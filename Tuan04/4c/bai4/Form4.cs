namespace bai4
{
    public partial class Form4 : Form
    {
        private readonly List<int> _day = new();   // dãy số đã nhập

        public Form4()
        {
            InitializeComponent();
        }

        // ===== Chặn nhập: chỉ chữ số, và dấu '-' ở đầu (một lần) =====
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var txt = (TextBox)sender!;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == '-')
            {
                bool dauChuoi = txt.SelectionStart == 0;
                bool daCoTru = txt.Text.Contains('-') && !txt.SelectedText.Contains('-');
                if (dauChuoi && !daCoTru) return;
            }

            e.Handled = true;
        }

        // ===== Kiểm tra ô nhập số =====
        private bool KiemTraSo(out int giaTri)
        {
            giaTri = 0;

            if (string.IsNullOrWhiteSpace(txtSo.Text))
            {
                DatLoi(txtSo, "Chưa nhập số");
                return false;
            }
            if (!int.TryParse(txtSo.Text, out giaTri))
            {
                DatLoi(txtSo, "Phải là số nguyên hợp lệ");
                return false;
            }

            DatLoi(txtSo, "");
            return true;
        }

        // Rời ô: ô rỗng thì bỏ qua (chỉ báo lỗi khi bấm Nhập), có chữ thì kiểm tra
        private void txtSo_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSo.Text))
                DatLoi(txtSo, "");
            else
                KiemTraSo(out _);
        }

        // ===== Nhập: thêm số vào dãy =====
        private void btnNhap_Click(object? sender, EventArgs e)
        {
            if (!KiemTraSo(out int so))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo.Focus();
                return;
            }

            _day.Add(so);
            txtDay.Text = string.Join(" ", _day);

            // dãy đổi nên kết quả tổng cũ không còn đúng
            txtTong.Clear();
            txtChan.Clear();
            txtLe.Clear();

            txtSo.Clear();
            txtSo.Focus();
        }

        // ===== Tính tổng, tổng chẵn, tổng lẻ =====
        private void btnTinhTong_Click(object? sender, EventArgs e)
        {
            if (_day.Count == 0)
            {
                MessageBox.Show("Chưa có số nào trong dãy. Hãy nhập số trước.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.Focus();
                return;
            }

            long tong = 0, chan = 0, le = 0;
            foreach (int x in _day)
            {
                tong += x;
                if (x % 2 == 0) chan += x;
                else le += x;           // số âm lẻ (vd -3 % 2 = -1) cũng vào đây
            }

            txtTong.Text = tong.ToString();
            txtChan.Text = chan.ToString();
            txtLe.Text = le.ToString();
        }

        // ===== Tiếp Tục: trả form về trạng thái ban đầu =====
        private void btnTiepTuc_Click(object? sender, EventArgs e)
        {
            _day.Clear();
            txtSo.Clear();
            txtDay.Clear();
            txtTong.Clear();
            txtChan.Clear();
            txtLe.Clear();
            DatLoi(txtSo, "");
            txtSo.Focus();
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form4_FormClosing để hỏi xác nhận
        }

        private void Form4_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}