using System.Globalization;
using System.Text;

namespace btvn1
{
    public partial class Form1 : Form
    {
        // Từ điển lưu sẵn trong List: (từ tiếng Anh, nghĩa tiếng Việt). Thêm từ mới ở đây.
        private static readonly List<(string Anh, string Viet)> TuDien = new()
        {
            ("student", "Sinh viên, học sinh"),
            ("teacher", "Giáo viên, thầy giáo, cô giáo"),
            ("worker", "Công nhân"),
            ("hat", "Cái mũ, nón"),
            ("head", "Cái đầu"),
            ("mouse", "Con chuột"),
            ("cat", "Con mèo"),
            ("dog", "Con chó"),
            ("snake", "Con rắn"),
            ("lamb", "Con cừu non"),
            ("loan", "Khoản vay"),
            ("frog", "Con ếch"),
            ("sheep", "Con cừu"),
            ("book", "Quyển sách"),
            ("pen", "Cây bút"),
            ("table", "Cái bàn"),
            ("chair", "Cái ghế"),
            ("house", "Ngôi nhà"),
            ("car", "Xe hơi, ô tô"),
            ("water", "Nước"),
            ("fire", "Lửa"),
            ("computer", "Máy tính"),
            ("school", "Trường học"),
            ("friend", "Bạn bè"),
            ("apple", "Quả táo"),
            ("rice", "Cơm, gạo"),
            ("sun", "Mặt trời"),
            ("moon", "Mặt trăng"),
            ("love", "Tình yêu, yêu"),
            ("happy", "Vui vẻ, hạnh phúc"),
        };

        // Dữ liệu dựng từ TuDien khi form load
        private readonly Dictionary<string, string> _anhViet = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, List<string>> _vietAnh = new(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> _dsAnh = new();    // các từ tiếng Anh, đã sắp xếp
        private readonly List<string> _dsViet = new();   // các từ tiếng Việt, đã sắp xếp

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: dựng dữ liệu và đổ vào combobox, listbox =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            foreach (var (anh, viet) in TuDien)
            {
                string a = Chuan(anh).ToLower();
                _anhViet[a] = viet;

                // Tách từng nghĩa tiếng Việt để tra ngược Việt - Anh
                foreach (string v in viet.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    string k = Chuan(v).ToLower();
                    if (k.Length == 0) continue;

                    if (!_vietAnh.TryGetValue(k, out var ds))
                        _vietAnh[k] = ds = new List<string>();
                    if (!ds.Contains(a)) ds.Add(a);
                }
            }

            _dsAnh.AddRange(_anhViet.Keys.OrderBy(x => x, StringComparer.OrdinalIgnoreCase));
            _dsViet.AddRange(_vietAnh.Keys.OrderBy(x => x, StringComparer.Create(new CultureInfo("vi-VN"), true)));

            cboAnh.Items.AddRange(_dsAnh.ToArray());
            lstAnh.Items.AddRange(_dsAnh.ToArray());
            cboViet.Items.AddRange(_dsViet.ToArray());
            lstViet.Items.AddRange(_dsViet.ToArray());
        }

        // ===== Tiện ích xử lý chữ =====
        private static string Chuan(string s) => s.Trim().Normalize(NormalizationForm.FormC);

        // Bỏ dấu tiếng Việt và đưa về chữ thường để so khớp không phân biệt dấu
        private static string BoDau(string s)
        {
            string d = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in d)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);

