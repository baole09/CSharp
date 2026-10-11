using System.Text.RegularExpressions;

namespace bai2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // ===== Kiểm tra từng ô (true nếu hợp lệ, đồng thời bật/tắt viền đỏ) =====
        private bool KiemTraBatBuoc(TextBox txt, string ten)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                DatLoi(txt, $"Bắt buộc nhập {ten}");
                return false;
            }
            DatLoi(txt, "");
            return true;
        }

        private bool KiemTraEmail()
        {
            if (!KiemTraBatBuoc(txtEmail, "địa chỉ email")) return false;

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                DatLoi(txtEmail, "Email không đúng định dạng (vd: ten@gmail.com)");
                return false;
            }
            DatLoi(txtEmail, "");
            return true;
        }

        private bool KiemTraXacNhan()
        {
            if (txtXacNhan.Text != txtMatKhau.Text)
            {
                DatLoi(txtXacNhan, "Mật khẩu xác nhận không khớp");
                return false;
            }
            DatLoi(txtXacNhan, "");
            return true;
        }

        // ===== Validating: chạy khi rời khỏi ô (không đặt e.Cancel) =====
        private void txtBatBuoc_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            KiemTraBatBuoc(txtTenDangNhap, "tên đăng nhập");
        }

        private void txtEmail_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            KiemTraEmail();
        }

        private void txtMatKhau_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            KiemTraBatBuoc(txtMatKhau, "mật khẩu");
            if (txtXacNhan.Text.Length > 0) KiemTraXacNhan();
        }

        private void txtXacNhan_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            KiemTraXacNhan();
        }

        // ===== Nút Đăng ký (cũng là Enter) =====
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            bool tenOk = KiemTraBatBuoc(txtTenDangNhap, "tên đăng nhập");
            bool emailOk = KiemTraEmail();
            bool mkOk = KiemTraBatBuoc(txtMatKhau, "mật khẩu");
            bool xnOk = KiemTraXacNhan();

            if (!tenOk || !emailOk || !mkOk || !xnOk)
            {
                MessageBox.Show("Thông tin chưa hợp lệ. Vui lòng kiểm tra các ô có viền đỏ.",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (!tenOk) txtTenDangNhap.Focus();
                else if (!emailOk) txtEmail.Focus();
                else if (!mkOk) txtMatKhau.Focus();
                else txtXacNhan.Focus();
                return;
            }

            MessageBox.Show(
                $"Tên đăng nhập: {txtTenDangNhap.Text}\n" +
                $"Địa chỉ email: {txtEmail.Text}\n" +
                $"Mật khẩu: {txtMatKhau.Text}\n" +
                $"Xác nhận mật khẩu: {txtXacNhan.Text}",
                "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Esc = đóng form (vẫn đi qua Form1_FormClosing) =====
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        // ===== Hỏi xác nhận trước khi đóng Form =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
        // ===== Ẩn / hiện mật khẩu =====
        private void chkHienMatKhau_CheckedChanged(object? sender, EventArgs e)
        {
            bool hien = chkHienMatKhau.Checked;
            txtMatKhau.UseSystemPasswordChar = !hien;
            txtXacNhan.UseSystemPasswordChar = !hien;
        }
    }
}