namespace bai2
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

            // ----- các bảng bố cục -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 33F, 67F }, new[] { 100F });
            tlpPhai = TaoBang("tlpPhai", new[] { 100F }, new[] { 11F, 44F, 9F, 24F, 12F });
            tlpChon = TaoBang("tlpChon", new[] { 24F, 76F }, new[] { 100F });
            tlpSV = TaoBang("tlpSV", new[] { 26F, 74F }, new[] { 24F, 24F, 24F, 28F });
            tlpNutSV = TaoBang("tlpNutSV", new[] { 50F, 50F }, new[] { 100F });
            tlpLop = TaoBang("tlpLop", new[] { 22F, 46F, 32F }, new[] { 100F });

            // ----- khởi tạo control -----
            tvLop = new TreeView();
            lblChonLop = new Label(); lblMaSV = new Label(); lblHoTen = new Label();
            lblDiaChi = new Label(); lblTenLop = new Label();
            cboLop = new ComboBox();
            txtMaSV = new TextBox(); txtHoTen = new TextBox(); txtDiaChi = new TextBox();
            txtTenLop = new TextBox();
            grpSinhVien = new GroupBox(); grpThongTinLop = new GroupBox();
            chkThemLop = new CheckBox();
            btnCapNhat = new Button(); btnXoa = new Button(); btnThemLop = new Button();

            // ----- TreeView -----
            tvLop.Dock = DockStyle.Fill;
            tvLop.HideSelection = false;
            tvLop.Margin = new Padding(6);
            tvLop.Name = "tvLop";
            tvLop.AfterSelect += tvLop_AfterSelect;

            // ----- Chọn lớp -----
            Nhan(lblChonLop, "lblChonLop", "Chọn Lớp");
            cboLop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Margin = new Padding(6, 4, 6, 4);
            cboLop.Name = "cboLop";

            // ----- Thông tin sinh viên -----
            Nhom(grpSinhVien, "grpSinhVien", "Thông tin sinh viên");
            Nhan(lblMaSV, "lblMaSV", "Mã SV:");
            Nhan(lblHoTen, "lblHoTen", "Họ Tên:");
            Nhan(lblDiaChi, "lblDiaChi", "Địa Chỉ");
            NhapChu(txtMaSV, "txtMaSV");
            NhapChu(txtHoTen, "txtHoTen");
            NhapChu(txtDiaChi, "txtDiaChi");

            Nut(btnCapNhat, "btnCapNhat", "Cập Nhật");
            Nut(btnXoa, "btnXoa", "Xóa");
            btnCapNhat.Click += btnCapNhat_Click;
            btnXoa.Click += btnXoa_Click;

            // ----- Thêm lớp -----
            chkThemLop.Anchor = AnchorStyles.Left;
            chkThemLop.AutoSize = true;
            chkThemLop.Margin = new Padding(6, 3, 3, 3);
            chkThemLop.Name = "chkThemLop";
            chkThemLop.Text = "Thêm lớp";
            chkThemLop.UseVisualStyleBackColor = true;
            chkThemLop.CheckedChanged += chkThemLop_CheckedChanged;

            Nhom(grpThongTinLop, "grpThongTinLop", "Thông tin lớp");
            Nhan(lblTenLop, "lblTenLop", "Tên lớp");
            NhapChu(txtTenLop, "txtTenLop");
            Nut(btnThemLop, "btnThemLop", "Thêm lớp");
            btnThemLop.Click += btnThemLop_Click;

            // ----- ghép -----
            tlpChon.Controls.Add(lblChonLop, 0, 0);
            tlpChon.Controls.Add(cboLop, 1, 0);

            tlpNutSV.Controls.Add(btnCapNhat, 0, 0);
            tlpNutSV.Controls.Add(btnXoa, 1, 0);

            tlpSV.Controls.Add(lblMaSV, 0, 0);
            tlpSV.Controls.Add(txtMaSV, 1, 0);
            tlpSV.Controls.Add(lblHoTen, 0, 1);
            tlpSV.Controls.Add(txtHoTen, 1, 1);
            tlpSV.Controls.Add(lblDiaChi, 0, 2);
            tlpSV.Controls.Add(txtDiaChi, 1, 2);
            tlpSV.Controls.Add(tlpNutSV, 0, 3);
            tlpSV.SetColumnSpan(tlpNutSV, 2);
            grpSinhVien.Controls.Add(tlpSV);

            tlpLop.Controls.Add(lblTenLop, 0, 0);
            tlpLop.Controls.Add(txtTenLop, 1, 0);
            tlpLop.Controls.Add(btnThemLop, 2, 0);
            grpThongTinLop.Controls.Add(tlpLop);

            tlpPhai.Controls.Add(tlpChon, 0, 0);
            tlpPhai.Controls.Add(grpSinhVien, 0, 1);
            tlpPhai.Controls.Add(chkThemLop, 0, 2);
            tlpPhai.Controls.Add(grpThongTinLop, 0, 3);

            tableLayoutPanel1.Controls.Add(tvLop, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpPhai, 1, 0);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 440);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(718, 487);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên";
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

        private static void Nhan(Label l, string ten, string chu)
        {
            l.Anchor = AnchorStyles.Left;
            l.AutoSize = true;
            l.Name = ten;
            l.Text = chu;
        }

        private static void Nhom(GroupBox g, string ten, string chu)
        {
            g.Dock = DockStyle.Fill;
            g.Margin = new Padding(6);
            g.Name = ten;
            g.TabStop = false;
            g.Text = chu;
        }

        private void NhapChu(TextBox t, string ten)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.Name = ten;
            t.TextChanged += txt_TextChanged;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(6, 6, 6, 6);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpPhai;
        private TableLayoutPanel tlpChon;
        private TableLayoutPanel tlpSV;
        private TableLayoutPanel tlpNutSV;
        private TableLayoutPanel tlpLop;

        private TreeView tvLop;
        private Label lblChonLop;
        private Label lblMaSV;
        private Label lblHoTen;
        private Label lblDiaChi;
        private Label lblTenLop;
        private ComboBox cboLop;
        private TextBox txtMaSV;
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private TextBox txtTenLop;
        private GroupBox grpSinhVien;
        private GroupBox grpThongTinLop;
        private CheckBox chkThemLop;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnThemLop;
    }
}