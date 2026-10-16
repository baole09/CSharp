using System.Globalization;

namespace bai2
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;   // số dạng 5,200,000

        private bool _dangThem;   // true khi đang ở chế độ Thêm (nút Thêm đang là Hủy)

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: Lưu, Xóa mờ; các ô nhập rỗng, chỉ đọc =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            _dangThem = false;
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;

            XoaOnhap();
            DatChoPhepNhap(false);
            CapNhatTongTien();
            CanCotListView();
        }

        // ===== Chia độ rộng cột ListView theo kích thước hiện tại =====
        private void CanCotListView()
        {
            int tong = lvTK.ClientSize.Width - 2;
            if (tong < 300 || lvTK.Columns.Count < 5) return;

            double[] ti = { 0.08, 0.22, 0.28, 0.22, 0.20 };
            for (int i = 0; i < 5; i++)
                lvTK.Columns[i].Width = (int)(tong * ti[i]);
        }

        // ===== Tiện ích với các ô nhập =====
        private TextBox[] CacO => new[] { txtSoTK, txtTenKH, txtDiaChi, txtSoTien };

        private void DatChoPhepNhap(bool cho)
        {
            foreach (var t in CacO)
                t.ReadOnly = !cho;
        }

        private void XoaOnhap()
        {
            foreach (var t in CacO)
            {
                t.Clear();
                DatLoi(t, "");
            }
        }

        private void txt_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
        }

        // Số tài khoản và số tiền chỉ cho gõ chữ số
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===== Vào / thoát chế độ Thêm =====
        private void VaoCheDoThem()
        {
            _dangThem = true;
            lvTK.SelectedItems.Clear();   // bỏ chọn dòng để Xóa mờ

            XoaOnhap();
            DatChoPhepNhap(true);

            btnThem.Text = "Hủy";
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;

            txtSoTK.Focus();              // đặt con trỏ vào Số tài khoản
        }

        private void ThoatCheDoThem(bool giuNoiDung)
        {
            _dangThem = false;

            if (giuNoiDung)
            {
                foreach (var t in CacO) DatLoi(t, "");
            }
            else
            {
                XoaOnhap();
            }

            DatChoPhepNhap(false);
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
        }

        // ===== Thêm / Hủy =====
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (_dangThem) ThoatCheDoThem(false);
            else VaoCheDoThem();
        }

        // ===== Tổng tiền =====
        private void CapNhatTongTien()
        {
            long tong = lvTK.Items.Cast<ListViewItem>().Sum(it => (long)it.Tag!);
            txtTongTien.Text = tong.ToString("N0", Inv);
        }

        // ===== Đánh lại STT =====
        private void DanhLaiSTT()
        {
            for (int i = 0; i < lvTK.Items.Count; i++)
                lvTK.Items[i].Text = (i + 1).ToString();
        }

        // ===== Lưu: thêm một dòng vào ListView =====
        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!_dangThem) return;

            string so = txtSoTK.Text.Trim();
            string ten = string.Join(" ", txtTenKH.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            string dc = string.Join(" ", txtDiaChi.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var dsLoi = new List<string>();
            TextBox? dau = null;

            void Loi(TextBox t, string m)
            {
                DatLoi(t, m);
                dsLoi.Add(m);
                dau ??= t;
            }

            if (so.Length == 0)
                Loi(txtSoTK, "Số tài khoản không được để trống.");
            else if (lvTK.Items.Cast<ListViewItem>().Any(it => it.SubItems[1].Text == so))
                Loi(txtSoTK, $"Số tài khoản {so} đã tồn tại.");

            if (ten.Length == 0) Loi(txtTenKH, "Tên khách hàng không được để trống.");
            if (dc.Length == 0) Loi(txtDiaChi, "Địa chỉ không được để trống.");

            long tien = 0;
            if (txtSoTien.Text.Length == 0)
                Loi(txtSoTien, "Số tiền không được để trống.");
            else if (!long.TryParse(txtSoTien.Text, NumberStyles.None, Inv, out tien))
                Loi(txtSoTien, "Số tiền phải là số.");

            if (dsLoi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dau?.Focus();
                return;
            }

            var it2 = new ListViewItem(new[]
            {
                (lvTK.Items.Count + 1).ToString(),   // STT tự đánh
                so,
                ten,
                dc,
                tien.ToString("N0", Inv)
            })
            { Tag = tien };                          // giữ số tiền gốc để cộng tổng

            lvTK.Items.Add(it2);
            it2.EnsureVisible();

            CapNhatTongTien();
            ThoatCheDoThem(true);    // về trạng thái ban đầu, nội dung vừa lưu vẫn hiện
        }

        // ===== Click một dòng: hiện thông tin lên các textbox =====
        private void lvTK_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lvTK.SelectedItems.Count == 1)
            {
                if (_dangThem) ThoatCheDoThem(false);   // chọn dòng thì thoát chế độ Thêm

                var it = lvTK.SelectedItems[0];
                txtSoTK.Text = it.SubItems[1].Text;
                txtTenKH.Text = it.SubItems[2].Text;
                txtDiaChi.Text = it.SubItems[3].Text;
                txtSoTien.Text = ((long)it.Tag!).ToString(Inv);

                btnXoa.Enabled = true;                  // có dòng được chọn thì Xóa sáng
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        // ===== Xóa dòng đang chọn =====
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (lvTK.SelectedItems.Count != 1) return;

            var it = lvTK.SelectedItems[0];
            var kq = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản {it.SubItems[1].Text} của {it.SubItems[2].Text}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            lvTK.Items.Remove(it);
            DanhLaiSTT();
            CapNhatTongTien();
            XoaOnhap();
            btnXoa.Enabled = false;
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng form: nút X, Alt+F4, Thoát, Esc =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
