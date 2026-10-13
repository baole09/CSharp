namespace btvn1
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

            // ----- bảng bố cục chính -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 90F, 10F });

            // ----- TabControl và hai trang -----
            tabChinh = new TabControl();
            tabAnhViet = new TabPage();
            tabVietAnh = new TabPage();

            tlpAnhViet = TaoBang("tlpAnhViet", new[] { 50F, 50F }, new[] { 11F, 12F, 77F });
            tlpVietAnh = TaoBang("tlpVietAnh", new[] { 50F, 50F }, new[] { 11F, 12F, 77F });

            lblAnh = new Label(); lblNghiaViet = new Label();
            cboAnh = new ComboBox(); lstAnh = new ListBox(); txtNghiaViet = new TextBox();

            lblViet = new Label(); lblNghiaAnh = new Label();
            cboViet = new ComboBox(); lstViet = new ListBox(); txtNghiaAnh = new TextBox();

            btnThoat = new Button();

            // Trang Anh - Việt
            tabAnhViet.Name = "tabAnhViet";
            tabAnhViet.Text = "ANH - VIỆT";
            tabAnhViet.UseVisualStyleBackColor = true;
            LapTrang(tabAnhViet, tlpAnhViet, lblAnh, lblNghiaViet, cboAnh, lstAnh, txtNghiaViet,
                     "Tiếng Anh", "Tiếng Việt", "Anh", "NghiaViet");
            cboAnh.TextChanged += cboAnh_TextChanged;
            lstAnh.MouseDoubleClick += lstAnh_MouseDoubleClick;

            // Trang Việt - Anh
            tabVietAnh.Name = "tabVietAnh";
            tabVietAnh.Text = "VIỆT - ANH";
            tabVietAnh.UseVisualStyleBackColor = true;
            LapTrang(tabVietAnh, tlpVietAnh, lblViet, lblNghiaAnh, cboViet, lstViet, txtNghiaAnh,
                     "Tiếng Việt", "Tiếng Anh", "Viet", "NghiaAnh");
            cboViet.TextChanged += cboViet_TextChanged;
            lstViet.MouseDoubleClick += lstViet_MouseDoubleClick;

            tabChinh.Controls.Add(tabAnhViet);
            tabChinh.Controls.Add(tabVietAnh);
            tabChinh.Dock = DockStyle.Fill;
            tabChinh.Margin = new Padding(6);
            tabChinh.Name = "tabChinh";

            // ----- nút Thoát -----
            btnThoat.Anchor = AnchorStyles.Right;
            btnThoat.Margin = new Padding(6);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 34);
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;

            tableLayoutPanel1.Controls.Add(tabChinh, 0, 0);
            tableLayoutPanel1.Controls.Add(btnThoat, 0, 1);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;         // Esc = Thoát
            ClientSize = new Size(560, 420);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(578, 467);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
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

        // Dựng một trang từ điển: cột trái (nhãn, combobox, danh sách từ), cột phải (nhãn, ô nghĩa)
        private static void LapTrang(TabPage trang, TableLayoutPanel tlp,
                                     Label lblTrai, Label lblPhai,
                                     ComboBox cbo, ListBox lst, TextBox txtNghia,
                                     string chuTrai, string chuPhai, string hauTo, string hauToNghia)
        {
            lblTrai.Anchor = AnchorStyles.Left;
            lblTrai.AutoSize = true;
            lblTrai.Margin = new Padding(6, 3, 3, 3);
            lblTrai.Name = "lbl" + hauTo;
            lblTrai.Text = chuTrai;

            lblPhai.Anchor = AnchorStyles.Left;
            lblPhai.AutoSize = true;
            lblPhai.Margin = new Padding(6, 3, 3, 3);
            lblPhai.Name = "lbl" + hauToNghia;
            lblPhai.Text = chuPhai;

            // Ô gõ từ cần tra: tự hoàn thành theo các từ có trong danh sách
            cbo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            cbo.FormattingEnabled = true;
            cbo.Margin = new Padding(6, 4, 6, 4);
            cbo.MaxLength = 50;
            cbo.Name = "cbo" + hauTo;

            lst.Dock = DockStyle.Fill;
            lst.FormattingEnabled = true;
            lst.IntegralHeight = false;
            lst.Margin = new Padding(6);
            lst.Name = "lst" + hauTo;

            txtNghia.BackColor = Color.White;
            txtNghia.Dock = DockStyle.Fill;
            txtNghia.Margin = new Padding(6);
            txtNghia.Multiline = true;
            txtNghia.Name = "txt" + hauToNghia;
            txtNghia.ReadOnly = true;
            txtNghia.ScrollBars = ScrollBars.Vertical;
            txtNghia.TabStop = false;

            tlp.Controls.Add(lblTrai, 0, 0);
            tlp.Controls.Add(cbo, 0, 1);
            tlp.Controls.Add(lst, 0, 2);
            tlp.Controls.Add(lblPhai, 1, 0);
            tlp.Controls.Add(txtNghia, 1, 1);
            tlp.SetRowSpan(txtNghia, 2);
            tlp.Padding = new Padding(8);

            trang.Controls.Add(tlp);
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabChinh;
        private TabPage tabAnhViet;
        private TabPage tabVietAnh;
        private TableLayoutPanel tlpAnhViet;
        private TableLayoutPanel tlpVietAnh;

        private Label lblAnh;
        private Label lblNghiaViet;
        private ComboBox cboAnh;
        private ListBox lstAnh;
        private TextBox txtNghiaViet;

        private Label lblViet;
        private Label lblNghiaAnh;
        private ComboBox cboViet;
        private ListBox lstViet;
        private TextBox txtNghiaAnh;

        private Button btnThoat;
    }
}