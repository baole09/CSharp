namespace nangcao
{
    public partial class Form1 : Form
    {
        // Các mảng chuỗi dùng để ghép tên ngẫu nhiên
        private static readonly string[] HO =
            { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };

        private static readonly string[] TENLOT =
            { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };

        private static readonly string[] TEN =
            { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Tiện ích xử lý chuỗi =====
        // Tách tên thành các từ (bỏ khoảng trắng thừa)
        private static string[] TachTu(string ten) =>
            ten.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // So sánh không phân biệt hoa thường, đưa về dạng dựng sẵn để chữ có dấu so sánh đúng
        private static bool Bang(string a, string b) =>
            string.Equals(a.Normalize(System.Text.NormalizationForm.FormC),
                          b.Normalize(System.Text.NormalizationForm.FormC),
                          StringComparison.OrdinalIgnoreCase);

        // Viết hoa chữ đầu mỗi từ, các chữ còn lại viết thường
        private static string VietHoaDau(string s) =>
            string.Join(" ", TachTu(s).Select(w => char.ToUpper(w[0]) + w[1..].ToLower()));

        // Các chỉ số đang chọn trong listbox (đã chép ra danh sách)
        private List<int> DangChon() => lstTen.SelectedIndices.Cast<int>().ToList();

        private bool CoChon(out List<int> chon)
        {
            chon = DangChon();
            if (chon.Count == 0)
            {
                MessageBox.Show("Chưa chọn phần tử nào trong danh sách.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ===== Nhập tên ngẫu nhiên: thêm 50 tên =====
        private void btnNgauNhien_Click(object? sender, EventArgs e)
        {
            lstTen.BeginUpdate();
            for (int i = 0; i < 50; i++)
            {
                string ho = HO[Random.Shared.Next(HO.Length)];
                string lot = TENLOT[Random.Shared.Next(TENLOT.Length)];
                string ten = TEN[Random.Shared.Next(TEN.Length)];
                lstTen.Items.Add($"{ho} {lot} {ten}");
            }
            lstTen.EndUpdate();
        }

        // ===== Xóa các phần tử đang chọn =====
        private void btnXoaChon_Click(object? sender, EventArgs e)
        {
            if (!CoChon(out var chon)) return;

            lstTen.BeginUpdate();
            foreach (int i in chon.OrderByDescending(x => x))   // xóa từ cuối lên để chỉ số không lệch
                lstTen.Items.RemoveAt(i);
            lstTen.EndUpdate();
        }

        // ===== Xóa theo điều kiện (tên là Sơn / họ là Lê) =====
        private void XoaTheo(Func<string, bool> dieuKien, string moTa)
        {
            int dem = 0;

            lstTen.BeginUpdate();
            for (int i = lstTen.Items.Count - 1; i >= 0; i--)
            {
                if (dieuKien((string)lstTen.Items[i]))
                {
                    lstTen.Items.RemoveAt(i);
                    dem++;
                }
            }
            lstTen.EndUpdate();

            MessageBox.Show(dem > 0 ? $"Đã xóa {dem} phần tử {moTa}."
                                    : $"Không có phần tử nào {moTa}.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaSon_Click(object? sender, EventArgs e)
        {
            // Tên là từ cuối cùng của chuỗi
            XoaTheo(s => { var t = TachTu(s); return t.Length > 0 && Bang(t[^1], "Sơn"); }, "có tên là Sơn");
        }

        private void btnXoaHoLe_Click(object? sender, EventArgs e)
        {
            // Họ là từ đầu tiên của chuỗi
            XoaTheo(s => { var t = TachTu(s); return t.Length > 0 && Bang(t[0], "Lê"); }, "có họ là Lê");
        }

        // ===== Biến đổi các phần tử đang chọn (giữ nguyên trạng thái chọn) =====
        private void BienDoiDangChon(Func<string, string> bienDoi)
        {
            if (!CoChon(out var chon)) return;

            lstTen.BeginUpdate();
            foreach (int i in chon)
                lstTen.Items[i] = bienDoi((string)lstTen.Items[i]);
            foreach (int i in chon)
                lstTen.SetSelected(i, true);   // gán một phần tử làm mất chọn nên chọn lại
            lstTen.EndUpdate();
        }

        private void btnHoa_Click(object? sender, EventArgs e) =>
            BienDoiDangChon(s => s.ToUpper());

        private void btnThuong_Click(object? sender, EventArgs e) =>
            BienDoiDangChon(s => s.ToLower());

        private void btnVietHoaDau_Click(object? sender, EventArgs e) =>
            BienDoiDangChon(VietHoaDau);

        // ===== Xóa tất cả =====
        private void btnXoaTatCa_Click(object? sender, EventArgs e)
        {
            if (lstTen.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đang rỗng.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lstTen.Items.Clear();
        }

        // ===== Double click một tên: mở hộp nhập để đổi tên tại vị trí đó =====
        private void lstTen_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            int i = lstTen.IndexFromPoint(e.Location);
            if (i == ListBox.NoMatches) return;

            string cu = (string)lstTen.Items[i];
            string? moi = HopNhap(this, "Đổi tên", $"Nhập tên mới thay cho \"{cu}\":", cu);

            if (moi == null) return;   // bấm Hủy

            moi = string.Join(" ", TachTu(moi));   // bỏ khoảng trắng thừa
            if (moi.Length == 0)
            {
                MessageBox.Show("Tên không được để trống.", "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstTen.Items[i] = moi;       // thay đúng vị trí cũ
            lstTen.SetSelected(i, true);
        }

        // Hộp nhập chuỗi (thay cho InputBox của VB). Trả về null nếu bấm Hủy.
        // private static string? HopNhap(IWin32Window chu, string tieuDe, string loiNhac, string macDinh)
        // {
        //     using var f = new Form
        //     {
        //         Text = tieuDe,
        //         FormBorderStyle = FormBorderStyle.FixedDialog,
        //         StartPosition = FormStartPosition.CenterParent,
        //         MinimizeBox = false,
        //         MaximizeBox = false,
        //         ShowInTaskbar = false,
        //         ClientSize = new Size(420, 150)
        //     };

        //     var lbl = new Label { Text = loiNhac, Left = 15, Top = 15, Width = 390, Height = 36, AutoSize = false };
        //     var txt = new TextBox { Left = 15, Top = 60, Width = 390, Text = macDinh };
        //     var ok = new Button { Text = "OK", Left = 230, Top = 100, Width = 80, DialogResult = DialogResult.OK };
        //     var huy = new Button { Text = "Hủy", Left = 325, Top = 100, Width = 80, DialogResult = DialogResult.Cancel };

        //     f.Controls.AddRange(new Control[] { lbl, txt, ok, huy });
        //     f.AcceptButton = ok;
        //     f.CancelButton = huy;
        //     f.Shown += (s, ev) => { txt.Focus(); txt.SelectAll(); };

        //     return f.ShowDialog(chu) == DialogResult.OK ? txt.Text : null;
        // }
        // ===== Hỏi xác nhận trước khi đóng form (nút X, Alt+F4...) =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;   // chọn No thì không đóng
        }
            // Hộp nhập chuỗi (thay cho InputBox của VB), có ba nút đổi kiểu chữ. Trả về null nếu bấm Hủy.
        private static string? HopNhap(IWin32Window chu, string tieuDe, string loiNhac, string macDinh)
        {
            using var f = new Form
            {
                Text = tieuDe,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(420, 200)
            };

            var lbl = new Label { Text = loiNhac, Left = 15, Top = 15, Width = 390, Height = 36, AutoSize = false };
            var txt = new TextBox { Left = 15, Top = 60, Width = 390, Text = macDinh };

            // Ba nút đổi kiểu tên, tác động lên nội dung trong hộp nhập
            var btnHoa = new Button { Text = "HOA", Left = 15, Top = 100, Width = 120, Height = 30 };
            var btnThuong = new Button { Text = "thường", Left = 150, Top = 100, Width = 120, Height = 30 };
            var btnDau = new Button { Text = "Viết Hoa Đầu", Left = 285, Top = 100, Width = 120, Height = 30 };

            var ok = new Button { Text = "OK", Left = 230, Top = 150, Width = 80, Height = 30, DialogResult = DialogResult.OK };
            var huy = new Button { Text = "Hủy", Left = 325, Top = 150, Width = 80, Height = 30, DialogResult = DialogResult.Cancel };

            void DatChu(string v)
            {
                txt.Text = v;
                txt.Focus();
                txt.SelectionStart = txt.TextLength;   // đưa con trỏ về cuối chữ
            }

            btnHoa.Click += (s, ev) => DatChu(txt.Text.ToUpper());
            btnThuong.Click += (s, ev) => DatChu(txt.Text.ToLower());
            btnDau.Click += (s, ev) => DatChu(VietHoaDau(txt.Text));

            f.Controls.AddRange(new Control[] { lbl, txt, btnHoa, btnThuong, btnDau, ok, huy });
            f.AcceptButton = ok;
            f.CancelButton = huy;
            f.Shown += (s, ev) => { txt.Focus(); txt.SelectAll(); };

            return f.ShowDialog(chu) == DialogResult.OK ? txt.Text : null;
        }
    }
}
