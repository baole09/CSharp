using System.Globalization;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form load: Giải mờ, mặc định chọn bậc nhất =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            button_giai.Enabled = false;
            radioButton_bacnhat.Checked = true;
            CapNhatGiaoDien();
        }

        // ===== Chọn loại phương trình =====
        private void radiobutton_bacnhat_CheckedChanged(object? sender, EventArgs e)
        {
            CapNhatGiaoDien();
        }

        private void radiobutton_bachai_CheckedChanged(object? sender, EventArgs e)
        {
            CapNhatGiaoDien();
        }

        // Bậc nhất thì làm mờ ô và nhãn "Nhập c"; bậc hai thì bật lại
        private void CapNhatGiaoDien()
        {
            bool bacHai = radioButton_bachai.Checked;

            Inputc.Enabled = bacHai;
            Tc.Enabled = bacHai;

            if (!bacHai)
            {
                Inputc.Clear();
                DatLoi(Inputc, "");
            }

            Outputketqua.Clear();
            CapNhatNutGiai();
        }

        // Giải chỉ sáng khi các ô cần thiết đã có dữ liệu
        private void CapNhatNutGiai()
        {
            bool bacHai = radioButton_bachai.Checked;

            bool day = !string.IsNullOrWhiteSpace(Inputa.Text)
                    && !string.IsNullOrWhiteSpace(Inputb.Text)
                    && (!bacHai || !string.IsNullOrWhiteSpace(Inputc.Text));

            button_giai.Enabled = day;
        }

        // ===== Nhập liệu =====
        private void txtDuLieu_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
            Outputketqua.Clear();           // kết quả cũ không còn đúng
            CapNhatNutGiai();
        }

        // Chỉ cho gõ: chữ số, '-' ở đầu (một lần), một dấu thập phân ('.' hoặc ',')
        private void txtDuLieu_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var txt = (TextBox)sender!;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == '-')
            {
                bool dauChuoi = txt.SelectionStart == 0;
                bool daCoTru = txt.Text.Contains('-') && !txt.SelectedText.Contains('-');
                if (dauChuoi && !daCoTru) return;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                bool daCoDau = (txt.Text.Contains('.') || txt.Text.Contains(','))
                               && !txt.SelectedText.Contains('.') && !txt.SelectedText.Contains(',');
                if (!daCoDau) return;
            }

            e.Handled = true;
        }

        // Đọc một ô thành số, lỗi thì báo bằng viền đỏ và trả về thông điệp
        private bool DocSo(TextBox txt, string ten, out double giaTri, List<string> dsLoi)
        {
            giaTri = 0;
            string s = txt.Text.Trim().Replace(',', '.');

            if (!double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out giaTri)
                || !double.IsFinite(giaTri))
            {
                string loi = $"Hệ số {ten} phải là số hợp lệ.";
                DatLoi(txt, loi);
                dsLoi.Add(loi);
                return false;
            }

            DatLoi(txt, "");
            return true;
        }

        // ===== Giải =====
        private void button_giai_Click(object? sender, EventArgs e)
        {
            bool bacHai = radioButton_bachai.Checked;
            var dsLoi = new List<string>();

            bool aOk = DocSo(Inputa, "a", out double a, dsLoi);
            bool bOk = DocSo(Inputb, "b", out double b, dsLoi);
            double c = 0;
            bool cOk = !bacHai || DocSo(Inputc, "c", out c, dsLoi);

            if (!aOk || !bOk || !cOk)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (!aOk) Inputa.Focus();
                else if (!bOk) Inputb.Focus();
                else Inputc.Focus();
                return;
            }

            var pt = new PhuongTrinhBacHai(a, b, c);
            Outputketqua.Text = bacHai ? pt.GiaiBacHai() : pt.GiaiBacNhat();

            button_giai.Enabled = false;   // giải xong thì Giải mờ đi
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void button_thoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
    public class PhuongTrinhBacHai
    {
        // Thuộc tính: hệ số của phương trình
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public PhuongTrinhBacHai() { }

        public PhuongTrinhBacHai(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Delta => B * B - 4 * A * C;

        // Định dạng số: 2 chữ số thập phân, dấu chấm, không hiện -0.00
        private static string Dinh(double x)
        {
            x = Math.Round(x, 2);
            if (x == 0) x = 0;
            return x.ToString("F2", CultureInfo.InvariantCulture);
        }

        // Giải ax + b = 0  (dùng A và B)
        public string GiaiBacNhat()
        {
            if (A == 0)
                return B == 0 ? "Phương trình vô số nghiệm" : "Phương trình vô nghiệm";

            return $"Phương trình có nghiệm x = {Dinh(-B / A)}";
        }

        // Giải ax^2 + bx + c = 0  (dùng A, B, C)
        public string GiaiBacHai()
        {
            if (A == 0)
            {
                // a = 0: quy về bx + c = 0
                var bacNhat = new PhuongTrinhBacHai(B, C, 0);
                return "a = 0 nên giải như phương trình bậc nhất. " + bacNhat.GiaiBacNhat();
            }

            double delta = Delta;

            if (Math.Abs(delta) < 1e-12)
                return $"Phương trình có nghiệm kép x1 = x2 = {Dinh(-B / (2 * A))}";

            if (delta < 0)
                return "Phương trình vô nghiệm";

            double can = Math.Sqrt(delta);
            double x1 = (-B - can) / (2 * A);
            double x2 = (-B + can) / (2 * A);
            return $"Phương trình có 2 nghiệm phân biệt x1 = {Dinh(x1)}, x2 = {Dinh(x2)}";
        }
    }
}