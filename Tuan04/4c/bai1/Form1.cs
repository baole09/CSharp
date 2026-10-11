using System.Globalization;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== MỨC 2: chặn ký tự không phải số khi đang gõ =====
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var txt = (TextBox)sender!;
            string dauThapPhan = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            // Phím điều khiển (Backspace, Ctrl+C/V/X...) luôn cho qua
            if (char.IsControl(e.KeyChar)) return;

            // Chữ số
            if (char.IsDigit(e.KeyChar)) return;

            // Dấu trừ: chỉ ở đầu và chỉ một lần
            if (e.KeyChar == '-')
            {
                bool dauChuoi = txt.SelectionStart == 0;
                bool daCoTru = txt.Text.Contains('-') && !txt.SelectedText.Contains('-');
                if (dauChuoi && !daCoTru) return;
            }

            // Dấu thập phân: chỉ một lần
            if (e.KeyChar.ToString() == dauThapPhan)
            {
                bool daCoDau = txt.Text.Contains(dauThapPhan) && !txt.SelectedText.Contains(dauThapPhan);
                if (!daCoDau) return;
            }

            e.Handled = true;   // chặn mọi ký tự còn lại
        }

        // ===== MỨC 1: ErrorProvider khi rời khỏi ô =====
        private void txtSo_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            KiemTraHopLe((TextBox)sender!);   // không đặt e.Cancel để không khóa focus / không chặn đóng form
        }

        private bool KiemTraHopLe(TextBox txt)
        {
            string ten = txt == txtA ? "a" : "b";

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider1.SetError(txt, $"Chưa nhập giá trị {ten}");
                return false;
            }

            if (!double.TryParse(txt.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out _))
            {
                errorProvider1.SetError(txt, $"Giá trị {ten} phải là số hợp lệ");
                return false;
            }

            errorProvider1.SetError(txt, "");
            return true;
        }

        // ===== Xử lý 4 phép toán =====
        private void btnPhepToan_Click(object? sender, EventArgs e)
        {
            bool aOk = KiemTraHopLe(txtA);
            bool bOk = KiemTraHopLe(txtB);

            if (!aOk || !bOk)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng nhập a, b là số.",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                (aOk ? txtB : txtA).Focus();
                txtKetQua.Clear();
                return;
            }

            double a = double.Parse(txtA.Text, CultureInfo.CurrentCulture);
            double b = double.Parse(txtB.Text, CultureInfo.CurrentCulture);
            double kq;

            switch (((Button)sender!).Text)
            {
                case "+": kq = a + b; break;
                case "-": kq = a - b; break;
                case "x": kq = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0.", "Lỗi dữ liệu",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(txtB, "b phải khác 0");
                        txtB.Focus();
                        txtKetQua.Clear();
                        return;
                    }
                    kq = a / b;
                    break;
                default: return;
            }

            txtKetQua.Text = kq.ToString(CultureInfo.CurrentCulture);
        }

        // ===== Hỏi xác nhận trước khi đóng Form =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        // Esc = đóng form (vẫn đi qua Form1_FormClosing để hỏi xác nhận)
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}