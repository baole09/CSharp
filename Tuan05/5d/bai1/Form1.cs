namespace bai1
{
    public partial class Form1 : Form
    {
        // Dữ liệu đổ vào combobox Dân tộc khi Form_Load
        private static readonly string[] DanToc =
        {
            "Kinh", "Tày", "Thái", "Mường", "Khmer", "Hoa", "Nùng", "H'Mông",
            "Dao", "Gia Rai", "Ê Đê", "Ba Na", "Sán Chay", "Chăm", "Xơ Đăng"
        };

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: thêm dữ liệu vào combobox Dân tộc =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            cboDanToc.Items.AddRange(DanToc);
            DatLaiTruongNhap(false);
            CanCotListView();
            ActiveControl = txtHoTen;
        }

        // Enter: đang chọn một dòng thì Sửa, ngược lại Thêm (để nút đang focus tự xử lý Enter của nó)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl is not Button && ActiveControl != lvSV)
            {
                if (lvSV.SelectedItems.Count == 1) btnSua.PerformClick();
                else btnThem.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txt_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Chia độ rộng cột của ListView theo kích thước hiện tại =====
        private void CanCotListView()
        {
            int tong = lvSV.ClientSize.Width - 2;
            if (tong < 300 || lvSV.Columns.Count < 5) return;

            double[] ti = { 0.28, 0.20, 0.12, 0.22, 0.18 };
            for (int i = 0; i < 5; i++)
                lvSV.Columns[i].Width = (int)(tong * ti[i]);
        }

        // ===== Làm mới các control nhập liệu =====
        private void DatLaiTruongNhap(bool focus)
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false;
            radNam.Checked = true;
            chkAnh.Checked = chkPhap.Checked = chkHoa.Checked = false;
            cboDanToc.SelectedIndex = cboDanToc.Items.Count > 0 ? 0 : -1;

            DatLoi(txtHoTen, "");
            DatLoi(txtMaSV, "");

            if (focus) txtHoTen.Focus();
        }

        // ===== Đọc và kiểm tra dữ liệu nhập =====
        private static string ChuanHoa(string s) =>
            string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        private string NgoaiNguDaChon()
        {
            var ds = new List<string>();
            if (chkAnh.Checked) ds.Add("Anh");
            if (chkPhap.Checked) ds.Add("Pháp");
            if (chkHoa.Checked) ds.Add("Hoa");
            return string.Join(", ", ds);
        }

        private bool DocDuLieu(out string hoTen, out string ma)
        {
            hoTen = ChuanHoa(txtHoTen.Text);
            ma = txtMaSV.Text.Trim();

            var dsLoi = new List<string>();
            TextBox? dau = null;

            void Loi(TextBox t, string m)
            {
                DatLoi(t, m);
                dsLoi.Add(m);
                dau ??= t;
            }

            if (hoTen.Length == 0) Loi(txtHoTen, "Họ và tên không được để trống.");
            if (ma.Length == 0) Loi(txtMaSV, "Mã sinh viên không được để trống.");

            if (cboDanToc.SelectedIndex < 0)
                dsLoi.Add("Chưa chọn dân tộc.");

            if (dsLoi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dau?.Focus();
                return false;
            }
            return true;
        }

        private bool TonTaiMaSV(string ma) =>
            lvSV.Items.Cast<ListViewItem>()
                .Any(it => string.Equals(it.SubItems[1].Text, ma, StringComparison.OrdinalIgnoreCase));

        // ===== Thêm =====
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!DocDuLieu(out string hoTen, out string ma)) return;

            // Không cho trùng mã sinh viên
            if (TonTaiMaSV(ma))
            {
                string loi = $"Mã sinh viên {ma} đã tồn tại.";
                DatLoi(txtMaSV, loi);
                MessageBox.Show(loi, "Trùng mã sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return;
            }

            var it = new ListViewItem(new[]
            {
                hoTen,
                ma,
                radNam.Checked ? "Nam" : "Nữ",
                NgoaiNguDaChon(),
                (string)cboDanToc.SelectedItem!
            });

            lvSV.SelectedItems.Clear();
            lvSV.Items.Add(it);
            it.EnsureVisible();

            DatLaiTruongNhap(true);
        }

        // ===== Chọn một dòng: hiện thông tin lên các control, khóa Mã sinh viên =====
        private void lvSV_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count == 1)
            {
                var it = lvSV.SelectedItems[0];

                txtHoTen.Text = it.Text;
                txtMaSV.Text = it.SubItems[1].Text;
                radNam.Checked = it.SubItems[2].Text == "Nam";
                radNu.Checked = it.SubItems[2].Text == "Nữ";

                string nn = it.SubItems[3].Text;
                var ds = nn.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                chkAnh.Checked = ds.Contains("Anh");
                chkPhap.Checked = ds.Contains("Pháp");
                chkHoa.Checked = ds.Contains("Hoa");

                cboDanToc.SelectedItem = it.SubItems[4].Text;

                txtMaSV.ReadOnly = true;   // không cho sửa mã sinh viên
                DatLoi(txtHoTen, "");
                DatLoi(txtMaSV, "");
            }
            else
            {
                txtMaSV.ReadOnly = false;
            }
        }

        // Click vào chỗ trống của ListView: bỏ chọn và làm mới ô nhập để nhập sinh viên mới
        private void lvSV_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lvSV.GetItemAt(e.X, e.Y) == null)
            {
                lvSV.SelectedItems.Clear();
                DatLaiTruongNhap(false);
            }
        }

        // ===== Sửa =====
        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count != 1)
            {
                MessageBox.Show("Hãy chọn đúng một sinh viên trong danh sách để sửa.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var it = lvSV.SelectedItems[0];
            if (!DocDuLieu(out string hoTen, out string ma)) return;

            // Không cho sửa mã sinh viên
            if (!string.Equals(ma, it.SubItems[1].Text, StringComparison.OrdinalIgnoreCase))
            {
                txtMaSV.Text = it.SubItems[1].Text;
                MessageBox.Show("Không được sửa mã sinh viên.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            it.Text = hoTen;
            it.SubItems[2].Text = radNam.Checked ? "Nam" : "Nữ";
            it.SubItems[3].Text = NgoaiNguDaChon();
            it.SubItems[4].Text = (string)cboDanToc.SelectedItem!;
        }

        // ===== Xóa (nút Xóa và mục Xóa của ContextMenuStrip dùng chung) =====
        private void XoaDangChon()
        {
            var chon = lvSV.SelectedItems.Cast<ListViewItem>().ToList();

            if (chon.Count == 0)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xóa trong danh sách.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoi = chon.Count == 1
                ? $"Bạn có chắc chắn muốn xóa sinh viên {chon[0].Text}?"
                : $"Bạn có chắc chắn muốn xóa {chon.Count} sinh viên đã chọn?";

            var kq = MessageBox.Show(hoi, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            lvSV.BeginUpdate();
            foreach (var it in chon)
                lvSV.Items.Remove(it);
            lvSV.EndUpdate();

            DatLaiTruongNhap(true);
        }

        private void btnXoa_Click(object? sender, EventArgs e) => XoaDangChon();

        private void tsmXoa_Click(object? sender, EventArgs e) => XoaDangChon();

        // Chuột phải: chỉ hiện menu khi có dòng được chọn
        private void ctxLv_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvSV.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        // ===== Hỏi xác nhận trước khi đóng form: nút X, Alt+F4 =====
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
