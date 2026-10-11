using System.Globalization;

namespace btvn
{
    // Nút không nhận focus: Enter không bấm lại phím vừa click
    internal class PhimButton : Button
    {
        public PhimButton()
        {
            SetStyle(ControlStyles.Selectable, false);
            TabStop = false;
        }
    }

    public partial class Form1 : Form
    {
        private double _soTruoc;          // toán hạng thứ nhất
        private string? _phepToan;        // phép toán đang chờ
        private bool _nhapSoMoi = true;   // true: chữ số kế tiếp sẽ thay màn hình

        public Form1()
        {
            InitializeComponent();
            TaoBanPhim();
        }

        // ===== Tạo 16 phím, xếp 4 cột x 4 hàng như ảnh đề =====
        private void TaoBanPhim()
        {
            string[] nhan =
            {
                "1", "2", "3", "4",
                "5", "6", "7", "8",
                "9", "0", "=", "C",
                "+", "-", "*", "/"
            };

            for (int i = 0; i < nhan.Length; i++)
            {
                var b = new PhimButton
                {
                    Text = nhan[i],
                    Name = "btnPhim" + i,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(6),
                    Font = new Font("Times New Roman", 14F, FontStyle.Regular),
                    UseVisualStyleBackColor = true
                };
                b.Click += Phim_Click;
                GanHieuUngNhan(b);   // hiệu ứng đổi màu khi nhấn (file Highlight)

                tlpPhim.Controls.Add(b, i % 4, i / 4);
            }
        }

        private void Phim_Click(object? sender, EventArgs e)
        {
            XuLyPhim(((Button)sender!).Text);
        }

        // ===== Bàn phím: gõ số, phép toán, =, c =====
        private void Form1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case >= '0' and <= '9':
                case '+':
                case '-':
                case '*':
                case '/':
                    XuLyPhim(e.KeyChar.ToString());
                    e.Handled = true;
                    break;

                case '=':
                    XuLyPhim("=");
                    e.Handled = true;
                    break;

                case 'c':
                case 'C':
                    XuLyPhim("C");
                    e.Handled = true;
                    break;
            }
        }

        // Enter = "=", Esc = "C"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                XuLyPhim("=");
                return true;
            }
            if (keyData == Keys.Escape)
            {
                XuLyPhim("C");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ===== Điều phối theo loại phím =====
        private void XuLyPhim(string phim)
        {
            if (phim.Length == 1 && char.IsDigit(phim[0]))
                NhapChuSo(phim);
            else if (phim is "+" or "-" or "*" or "/")
                NhapPhepToan(phim);
            else if (phim == "=")
                TinhKetQua();
            else if (phim == "C")
                Xoa();
        }

        private void NhapChuSo(string so)
        {
            if (_nhapSoMoi || lblManHinh.Text == "0")
            {
                lblManHinh.Text = so;
                _nhapSoMoi = false;
            }
            else if (lblManHinh.Text.Length < 15)
            {
                lblManHinh.Text += so;
            }
        }

        private void NhapPhepToan(string phep)
        {
            // Đã có phép toán chờ và vừa nhập xong số thứ hai: tính trước rồi mới nhận phép mới
            if (_phepToan != null && !_nhapSoMoi)
            {
                if (!Tinh(out double kq)) return;
                lblManHinh.Text = DinhDang(kq);
            }

            _soTruoc = DocManHinh();
            _phepToan = phep;
            _nhapSoMoi = true;
        }

        private void TinhKetQua()
        {
            if (_phepToan == null) return;
            if (!Tinh(out double kq)) return;

            lblManHinh.Text = DinhDang(kq);
            _phepToan = null;
            _nhapSoMoi = true;
        }

        // ===== Xóa (C): về trạng thái ban đầu =====
        private void Xoa()
        {
            lblManHinh.Text = "0";
            _soTruoc = 0;
            _phepToan = null;
            _nhapSoMoi = true;
        }

        // ===== Tính _soTruoc [phép toán] số trên màn hình =====
        private bool Tinh(out double kq)
        {
            double so2 = DocManHinh();
            kq = 0;

            switch (_phepToan)
            {
                case "+": kq = _soTruoc + so2; break;
                case "-": kq = _soTruoc - so2; break;
                case "*": kq = _soTruoc * so2; break;
                case "/":
                    if (so2 == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0.", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Xoa();
                        return false;
                    }
                    kq = _soTruoc / so2;
                    break;
            }
            return true;
        }

        private double DocManHinh() =>
            double.Parse(lblManHinh.Text, CultureInfo.CurrentCulture);

        private static string DinhDang(double so) =>
            so.ToString("G15", CultureInfo.CurrentCulture);
    }
}