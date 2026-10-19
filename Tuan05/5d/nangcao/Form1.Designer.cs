namespace nangcao
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();

            // ----- khởi tạo control -----
            menuChinh = new MenuStrip();
            mnuCapNhat = new ToolStripMenuItem();
            mnuNhapMoi = new ToolStripMenuItem();
            mnuChuyenB = new ToolStripMenuItem();
            mnuChuyenA = new ToolStripMenuItem();
            mnuXoa = new ToolStripMenuItem();
            mnuKetThuc = new ToolStripMenuItem();

            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 50F, 50F }, new[] { 100F });
            grpLopA = new GroupBox(); grpLopB = new GroupBox();
            lstLopA = new ListBox(); lstLopB = new ListBox();

            // ----- menu (chữ sau & là phím nóng, nhấn Alt + chữ đó) -----
            var dam = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

            mnuNhapMoi.Font = dam;
            mnuNhapMoi.Name = "mnuNhapMoi";
            mnuNhapMoi.Text = "&Nhập học viên mới";
            mnuNhapMoi.Click += mnuNhapMoi_Click;

            mnuChuyenB.Font = dam;
            mnuChuyenB.Name = "mnuChuyenB";
            mnuChuyenB.Text = "Chuyển sang lớp &B";
            mnuChuyenB.Click += mnuChuyenB_Click;

            mnuChuyenA.Font = dam;
            mnuChuyenA.Name = "mnuChuyenA";
            mnuChuyenA.Text = "Chuyển sang lớp &A";
            mnuChuyenA.Click += mnuChuyenA_Click;

            mnuXoa.Font = dam;
            mnuXoa.Name = "mnuXoa";
            mnuXoa.Text = "&Xóa học viên";
            mnuXoa.Click += mnuXoa_Click;

            mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] { mnuNhapMoi, mnuChuyenB, mnuChuyenA, mnuXoa });
            mnuCapNhat.Font = dam;
            mnuCapNhat.Name = "mnuCapNhat";
            mnuCapNhat.Text = "&Cập nhật";

            mnuKetThuc.Font = dam;
            mnuKetThuc.Name = "mnuKetThuc";
            mnuKetThuc.Text = "&Kết thúc";
            mnuKetThuc.Click += mnuKetThuc_Click;

            menuChinh.Dock = DockStyle.Top;
            menuChinh.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });
            menuChinh.Name = "menuChinh";

            // ----- hai danh sách lớp (cho chọn nhiều mục) -----
            Nhom(grpLopA, "grpLopA", "Lớp A");
            Nhom(grpLopB, "grpLopB", "Lớp B");
            DanhSach(lstLopA, "lstLopA");
            DanhSach(lstLopB, "lstLopB");

            grpLopA.Controls.Add(lstLopA);
            grpLopB.Controls.Add(lstLopB);
            tableLayoutPanel1.Controls.Add(grpLopA, 0, 0);
            tableLayoutPanel1.Controls.Add(grpLopB, 1, 0);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 12);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 380);
            Controls.Add(tableLayoutPanel1);   // thêm bảng trước, menu sau để menu nằm sát mép trên
            Controls.Add(menuChinh);
            MainMenuStrip = menuChinh;
            MinimumSize = new Size(438, 307);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý học viên";
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        // ===== Hàm phụ dựng giao diện =====
        private static TableLayoutPanel TaoBang(string ten, float[] cot, float[] hang)
        {
            var t = new TableLayoutPanel
            {
                Name = ten,
                Dock = DockStyle.Fill,
                ColumnCount = cot.Length,
                RowCount = hang.Length
            };
            foreach (float c in cot) t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, c));
            foreach (float h in hang) t.RowStyles.Add(new RowStyle(SizeType.Percent, h));
            return t;
        }

        private static void Nhom(GroupBox g, string ten, string chu)
        {
            g.Dock = DockStyle.Fill;
            g.Margin = new Padding(6);
            g.Name = ten;
            g.TabStop = false;
            g.Text = chu;
        }

        private static void DanhSach(ListBox l, string ten)
        {
            l.Dock = DockStyle.Fill;
            l.FormattingEnabled = true;
            l.IntegralHeight = false;
            l.Name = ten;
            l.SelectionMode = SelectionMode.MultiExtended;
        }

        private MenuStrip menuChinh;
        private ToolStripMenuItem mnuCapNhat;
        private ToolStripMenuItem mnuNhapMoi;
        private ToolStripMenuItem mnuChuyenB;
        private ToolStripMenuItem mnuChuyenA;
        private ToolStripMenuItem mnuXoa;
        private ToolStripMenuItem mnuKetThuc;

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox grpLopA;
        private GroupBox grpLopB;
        private ListBox lstLopA;
        private ListBox lstLopB;
    }
}