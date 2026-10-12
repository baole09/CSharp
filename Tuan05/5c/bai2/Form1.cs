namespace bai2
{
    public partial class Form1 : Form
    {
        // Thông tin một sinh viên, lưu trong Tag của node sinh viên trên TreeView
        private record SinhVien(string Ma, string HoTen, string DiaChi);

        private TreeNode _goc = null!;   // node gốc "Danh sách lớp"

        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: có sẵn vài lớp, checkbox Thêm lớp = false, nhóm Thông tin lớp ẩn =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            _goc = tvLop.Nodes.Add("Danh sách lớp");

            foreach (string lop in new[] { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" })
            {
                _goc.Nodes.Add(lop);
                cboLop.Items.Add(lop);
            }

            _goc.Expand();
            cboLop.SelectedIndex = 0;

            chkThemLop.Checked = false;
            grpThongTinLop.Visible = false;

            ActiveControl = txtMaSV;
        }

        // Enter: ô Tên lớp thì Thêm lớp, ô thông tin sinh viên thì Cập Nhật
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == txtTenLop)
                {
                    btnThemLop.PerformClick();
                    return true;
                }
                if (ActiveControl == txtMaSV || ActiveControl == txtHoTen || ActiveControl == txtDiaChi)
                {
                    btnCapNhat.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txt_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Tick Thêm lớp: hiện/ẩn nhóm Thông tin lớp =====
        private void chkThemLop_CheckedChanged(object? sender, EventArgs e)
        {
            grpThongTinLop.Visible = chkThemLop.Checked;
            if (chkThemLop.Checked)
                txtTenLop.Focus();
        }

        // ===== Tiện ích tìm trong TreeView =====
        private bool TonTaiLop(string ten) =>
            _goc.Nodes.Cast<TreeNode>().Any(n => string.Equals(n.Text, ten, StringComparison.OrdinalIgnoreCase));

        // Kiểm tra mã SV trên toàn bộ các lớp
        private bool TonTaiMaSV(string ma) =>
            _goc.Nodes.Cast<TreeNode>()
                .SelectMany(lop => lop.Nodes.Cast<TreeNode>())
                .Any(sv => sv.Tag is SinhVien s && string.Equals(s.Ma, ma, StringComparison.OrdinalIgnoreCase));

        // ===== Thêm lớp =====
        private void btnThemLop_Click(object? sender, EventArgs e)
        {
            string ten = txtTenLop.Text.Trim();
            string loi = "";

            if (ten.Length == 0)
                loi = "Tên lớp không được để trống.";
            else if (TonTaiLop(ten))
                loi = $"Lớp {ten} đã tồn tại.";

            if (loi.Length > 0)
            {
                DatLoi(txtTenLop, loi);
                MessageBox.Show(loi, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
                txtTenLop.SelectAll();
                return;
            }

            _goc.Nodes.Add(ten);       // thêm vào TreeView
            cboLop.Items.Add(ten);     // đồng thời thêm vào ComboBox
            if (cboLop.SelectedIndex < 0)
                cboLop.SelectedIndex = 0;

            _goc.Expand();
            txtTenLop.Clear();
            txtTenLop.Focus();
        }

        // ===== Cập Nhật: thêm sinh viên vào lớp đang chọn =====
        private void btnCapNhat_Click(object? sender, EventArgs e)
        {
            if (cboLop.SelectedItem is not string tenLop)
            {
                MessageBox.Show("Chưa có lớp nào được chọn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            var dsLoi = new List<string>();
            TextBox? dau = null;

            void Loi(TextBox t, string m)
            {
                DatLoi(t, m);
                dsLoi.Add(m);
                dau ??= t;
            }

            if (ma.Length == 0) Loi(txtMaSV, "Mã sinh viên không được để trống.");
            else if (TonTaiMaSV(ma)) Loi(txtMaSV, $"Mã sinh viên {ma} đã tồn tại.");

            if (hoTen.Length == 0) Loi(txtHoTen, "Họ tên không được để trống.");
            if (diaChi.Length == 0) Loi(txtDiaChi, "Địa chỉ không được để trống.");

            if (dsLoi.Count > 0)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dau?.Focus();
                return;
            }

            TreeNode lopNode = _goc.Nodes.Cast<TreeNode>().First(n => n.Text == tenLop);

            // Node sinh viên lưu đủ thông tin trong Tag; node con hiển thị địa chỉ
            var sv = new TreeNode($"{ma}, {hoTen}") { Tag = new SinhVien(ma, hoTen, diaChi) };
            sv.Nodes.Add(diaChi);
            lopNode.Nodes.Add(sv);

            lopNode.Expand();
            sv.Expand();

            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtMaSV.Focus();
        }

        // ===== Click chọn node sinh viên: hiện thông tin lên các textbox =====
        private void tvLop_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            // Chỉ xử lý node sinh viên (cấp 2, có Tag là SinhVien)
            if (e.Node is not { Level: 2, Tag: SinhVien sv }) return;

            // Chọn đúng lớp của sinh viên trên combobox
            if (e.Node.Parent != null)
                cboLop.SelectedItem = e.Node.Parent.Text;

            txtMaSV.Text = sv.Ma;
            txtHoTen.Text = sv.HoTen;
            txtDiaChi.Text = sv.DiaChi;

            DatLoi(txtMaSV, "");
            DatLoi(txtHoTen, "");
            DatLoi(txtDiaChi, "");
        }

        // ===== Xóa: chỉ cho phép xóa node sinh viên đang chọn (có xác nhận) =====
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            TreeNode? nut = tvLop.SelectedNode;

            if (nut is not { Level: 2, Tag: SinhVien })
            {
                MessageBox.Show("Chỉ được xóa node sinh viên. Hãy chọn một sinh viên trên TreeView.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kq = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {nut.Text}?", "Xác nhận xóa",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            nut.Remove();

            // Xóa thông tin sinh viên vừa bị xóa khỏi các ô nhập
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
        }
            // ===== Hỏi xác nhận trước khi đóng form (nút X, Alt+F4...) =====
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
