namespace nangcao
{
    public partial class Form1 : Form
    {
        private enum TrangThai { Trong, DangChon, DaBan }

        private readonly Dictionary<Button, TrangThai> _ghe = new();

        private static readonly Color MauTrong = Color.White;      // chưa bán
        private static readonly Color MauDangChon = Color.Blue;    // đang chọn
        private static readonly Color MauDaBan = Color.Yellow;     // đã bán

        public Form1()
        {
            InitializeComponent();
            TaoSoDoGhe();
        }

        // ===== Tạo 15 ghế, xếp 5 cột x 3 hàng =====
        private void TaoSoDoGhe()
        {
            for (int so = 1; so <= 15; so++)
            {
                var b = new Button
                {
                    Name = "btnGhe" + so,
                    Text = so.ToString(),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(6),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    UseVisualStyleBackColor = false,   // bắt buộc để BackColor có tác dụng
                    TabStop = false,
                    Tag = "ghe"                        // để file Highlight bỏ qua các nút này
                };
                b.Click += Ghe_Click;

                tlpGhe.Controls.Add(b, (so - 1) % 5, (so - 1) / 5);
                DatTrangThai(b, TrangThai.Trong);
            }
        }

        private void DatTrangThai(Button b, TrangThai tt)
        {
            _ghe[b] = tt;
            b.BackColor = tt switch
            {
                TrangThai.DangChon => MauDangChon,
                TrangThai.DaBan => MauDaBan,
                _ => MauTrong
            };
            b.ForeColor = tt == TrangThai.DangChon ? Color.White : Color.Black;
        }

        // Giá vé theo lô: ghế 1-5 (A) = 1000, 6-10 (B) = 1500, 11-15 (C) = 2000
        private static int GiaVe(int soGhe) => ((soGhe - 1) / 5) switch
        {
            0 => 1000,
            1 => 1500,
            _ => 2000
        };

        // ===== Click vào một ghế =====
        private void Ghe_Click(object? sender, EventArgs e)
        {
            var b = (Button)sender!;

            switch (_ghe[b])
            {
                case TrangThai.Trong:
                    DatTrangThai(b, TrangThai.DangChon);
                    break;

                case TrangThai.DangChon:
                    DatTrangThai(b, TrangThai.Trong);
                    break;

                case TrangThai.DaBan:
                    MessageBox.Show($"Ghế số {b.Text} đã bán. Vui lòng chọn ghế khác.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            btnChon.Focus();   // tránh việc Enter bấm lại chính ghế vừa click
        }

        // ===== Chọn: các ghế xanh thành vàng, xuất tổng tiền =====
        private void btnChon_Click(object? sender, EventArgs e)
        {
            var dangChon = _ghe.Where(kv => kv.Value == TrangThai.DangChon)
                               .Select(kv => kv.Key)
                               .ToList();

            if (dangChon.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn ghế nào.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long tong = 0;
            foreach (var b in dangChon)
            {
                tong += GiaVe(int.Parse(b.Text));
                DatTrangThai(b, TrangThai.DaBan);
            }

            txtThanhTien.Text = tong.ToString("N0");
        }

        // ===== Hủy bỏ: các ghế xanh về trắng, thành tiền = 0 =====
        private void btnHuyBo_Click(object? sender, EventArgs e)
        {
            var dangChon = _ghe.Where(kv => kv.Value == TrangThai.DangChon)
                               .Select(kv => kv.Key)
                               .ToList();

            foreach (var b in dangChon)
                DatTrangThai(b, TrangThai.Trong);

            txtThanhTien.Text = "0";
        }

        // ===== Kết thúc (Esc cũng gọi nút này) =====
        private void btnKetThuc_Click(object? sender, EventArgs e)
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
}