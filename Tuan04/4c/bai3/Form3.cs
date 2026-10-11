namespace bai3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // ===== Chặn nhập khác chữ số =====
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===== Kiểm tra một ô: hợp lệ thì trả về true và giá trị =====
        private bool KiemTraSo(TextBox txt, string ten, out long giaTri)
        {
            giaTri = 0;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                DatLoi(txt, $"Chưa nhập số {ten}");
                return false;
            }
            if (!long.TryParse(txt.Text, out giaTri))
            {
                DatLoi(txt, $"Số {ten} phải là số nguyên");
                return false;
            }
            if (giaTri <= 0)
            {
                DatLoi(txt, $"Số {ten} phải là số nguyên dương (> 0)");
                return false;
            }

            DatLoi(txt, "");
            return true;
        }

        // Rời ô thì kiểm tra (không đặt e.Cancel để không khóa focus)
        private void txtSo_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender!;
            KiemTraSo(txt, txt == txtA ? "a" : "b", out _);
        }

        private static long UCLN(long a, long b)
        {
            while (b != 0)
            {
                long r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        // ===== Thực Hiện =====
        private void btnThucHien_Click(object? sender, EventArgs e)
        {
            bool aOk = KiemTraSo(txtA, "a", out long a);
            bool bOk = KiemTraSo(txtB, "b", out long b);

            if (!aOk || !bOk)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng nhập a, b là số nguyên dương.",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUCLN.Clear();
                txtBCNN.Clear();
                (aOk ? txtB : txtA).Focus();
                return;
            }

            long ucln = UCLN(a, b);
            long bcnn = a / ucln * b;   // chia trước để giảm nguy cơ tràn số

            txtUCLN.Text = ucln.ToString();
            txtBCNN.Text = bcnn.ToString();
        }

        // ===== Tiếp Tục: làm mới để nhập lại =====
        private void btnTiepTuc_Click(object? sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            DatLoi(txtA, "");
            DatLoi(txtB, "");
            txtA.Focus();
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form3_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng Form =====
        private void Form3_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}