            return sb.ToString().Normalize(NormalizationForm.FormC)
                     .Replace('đ', 'd').Replace('Đ', 'D')
                     .ToLowerInvariant();
        }

        // Từ có phần đầu khớp nhiều ký tự nhất với chữ đang gõ (danh sách đã sắp xếp nên khi bằng nhau lấy từ đứng trước)
        private static string? TimGanNhat(List<string> ds, string dangGo)
        {
            string g = BoDau(dangGo.Trim());
            if (g.Length == 0) return null;

            string? tot = null;
            int dai = 0;

            foreach (string w in ds)
            {
                string b = BoDau(w);
                int n = 0;
                while (n < g.Length && n < b.Length && g[n] == b[n]) n++;

                if (n > dai)
                {
                    dai = n;
                    tot = w;
                }
            }
            return tot;   // null nếu không khớp ký tự nào
        }

        // Tìm từ để tra: khớp đúng cả từ thì lấy luôn, không thì lấy từ bắt đầu bằng chữ đã gõ
        private static string? TimTu(List<string> ds, string dangGo)
        {
            string g = Chuan(dangGo).ToLower();
            if (g.Length == 0) return null;

            string? dung = ds.FirstOrDefault(w => string.Equals(w, g, StringComparison.OrdinalIgnoreCase));
            if (dung != null) return dung;

            string bg = BoDau(g);
            return ds.FirstOrDefault(w => BoDau(w).StartsWith(bg, StringComparison.Ordinal));
        }

        private static void ChonTrongList(ListBox lst, string? tu)
        {
            if (tu != null) lst.SelectedItem = tu;   // listbox tự cuộn tới từ đó
            else lst.ClearSelected();
        }

        // ===== Gõ vào combobox: dò tìm đến từ khớp gần nhất trong danh sách =====
        private void cboAnh_TextChanged(object? sender, EventArgs e)
        {
            ChonTrongList(lstAnh, TimGanNhat(_dsAnh, cboAnh.Text));
        }

        private void cboViet_TextChanged(object? sender, EventArgs e)
        {
            ChonTrongList(lstViet, TimGanNhat(_dsViet, cboViet.Text));
        }

        // ===== Tra nghĩa =====
        private void TraAnhViet()
        {
            if (string.IsNullOrWhiteSpace(cboAnh.Text))
            {
                txtNghiaViet.Clear();
                MessageBox.Show("Chưa nhập từ cần tra.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? tu = TimTu(_dsAnh, cboAnh.Text);
            if (tu == null)
            {
                txtNghiaViet.Clear();
                MessageBox.Show($"Không tìm thấy từ \"{cboAnh.Text.Trim()}\" trong từ điển.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cboAnh.Text = tu;                       // điền đầy đủ từ vừa tìm được
            cboAnh.SelectionStart = cboAnh.Text.Length;
            lstAnh.SelectedItem = tu;
            txtNghiaViet.Text = _anhViet[tu];
        }

        private void TraVietAnh()
        {
            if (string.IsNullOrWhiteSpace(cboViet.Text))
            {
                txtNghiaAnh.Clear();
                MessageBox.Show("Chưa nhập từ cần tra.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? tu = TimTu(_dsViet, cboViet.Text);
            if (tu == null)
            {
                txtNghiaAnh.Clear();
                MessageBox.Show($"Không tìm thấy từ \"{cboViet.Text.Trim()}\" trong từ điển.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cboViet.Text = tu;
            cboViet.SelectionStart = cboViet.Text.Length;
            lstViet.SelectedItem = tu;
            txtNghiaAnh.Text = string.Join(", ", _vietAnh[tu]);
        }

        // ===== Double click một từ trong danh sách: hiện nghĩa =====
        private void lstAnh_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            int i = lstAnh.IndexFromPoint(e.Location);
            if (i == ListBox.NoMatches) return;

            cboAnh.Text = (string)lstAnh.Items[i];
            TraAnhViet();
        }

        private void lstViet_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            int i = lstViet.IndexFromPoint(e.Location);
            if (i == ListBox.NoMatches) return;

            cboViet.Text = (string)lstViet.Items[i];
            TraVietAnh();
        }

        // ===== Phím Enter trong combobox: tra nghĩa =====
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (cboAnh.ContainsFocus)
                {
                    TraAnhViet();
                    return true;
                }
                if (cboViet.ContainsFocus)
                {
                    TraVietAnh();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng form: nút X, Alt+F4, Thoát, Esc =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;   // chọn No thì không đóng
        }
    }
}
