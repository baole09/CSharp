namespace btvn1
{
    public partial class Form1 : Form
    {
        private const int TongGiay = 30 * 60;   // 30 phút

        private enum TrangThai { ChuaChay, DangChay, TamDung }

        private TrangThai _tt = TrangThai.ChuaChay;
        private TimeSpan _conLai = TimeSpan.FromSeconds(TongGiay);   // thời gian còn lại khi dừng
        private long _hetGio;                                         // mốc kết thúc (Environment.TickCount64)

        public Form1()
        {
            InitializeComponent();
            HienThi(TongGiay);
        }

        // ===== Hiển thị mm:ss; 10 giây cuối chuyển sang màu đỏ =====
        private void HienThi(int giay)
        {
            lblThoiGian.Text = $"{giay / 60:00}:{giay % 60:00}";
            lblThoiGian.ForeColor = (_tt == TrangThai.DangChay && giay <= 10) ? Color.Red : SystemColors.ControlText;
        }

        // ===== Bắt đầu / Tạm dừng / Tiếp tục =====
        private void btnBatDau_Click(object? sender, EventArgs e)
        {
            switch (_tt)
            {
                case TrangThai.ChuaChay:
                case TrangThai.TamDung:
                    // Đặt mốc kết thúc = bây giờ + thời gian còn lại, rồi chạy bộ định thời
                    _hetGio = Environment.TickCount64 + (long)_conLai.TotalMilliseconds;
                    _tt = TrangThai.DangChay;
                    timer1.Start();
                    btnBatDau.Text = "Tạm dừng";
                    break;

                case TrangThai.DangChay:
                    // Lưu lại thời gian còn lại để lần sau đếm tiếp
                    long con = Math.Max(0, _hetGio - Environment.TickCount64);
                    _conLai = TimeSpan.FromMilliseconds(con);
                    timer1.Stop();
                    _tt = TrangThai.TamDung;
                    btnBatDau.Text = "Tiếp tục";
                    HienThi((int)Math.Ceiling(_conLai.TotalSeconds));
                    break;
            }
        }

        // ===== Mỗi lần Tick: tính lại thời gian còn lại theo đồng hồ hệ thống =====
        private void timer1_Tick(object? sender, EventArgs e)
        {
            long con = _hetGio - Environment.TickCount64;

            if (con <= 0)
            {
                timer1.Stop();
                HienThi(0);
                MessageBox.Show("Hết giờ!", "Đồng hồ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatLai();
                return;
            }

            HienThi((int)Math.Ceiling(con / 1000.0));
        }

        // ===== Về trạng thái ban đầu: 30:00 và nút Bắt đầu =====
        private void DatLai()
        {
            _tt = TrangThai.ChuaChay;
            _conLai = TimeSpan.FromSeconds(TongGiay);
            btnBatDau.Text = "Bắt đầu";
            HienThi(TongGiay);
        }

        // ===== Hỏi xác nhận khi đóng form lúc đồng hồ đang chạy hoặc đang tạm dừng =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            if (_tt == TrangThai.ChuaChay) return;

            var kq = MessageBox.Show("Đồng hồ đang đếm. Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
