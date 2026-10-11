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

            // ----- các bảng bố cục -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 10F, 19F, 35F, 11F, 20F, 5F });
            tlpThongTin = TaoBang("tlpThongTin", new[] { 32F, 68F }, new[] { 33F, 33F, 34F });
            tlpNhom = TaoBang("tlpNhom", new[] { 50F, 50F }, new[] { 100F });
            tlpNuoc = TaoBang("tlpNuoc", new[] { 50F, 50F }, new[] { 33F, 33F, 34F });
            tlpThucAn = TaoBang("tlpThucAn", new[] { 50F, 50F }, new[] { 33F, 33F, 34F });
            tlpNut = TaoBang("tlpNut", new[] { 25F, 25F, 25F, 25F }, new[] { 100F });
            tlpTong = TaoBang("tlpTong", new[] { 38F, 62F }, new[] { 50F, 50F });

            // ----- khởi tạo control -----
            lblTieuDe = new Label(); lblTen = new Label(); lblSoKhach = new Label();
            lblTongKhach = new Label(); lblTongTien = new Label();
            txtTen = new TextBox(); txtSoKhach = new TextBox();
            txtTongKhach = new TextBox(); txtTongTien = new TextBox();
            chkSinhVien = new CheckBox();
            grpNuoc = new GroupBox(); grpThucAn = new GroupBox();

            radioButton_cafeden = new RadioButton(); radioButton_cafeda = new RadioButton();
            radioButton_cafesua = new RadioButton(); radioButton_cafekem = new RadioButton();
            radioButton_cafesuada = new RadioButton();

            chkBanhMyTrung = new CheckBox(); chkMyXaoBo = new CheckBox(); chkBanhMyCa = new CheckBox();
            chkMyCay = new CheckBox(); chkMyTomTrung = new CheckBox();

            btnTinhTien = new Button(); btnNhapLai = new Button();
            btnThanhToan = new Button(); btnThoat = new Button();

            // ----- tiêu đề -----
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.Chocolate;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "CAFE SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nhãn -----
            NhanDam(lblTen, "lblTen", "Tên khách hàng");
            NhanDam(lblSoKhach, "lblSoKhach", "Số khách hàng");
            NhanDam(lblTongKhach, "lblTongKhach", "Tổng khách hàng");
            NhanDam(lblTongTien, "lblTongTien", "Tổng tiền thanh toán");

            // ----- ô nhập thông tin -----
            txtTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTen.BorderStyle = BorderStyle.None;
            txtTen.Margin = new Padding(6, 4, 6, 4);
            txtTen.MaxLength = 50;
            txtTen.Name = "txtTen";
            txtTen.TextChanged += Nhap_TextChanged;
            txtTen.Validating += txtTen_Validating;

            txtSoKhach.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSoKhach.BorderStyle = BorderStyle.None;
            txtSoKhach.Margin = new Padding(6, 4, 6, 4);
            txtSoKhach.MaxLength = 4;
            txtSoKhach.Name = "txtSoKhach";
            txtSoKhach.KeyPress += txtSoKhach_KeyPress;
            txtSoKhach.TextChanged += Nhap_TextChanged;
            txtSoKhach.Validating += txtSoKhach_Validating;

            chkSinhVien.Anchor = AnchorStyles.Left;
            chkSinhVien.AutoSize = true;
            chkSinhVien.Margin = new Padding(6, 3, 3, 3);
            chkSinhVien.Name = "chkSinhVien";
            chkSinhVien.Text = "Sinh viên ?";
            chkSinhVien.UseVisualStyleBackColor = true;
            chkSinhVien.CheckedChanged += DuLieuThayDoi;

            // ----- nhóm Nước uống (radio, giá lưu trong Tag) -----
            grpNuoc.Dock = DockStyle.Fill;
            grpNuoc.Margin = new Padding(6);
            grpNuoc.Name = "grpNuoc";
            grpNuoc.TabStop = false;
            grpNuoc.Text = "Nước uống";

            Radio(radioButton_cafeden, "radioButton_cafeden", "Cafe đen", 20000m);
            Radio(radioButton_cafeda, "radioButton_cafeda", "Cafe đá", 25000m);
            Radio(radioButton_cafesua, "radioButton_cafesua", "Cafe sữa", 25000m);
            Radio(radioButton_cafekem, "radioButton_cafekem", "Cafe kem", 35000m);
            Radio(radioButton_cafesuada, "radioButton_cafesuada", "Cafe sữa đá", 30000m);

            // ----- nhóm Thức ăn (checkbox, giá lưu trong Tag) -----
            grpThucAn.Dock = DockStyle.Fill;
            grpThucAn.Margin = new Padding(6);
            grpThucAn.Name = "grpThucAn";
            grpThucAn.TabStop = false;
            grpThucAn.Text = "Thức ăn";

            Check(chkBanhMyTrung, "chkBanhMyTrung", "Bánh mỳ trứng", 15000m);
            Check(chkMyXaoBo, "chkMyXaoBo", "Mỳ xào bò", 30000m);
            Check(chkBanhMyCa, "chkBanhMyCa", "Bánh mỳ cá", 15000m);
            Check(chkMyCay, "chkMyCay", "Mỳ cay", 50000m);
            Check(chkMyTomTrung, "chkMyTomTrung", "Mỳ tôm trứng", 20000m);

            // ----- nút -----
            Nut(btnTinhTien, "btnTinhTien", "Tính tiền");
            Nut(btnNhapLai, "btnNhapLai", "Nhập lại");
            Nut(btnThanhToan, "btnThanhToan", "Thanh toán");
            Nut(btnThoat, "btnThoat", "Thoát");
            btnTinhTien.Click += btnTinhTien_Click;
            btnNhapLai.Click += btnNhapLai_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnThoat.Click += btnThoat_Click;

            // ----- ô tổng (chỉ đọc) -----
            XuatKq(txtTongKhach, "txtTongKhach");
            XuatKq(txtTongTien, "txtTongTien");

            // ----- ghép vào bảng -----
            tlpThongTin.Controls.Add(lblTen, 0, 0);
            tlpThongTin.Controls.Add(txtTen, 1, 0);
            tlpThongTin.Controls.Add(lblSoKhach, 0, 1);
            tlpThongTin.Controls.Add(txtSoKhach, 1, 1);
            tlpThongTin.Controls.Add(chkSinhVien, 1, 2);

            tlpNuoc.Controls.Add(radioButton_cafeden, 0, 0);
            tlpNuoc.Controls.Add(radioButton_cafeda, 1, 0);
            tlpNuoc.Controls.Add(radioButton_cafesua, 0, 1);
            tlpNuoc.Controls.Add(radioButton_cafekem, 1, 1);
            tlpNuoc.Controls.Add(radioButton_cafesuada, 0, 2);
            grpNuoc.Controls.Add(tlpNuoc);

            tlpThucAn.Controls.Add(chkBanhMyTrung, 0, 0);
            tlpThucAn.Controls.Add(chkMyXaoBo, 1, 0);
            tlpThucAn.Controls.Add(chkBanhMyCa, 0, 1);
            tlpThucAn.Controls.Add(chkMyCay, 1, 1);
            tlpThucAn.Controls.Add(chkMyTomTrung, 0, 2);
            grpThucAn.Controls.Add(tlpThucAn);

            tlpNhom.Controls.Add(grpNuoc, 0, 0);
            tlpNhom.Controls.Add(grpThucAn, 1, 0);

            tlpNut.Controls.Add(btnTinhTien, 0, 0);
            tlpNut.Controls.Add(btnNhapLai, 1, 0);
            tlpNut.Controls.Add(btnThanhToan, 2, 0);
            tlpNut.Controls.Add(btnThoat, 3, 0);

            tlpTong.Controls.Add(lblTongKhach, 0, 0);
            tlpTong.Controls.Add(txtTongKhach, 1, 0);
            tlpTong.Controls.Add(lblTongTien, 0, 1);
            tlpTong.Controls.Add(txtTongTien, 1, 1);

            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpThongTin, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpNhom, 0, 2);
            tableLayoutPanel1.Controls.Add(tlpNut, 0, 3);
            tableLayoutPanel1.Controls.Add(tlpTong, 0, 4);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnTinhTien;      // Enter = Tính tiền
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;         // Esc = Thoát
            ClientSize = new Size(600, 620);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(618, 667);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh toán tiền";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
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

        private static void NhanDam(Label l, string ten, string chu)
        {
            l.Anchor = AnchorStyles.Left;
            l.AutoSize = true;
            l.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            l.Name = ten;
            l.Text = chu;
        }

        private void Radio(RadioButton r, string ten, string chu, decimal gia)
        {
            r.Anchor = AnchorStyles.Left;
            r.AutoSize = true;
            r.Name = ten;
            r.Tag = gia;
            r.Text = chu;
            r.UseVisualStyleBackColor = true;
            r.CheckedChanged += DuLieuThayDoi;
        }

        private void Check(CheckBox c, string ten, string chu, decimal gia)
        {
            c.Anchor = AnchorStyles.Left;
            c.AutoSize = true;
            c.Name = ten;
            c.Tag = gia;
            c.Text = chu;
            c.UseVisualStyleBackColor = true;
            c.CheckedChanged += DuLieuThayDoi;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(6, 10, 6, 10);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private static void XuatKq(TextBox t, string ten)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.Name = ten;
            t.ReadOnly = true;
            t.TabStop = false;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpThongTin;
        private TableLayoutPanel tlpNhom;
        private TableLayoutPanel tlpNuoc;
        private TableLayoutPanel tlpThucAn;
        private TableLayoutPanel tlpNut;
        private TableLayoutPanel tlpTong;

        private Label lblTieuDe;
        private Label lblTen;
        private Label lblSoKhach;
        private Label lblTongKhach;
        private Label lblTongTien;

        private TextBox txtTen;
        private TextBox txtSoKhach;
        private TextBox txtTongKhach;
        private TextBox txtTongTien;

        private CheckBox chkSinhVien;
        private GroupBox grpNuoc;
        private GroupBox grpThucAn;

        private RadioButton radioButton_cafeden;
        private RadioButton radioButton_cafeda;
        private RadioButton radioButton_cafesua;
        private RadioButton radioButton_cafekem;
        private RadioButton radioButton_cafesuada;

        private CheckBox chkBanhMyTrung;
        private CheckBox chkMyXaoBo;
        private CheckBox chkBanhMyCa;
        private CheckBox chkMyCay;
        private CheckBox chkMyTomTrung;

        private Button btnTinhTien;
        private Button btnNhapLai;
        private Button btnThanhToan;
        private Button btnThoat;
    }
}