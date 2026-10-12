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
            SuspendLayout();

            // ----- các bảng bố cục -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 42F, 58F }, new[] { 100F });
            tlpTrai = TaoBang("tlpTrai", new[] { 100F }, new[] { 70F, 30F });
            tlpNhap = TaoBang("tlpNhap", new[] { 62F, 38F }, new[] { 45F, 55F });
            tlpPhai = TaoBang("tlpPhai", new[] { 100F }, new[] { 50F, 17F, 17F, 16F });

            // ----- khởi tạo control -----
            grpNhap = new GroupBox(); grpUoc = new GroupBox();
            txtSo = new TextBox(); cboSo = new ComboBox(); lstUoc = new ListBox();
            btnCapNhat = new Button(); btnThoat = new Button();
            btnTongUoc = new Button(); btnUocChan = new Button(); btnUocNguyenTo = new Button();

            // ----- nhóm Nhập Số -----
            grpNhap.Dock = DockStyle.Fill;
            grpNhap.Margin = new Padding(6);
            grpNhap.Name = "grpNhap";
            grpNhap.TabStop = false;
            grpNhap.Text = "Nhập Số";

            txtSo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSo.BorderStyle = BorderStyle.None;
            txtSo.Margin = new Padding(6, 4, 6, 4);
            txtSo.MaxLength = 9;
            txtSo.Name = "txtSo";
            txtSo.KeyPress += txtSo_KeyPress;
            txtSo.TextChanged += txtSo_TextChanged;
            txtSo.Validating += txtSo_Validating;

            cboSo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSo.FormattingEnabled = true;
            cboSo.Margin = new Padding(6, 4, 6, 4);
            cboSo.Name = "cboSo";
            cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;

            // ----- nhóm Danh sách các ước số -----
            grpUoc.Dock = DockStyle.Fill;
            grpUoc.Margin = new Padding(6);
            grpUoc.Name = "grpUoc";
            grpUoc.TabStop = false;
            grpUoc.Text = "Danh sách các ước số";

            lstUoc.Dock = DockStyle.Fill;
            lstUoc.FormattingEnabled = true;
            lstUoc.Name = "lstUoc";

            // ----- nút (có HotKey bằng ký tự &) -----
            Nut(btnCapNhat, "btnCapNhat", "&Cập nhật");
            Nut(btnThoat, "btnThoat", "Th&oát");
            Nut(btnTongUoc, "btnTongUoc", "&Tổng các ước số");
            Nut(btnUocChan, "btnUocChan", "Số lượng các ước số c&hẵn");
            Nut(btnUocNguyenTo, "btnUocNguyenTo", "Số lượng các ước số &nguyên tố");
            btnCapNhat.Click += btnCapNhat_Click;
            btnThoat.Click += btnThoat_Click;
            btnTongUoc.Click += btnTongUoc_Click;
            btnUocChan.Click += btnUocChan_Click;
            btnUocNguyenTo.Click += btnUocNguyenTo_Click;

            // ----- ghép bên trái -----
            tlpNhap.Controls.Add(txtSo, 0, 0);
            tlpNhap.Controls.Add(btnCapNhat, 1, 0);
            tlpNhap.Controls.Add(cboSo, 0, 1);
            tlpNhap.SetColumnSpan(cboSo, 2);
            grpNhap.Controls.Add(tlpNhap);

            tlpTrai.Controls.Add(grpNhap, 0, 0);
            tlpTrai.Controls.Add(btnThoat, 0, 1);

            // ----- ghép bên phải -----
            grpUoc.Controls.Add(lstUoc);
            tlpPhai.Controls.Add(grpUoc, 0, 0);
            tlpPhai.Controls.Add(btnTongUoc, 0, 1);
            tlpPhai.Controls.Add(btnUocChan, 0, 2);
            tlpPhai.Controls.Add(btnUocNguyenTo, 0, 3);

            // ----- bảng gốc -----
            tableLayoutPanel1.Controls.Add(tlpTrai, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpPhai, 1, 0);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnCapNhat;       // Enter = Cập nhật
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;         // Esc = Thoát
            ClientSize = new Size(640, 360);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(658, 407);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Combobox";
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

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(6);
            b.Name = ten;
            b.Text = chu;
            b.UseMnemonic = true;
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpTrai;
        private TableLayoutPanel tlpNhap;
        private TableLayoutPanel tlpPhai;

        private GroupBox grpNhap;
        private GroupBox grpUoc;

        private TextBox txtSo;
        private ComboBox cboSo;
        private ListBox lstUoc;

        private Button btnCapNhat;
        private Button btnThoat;
        private Button btnTongUoc;
        private Button btnUocChan;
        private Button btnUocNguyenTo;
    }
}