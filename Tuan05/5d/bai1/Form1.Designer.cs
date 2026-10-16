namespace bai1
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
            components = new System.ComponentModel.Container();
            SuspendLayout();

            // ----- các bảng bố cục -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 46F, 40F, 14F });
            tlpNhap = TaoBang("tlpNhap", new[] { 24F, 76F }, new[] { 20F, 20F, 20F, 20F, 20F });
            tlpGioiTinh = TaoBang("tlpGioiTinh", new[] { 50F, 50F }, new[] { 100F });
            tlpNgoaiNgu = TaoBang("tlpNgoaiNgu", new[] { 33F, 33F, 34F }, new[] { 100F });
            tlpNut = TaoBang("tlpNut", new[] { 33F, 33F, 34F }, new[] { 100F });

            // ----- khởi tạo control -----
            lblHoTen = new Label(); lblMaSV = new Label(); lblGioiTinh = new Label();
            lblNgoaiNgu = new Label(); lblDanToc = new Label();
            txtHoTen = new TextBox(); txtMaSV = new TextBox();
            radNam = new RadioButton(); radNu = new RadioButton();
            chkAnh = new CheckBox(); chkPhap = new CheckBox(); chkHoa = new CheckBox();
            cboDanToc = new ComboBox();
            lvSV = new ListView();
            btnThem = new Button(); btnXoa = new Button(); btnSua = new Button();
            ctxLv = new ContextMenuStrip(components);
            tsmXoa = new ToolStripMenuItem();

            // ----- nhãn -----
            Nhan(lblHoTen, "lblHoTen", "Họ và Tên");
            Nhan(lblMaSV, "lblMaSV", "Mã sinh viên");
            Nhan(lblGioiTinh, "lblGioiTinh", "Giới tính");
            Nhan(lblNgoaiNgu, "lblNgoaiNgu", "Ngoại ngữ");
            Nhan(lblDanToc, "lblDanToc", "Dân tộc");

            // ----- ô nhập -----
            NhapChu(txtHoTen, "txtHoTen", 50);
            NhapChu(txtMaSV, "txtMaSV", 15);

            // ----- giới tính (radio, bảng riêng để tạo một nhóm) -----
            Radio(radNam, "radNam", "Nam");
            Radio(radNu, "radNu", "Nữ");
            radNam.Checked = true;
            tlpGioiTinh.Controls.Add(radNam, 0, 0);
            tlpGioiTinh.Controls.Add(radNu, 1, 0);

            // ----- ngoại ngữ (checkbox) -----
            Check(chkAnh, "chkAnh", "Anh");
            Check(chkPhap, "chkPhap", "Pháp");
            Check(chkHoa, "chkHoa", "Hoa");
            tlpNgoaiNgu.Controls.Add(chkAnh, 0, 0);
            tlpNgoaiNgu.Controls.Add(chkPhap, 1, 0);
            tlpNgoaiNgu.Controls.Add(chkHoa, 2, 0);

            // ----- dân tộc -----
            cboDanToc.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDanToc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanToc.FormattingEnabled = true;
            cboDanToc.Margin = new Padding(6, 4, 6, 4);
            cboDanToc.Name = "cboDanToc";

            // ----- ghép khối nhập -----
            tlpNhap.Controls.Add(lblHoTen, 0, 0);
            tlpNhap.Controls.Add(txtHoTen, 1, 0);
            tlpNhap.Controls.Add(lblMaSV, 0, 1);
            tlpNhap.Controls.Add(txtMaSV, 1, 1);
            tlpNhap.Controls.Add(lblGioiTinh, 0, 2);
            tlpNhap.Controls.Add(tlpGioiTinh, 1, 2);
            tlpNhap.Controls.Add(lblNgoaiNgu, 0, 3);
            tlpNhap.Controls.Add(tlpNgoaiNgu, 1, 3);
            tlpNhap.Controls.Add(lblDanToc, 0, 4);
            tlpNhap.Controls.Add(cboDanToc, 1, 4);

            // ----- ListView -----
            lvSV.Columns.Add("Họ tên", 150);
            lvSV.Columns.Add("Mã sinh viên", 110);
            lvSV.Columns.Add("Giới tính", 80);
            lvSV.Columns.Add("Ngoại ngữ", 130);
            lvSV.Columns.Add("Dân tộc", 90);
            lvSV.ContextMenuStrip = ctxLv;
            lvSV.Dock = DockStyle.Fill;
            lvSV.FullRowSelect = true;
            lvSV.GridLines = true;
            lvSV.HideSelection = false;
            lvSV.Margin = new Padding(6);
            lvSV.MultiSelect = true;
            lvSV.Name = "lvSV";
            lvSV.UseCompatibleStateImageBehavior = false;
            lvSV.View = View.Details;
            lvSV.SelectedIndexChanged += lvSV_SelectedIndexChanged;
            lvSV.MouseDown += lvSV_MouseDown;
            lvSV.Resize += (s, e) => CanCotListView();

            // ----- ContextMenuStrip (chuột phải vào ListView) -----
            tsmXoa.Name = "tsmXoa";
            tsmXoa.Text = "Xóa";
            tsmXoa.Click += tsmXoa_Click;
            ctxLv.Items.Add(tsmXoa);
            ctxLv.Name = "ctxLv";
            ctxLv.Opening += ctxLv_Opening;

            // ----- nút -----
            Nut(btnThem, "btnThem", "Thêm");
            Nut(btnXoa, "btnXoa", "Xóa");
            Nut(btnSua, "btnSua", "Sửa");
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            tlpNut.Controls.Add(btnThem, 0, 0);
            tlpNut.Controls.Add(btnXoa, 1, 0);
            tlpNut.Controls.Add(btnSua, 2, 0);

            // ----- bảng gốc -----
            tableLayoutPanel1.Controls.Add(tlpNhap, 0, 0);
            tableLayoutPanel1.Controls.Add(lvSV, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpNut, 0, 2);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 560);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(638, 607);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBaitap1";
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
            l.Margin = new Padding(6, 3, 3, 3);
            l.Name = ten;
            l.Text = chu;
        }

        private void NhapChu(TextBox t, string ten, int toiDa)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.MaxLength = toiDa;
            t.Name = ten;
            t.TextChanged += txt_TextChanged;
        }

        private static void Radio(RadioButton r, string ten, string chu)
        {
            r.Anchor = AnchorStyles.Left;
            r.AutoSize = true;
            r.Name = ten;
            r.Text = chu;
            r.UseVisualStyleBackColor = true;
        }

        private static void Check(CheckBox c, string ten, string chu)
        {
            c.Anchor = AnchorStyles.Left;
            c.AutoSize = true;
            c.Name = ten;
            c.Text = chu;
            c.UseVisualStyleBackColor = true;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(24, 8, 24, 8);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpNhap;
        private TableLayoutPanel tlpGioiTinh;
        private TableLayoutPanel tlpNgoaiNgu;
        private TableLayoutPanel tlpNut;

        private Label lblHoTen;
        private Label lblMaSV;
        private Label lblGioiTinh;
        private Label lblNgoaiNgu;
        private Label lblDanToc;
        private TextBox txtHoTen;
        private TextBox txtMaSV;
        private RadioButton radNam;
        private RadioButton radNu;
        private CheckBox chkAnh;
        private CheckBox chkPhap;
        private CheckBox chkHoa;
        private ComboBox cboDanToc;

        private ListView lvSV;
        private ContextMenuStrip ctxLv;
        private ToolStripMenuItem tsmXoa;

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
    }
}