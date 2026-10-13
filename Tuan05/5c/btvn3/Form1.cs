using System.Globalization;
using System.Text;

namespace btvn3
{
    public partial class Form1 : Form
    {
        // So sánh chuỗi theo thứ tự chữ cái tiếng Việt
        private static readonly StringComparer SoSanhViet =
            StringComparer.Create(new CultureInfo("vi-VN"), true);

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: TreeView chứa các ký tự A -> Z =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
                tvDanhBa.Nodes.Add(c.ToString(), c.ToString());   // khóa = chữ cái để tìm node nhanh

            ActiveControl = txtFirstName;
        }

        private void txt_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Tiện ích xử lý chữ =====
        // Bỏ dấu tiếng Việt (Đ thành D) và đưa về chữ in hoa
        private static string BoDau(string s)
        {
            string d = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in d)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);

            return sb.ToString().Normalize(NormalizationForm.FormC)
                     .Replace('đ', 'd').Replace('Đ', 'D')
                     .ToUpperInvariant();
        }

        // Bỏ khoảng trắng thừa giữa các từ
        private static string ChuanHoa(string s) =>
            string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        // Chữ cái đầu của tên (A-Z, đã bỏ dấu); trả về null nếu không phải chữ cái
        private static char? ChuCaiDau(string ten)
        {
            string b = BoDau(ten);
            if (b.Length == 0) return null;

            char c = b[0];
            return c >= 'A' && c <= 'Z' ? c : null;
        }

        // ===== Add: đưa người mới vào node của chữ cái đầu của tên =====
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string first = ChuanHoa(txtFirstName.Text);
            string last = ChuanHoa(txtLastName.Text);

            var dsLoi = new List<string>();
            TextBox? dau = null;

            void Loi(TextBox t, string m)
            {
                DatLoi(t, m);
                dsLoi.Add(m);
                dau ??= t;
            }

            char? chu = null;

            if (first.Length == 0)
                Loi(txtFirstName, "First Name không được để trống.");
            else
            {
                chu = ChuCaiDau(first);
                if (chu == null)
                    Loi(txtFirstName, "First Name phải bắt đầu bằng một chữ cái (A-Z).");
            }

            if (last.Length == 0)
                Loi(txtLastName, "Last Name không được để trống.");

            if (dsLoi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dau?.Focus();
                return;
            }

            TreeNode nodeChu = tvDanhBa.Nodes[chu!.Value.ToString()];
            string text = $"{first}, {last}";

            // Không thêm trùng cùng họ tên trong một node
            if (nodeChu.Nodes.Cast<TreeNode>().Any(n =>
                    string.Equals(n.Text, text, StringComparison.OrdinalIgnoreCase)))
            {
                string msg = $"\"{text}\" đã có trong danh bạ.";
                DatLoi(txtFirstName, msg);
                MessageBox.Show(msg, "Trùng danh bạ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFirstName.Focus();
                return;
            }

            // Chèn đúng vị trí theo thứ tự chữ cái trong node
            int viTri = 0;
            while (viTri < nodeChu.Nodes.Count && SoSanhViet.Compare(nodeChu.Nodes[viTri].Text, text) <= 0)
                viTri++;

            var nut = new TreeNode(text);
            nodeChu.Nodes.Insert(viTri, nut);

            nodeChu.Expand();
            tvDanhBa.SelectedNode = nut;
            nut.EnsureVisible();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        // ===== Exit (Esc cũng gọi nút này) =====
        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng form: nút X, Alt+F4, Exit, Esc =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
