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

            // ----- các bảng bố cục (mỗi nhóm radio nằm trong bảng riêng) -----
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 8F, 12F, 12F, 20F, 24F, 24F });
            tlpTren = TaoBang("tlpTren", new[] { 24F, 52F, 24F }, new[] { 50F, 50F });
            tlpSapXep = TaoBang("tlpSapXep", new[] { 26F, 74F }, new[] { 100F });
            tlpNhomSapXep = TaoBang("tlpNhomSapXep", new[] { 50F, 50F }, new[] { 40F, 60F });
            tlpGiua = TaoBang("tlpGiua", new[] { 50F, 50F }, new[] { 100F });
            tlpTim = TaoBang("tlpTim", new[] { 62F, 38F }, new[] { 25F, 25F, 25F, 25F });
            tlpXoa = TaoBang("tlpXoa", new[] { 62F, 38F }, new[] { 25F, 25F, 25F, 25F });
            tlpDuoi1 = TaoBang("tlpDuoi1", new[] { 50F, 50F }, new[] { 100F });
            tlpThem = TaoBang("tlpThem", new[] { 62F, 38F }, new[] { 25F, 25F, 25F, 25F });
            tlpTong = TaoBang("tlpTong", new[] { 38F, 28F, 34F }, new[] { 25F, 25F, 25F, 25F });
            tlpDuoi2 = TaoBang("tlpDuoi2", new[] { 50F, 50F }, new[] { 100F });
            tlpMaxMin = TaoBang("tlpMaxMin", new[] { 42F, 28F, 30F }, new[] { 25F, 37.5F, 37.5F });
            tlpThay = TaoBang("tlpThay", new[] { 62F, 38F }, new[] { 25F, 25F, 25F, 25F });

            // ----- khởi tạo control -----
            lbltitle = new Label(); Tketqua = new Label(); Tsapxep = new Label();
            Ttimkiem = new Label(); Tsotimduoc = new Label(); Txoa = new Label(); Tsapxeptang = new Label();
            Tthem = new Label(); Tcanthem = new Label(); Tsapxepthemtang = new Label();
            Ttong = new Label(); Ttongmang = new Label(); Ttongchan = new Label(); Ttongle = new Label();
            Tmaxmin = new Label(); Tgtln = new Label(); Tgtnn = new Label();
            Tthaythe = new Label(); Tsothaythe = new Label();

            button_nhapmang = new Button(); button_reset = new Button(); button_thoat = new Button();
            button_thuchien = new Button(); button_tong = new Button(); button_tim = new Button();

            radioButton_tang = new RadioButton(); radioButton_giam = new RadioButton();
            radioButton_giatritim = new RadioButton(); radioButton_vitritim = new RadioButton();
            radioButton_giatrixoa = new RadioButton(); radioButton_vitrixoa = new RadioButton();
            radioButton_giatrithem = new RadioButton();
            radioButton_giatricanthay = new RadioButton(); radioButton_vitrithaythe = new RadioButton();

            Inputmang = new TextBox(); Outputmang = new TextBox();
            Inputgiatritim = new TextBox(); Inputvitritim = new TextBox(); Outputtim = new TextBox();
            Inputgiatrixoa = new TextBox(); Inputvitrixoa = new TextBox();
            Inputgiatrithem = new TextBox(); Inputvitrithem = new TextBox();
            Outputtongmang = new TextBox(); Outputtongchan = new TextBox(); Outputtongle = new TextBox();
            Outputmax = new TextBox(); Outputmin = new TextBox();
            Inputgiatrithay = new TextBox(); Inputvitrithay = new TextBox(); Inputsothaythe = new TextBox();

            // ----- tiêu đề -----
            lbltitle.Dock = DockStyle.Fill;
            lbltitle.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitle.ForeColor = Color.Red;
            lbltitle.Name = "lbltitle";
            lbltitle.Text = "Mảng Số Nguyên";
            lbltitle.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nhãn -----
            Nhan(Tketqua, "Tketqua", "Kết quả mảng :");
            Nhan(Tsapxep, "Tsapxep", "Sắp xếp");
            Nhan(Ttimkiem, "Ttimkiem", "Tìm Kiếm");
            Nhan(Tsotimduoc, "Tsotimduoc", "Số tìm được là :");
            Nhan(Txoa, "Txoa", "Xóa");
            Nhan(Tsapxeptang, "Tsapxeptang", "Cần sắp xếp tăng");
            Nhan(Tthem, "Tthem", "Thêm");
            Nhan(Tcanthem, "Tcanthem", "Tại vị trí cần thêm :");
            Nhan(Tsapxepthemtang, "Tsapxepthemtang", "Cần sắp xếp tăng");
            Nhan(Ttong, "Ttong", "Tổng");
            Nhan(Ttongmang, "Ttongmang", "Tổng mảng");
            Nhan(Ttongchan, "Ttongchan", "Tổng chẵn");
            Nhan(Ttongle, "Ttongle", "Tổng lẻ");
            Nhan(Tmaxmin, "Tmaxmin", "Max - Min");
            Nhan(Tgtln, "Tgtln", "Giá trị lớn nhất");
            Nhan(Tgtnn, "Tgtnn", "Giá trị nhỏ nhất");
            Nhan(Tthaythe, "Tthaythe", "Thay Thế");
            Nhan(Tsothaythe, "Tsothaythe", "Số thay thế là :");
            Tsapxeptang.ForeColor = Color.Red;
            Tsapxepthemtang.ForeColor = Color.Red;

            // ----- nút -----
            Nut(button_nhapmang, "button_nhapmang", "Nhập mảng :");
            Nut(button_reset, "button_reset", "Reset");
            Nut(button_thoat, "button_thoat", "Thoát");
            Nut(button_thuchien, "button_thuchien", "Thực Hiện");
            Nut(button_tong, "button_tong", "Tổng");
            Nut(button_tim, "button_tim", "Tìm");
            button_nhapmang.Click += button_nhapmang_Click;
            button_reset.Click += button_reset_Click;
            button_thoat.Click += button_thoat_Click;
            button_thuchien.Click += button_thuchien_Click;
            button_tong.Click += button_tong_Click;
            button_tim.Click += button_tim_Click;

            // ----- radio -----
            Radio(radioButton_tang, "radioButton_tang", "Sắp xếp Tăng");
            Radio(radioButton_giam, "radioButton_giam", "Sắp xếp Giảm");
            Radio(radioButton_giatritim, "radioButton_giatritim", "Tìm giá trị cần tìm");
            Radio(radioButton_vitritim, "radioButton_vitritim", "Tìm vị trí cần tìm");
            Radio(radioButton_giatrixoa, "radioButton_giatrixoa", "Tìm giá trị cần xóa");
            Radio(radioButton_vitrixoa, "radioButton_vitrixoa", "Tìm vị trí cần xóa");
            Radio(radioButton_giatrithem, "radioButton_giatrithem", "Tìm giá trị cần thêm");
            Radio(radioButton_giatricanthay, "radioButton_giatricanthay", "Giá trị cần thay thế");
            Radio(radioButton_vitrithaythe, "radioButton_vitrithaythe", "Vị trí cần thay thế");

            // ----- ô nhập mảng -----
            Inputmang.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Inputmang.BorderStyle = BorderStyle.None;
            Inputmang.Margin = new Padding(6, 4, 6, 4);
            Inputmang.Name = "Inputmang";
            Inputmang.KeyPress += Inputmang_KeyPress;
            Inputmang.TextChanged += txt_TextChanged;

            // ----- ô nhập số -----
            NhapSo(Inputgiatritim, "Inputgiatritim");
            NhapSo(Inputvitritim, "Inputvitritim");
            NhapSo(Inputgiatrixoa, "Inputgiatrixoa");
            NhapSo(Inputvitrixoa, "Inputvitrixoa");
            NhapSo(Inputgiatrithem, "Inputgiatrithem");
            NhapSo(Inputvitrithem, "Inputvitrithem");
            NhapSo(Inputgiatrithay, "Inputgiatrithay");
            NhapSo(Inputvitrithay, "Inputvitrithay");
            NhapSo(Inputsothaythe, "Inputsothaythe");

            // ----- ô kết quả (chỉ đọc) -----
            XuatKq(Outputmang, "Outputmang");
            XuatKq(Outputtim, "Outputtim");
            XuatKq(Outputtongmang, "Outputtongmang");
            XuatKq(Outputtongchan, "Outputtongchan");
            XuatKq(Outputtongle, "Outputtongle");
            XuatKq(Outputmax, "Outputmax");
            XuatKq(Outputmin, "Outputmin");

            // ----- hàng nhập mảng / kết quả mảng -----
            tlpTren.Controls.Add(button_nhapmang, 0, 0);
            tlpTren.Controls.Add(Inputmang, 1, 0);
            tlpTren.Controls.Add(button_reset, 2, 0);
            tlpTren.Controls.Add(Tketqua, 0, 1);
            tlpTren.Controls.Add(Outputmang, 1, 1);
            tlpTren.Controls.Add(button_thoat, 2, 1);

            // ----- Thực Hiện + Sắp xếp -----
            tlpNhomSapXep.Controls.Add(Tsapxep, 0, 0);
            tlpNhomSapXep.SetColumnSpan(Tsapxep, 2);
            tlpNhomSapXep.Controls.Add(radioButton_tang, 0, 1);
            tlpNhomSapXep.Controls.Add(radioButton_giam, 1, 1);
            tlpSapXep.Controls.Add(button_thuchien, 0, 0);
            tlpSapXep.Controls.Add(tlpNhomSapXep, 1, 0);

            // ----- Tìm kiếm | Xóa -----
            tlpTim.Controls.Add(Ttimkiem, 0, 0);
            tlpTim.SetColumnSpan(Ttimkiem, 2);
            tlpTim.Controls.Add(radioButton_giatritim, 0, 1);
            tlpTim.Controls.Add(Inputgiatritim, 1, 1);
            tlpTim.Controls.Add(radioButton_vitritim, 0, 2);
            tlpTim.Controls.Add(Inputvitritim, 1, 2);
            tlpTim.Controls.Add(Tsotimduoc, 0, 3);
            tlpTim.Controls.Add(Outputtim, 1, 3);

            tlpXoa.Controls.Add(Txoa, 0, 0);
            tlpXoa.SetColumnSpan(Txoa, 2);
            tlpXoa.Controls.Add(radioButton_giatrixoa, 0, 1);
            tlpXoa.Controls.Add(Inputgiatrixoa, 1, 1);
            tlpXoa.Controls.Add(radioButton_vitrixoa, 0, 2);
            tlpXoa.Controls.Add(Inputvitrixoa, 1, 2);
            tlpXoa.Controls.Add(Tsapxeptang, 0, 3);
            tlpXoa.SetColumnSpan(Tsapxeptang, 2);

            tlpGiua.Controls.Add(tlpTim, 0, 0);
            tlpGiua.Controls.Add(tlpXoa, 1, 0);

            // ----- Thêm | Tổng -----
            tlpThem.Controls.Add(Tthem, 0, 0);
            tlpThem.SetColumnSpan(Tthem, 2);
            tlpThem.Controls.Add(radioButton_giatrithem, 0, 1);
            tlpThem.Controls.Add(Inputgiatrithem, 1, 1);
            tlpThem.Controls.Add(Tcanthem, 0, 2);
            tlpThem.Controls.Add(Inputvitrithem, 1, 2);
            tlpThem.Controls.Add(Tsapxepthemtang, 0, 3);
            tlpThem.SetColumnSpan(Tsapxepthemtang, 2);

            tlpTong.Controls.Add(Ttong, 0, 0);
            tlpTong.SetColumnSpan(Ttong, 3);
            tlpTong.Controls.Add(Ttongmang, 0, 1);
            tlpTong.Controls.Add(Outputtongmang, 1, 1);
            tlpTong.Controls.Add(Ttongchan, 0, 2);
            tlpTong.Controls.Add(Outputtongchan, 1, 2);
            tlpTong.Controls.Add(Ttongle, 0, 3);
            tlpTong.Controls.Add(Outputtongle, 1, 3);
            tlpTong.Controls.Add(button_tong, 2, 1);
            tlpTong.SetRowSpan(button_tong, 3);

            tlpDuoi1.Controls.Add(tlpThem, 0, 0);
            tlpDuoi1.Controls.Add(tlpTong, 1, 0);

            // ----- Max - Min | Thay thế -----
            tlpMaxMin.Controls.Add(Tmaxmin, 0, 0);
            tlpMaxMin.SetColumnSpan(Tmaxmin, 3);
            tlpMaxMin.Controls.Add(Tgtln, 0, 1);
            tlpMaxMin.Controls.Add(Outputmax, 1, 1);
            tlpMaxMin.Controls.Add(Tgtnn, 0, 2);
            tlpMaxMin.Controls.Add(Outputmin, 1, 2);
            tlpMaxMin.Controls.Add(button_tim, 2, 1);
            tlpMaxMin.SetRowSpan(button_tim, 2);

            tlpThay.Controls.Add(Tthaythe, 0, 0);
            tlpThay.SetColumnSpan(Tthaythe, 2);
            tlpThay.Controls.Add(radioButton_giatricanthay, 0, 1);
            tlpThay.Controls.Add(Inputgiatrithay, 1, 1);
            tlpThay.Controls.Add(radioButton_vitrithaythe, 0, 2);
            tlpThay.Controls.Add(Inputvitrithay, 1, 2);
            tlpThay.Controls.Add(Tsothaythe, 0, 3);
            tlpThay.Controls.Add(Inputsothaythe, 1, 3);

            tlpDuoi2.Controls.Add(tlpMaxMin, 0, 0);
            tlpDuoi2.Controls.Add(tlpThay, 1, 0);

            // ----- bảng gốc -----
            tableLayoutPanel1.Controls.Add(lbltitle, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpTren, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpSapXep, 0, 2);
            tableLayoutPanel1.Controls.Add(tlpGiua, 0, 3);
            tableLayoutPanel1.Controls.Add(tlpDuoi1, 0, 4);
            tableLayoutPanel1.Controls.Add(tlpDuoi2, 0, 5);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_thoat;     // Esc = Thoát
            ClientSize = new Size(580, 780);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(598, 827);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mảng Số Nguyên";
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

        private void Radio(RadioButton r, string ten, string chu)
        {
            r.Anchor = AnchorStyles.Left;
            r.AutoSize = true;
            r.Name = ten;
            r.Text = chu;
            r.UseVisualStyleBackColor = true;
            r.CheckedChanged += Radio_CheckedChanged;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(6);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private void NhapSo(TextBox t, string ten)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.MaxLength = 9;
            t.Name = ten;
            t.KeyPress += txtSo_KeyPress;
            t.TextChanged += txt_TextChanged;
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
        private TableLayoutPanel tlpTren;
        private TableLayoutPanel tlpSapXep;
        private TableLayoutPanel tlpNhomSapXep;
        private TableLayoutPanel tlpGiua;
        private TableLayoutPanel tlpTim;
        private TableLayoutPanel tlpXoa;
        private TableLayoutPanel tlpDuoi1;
        private TableLayoutPanel tlpThem;
        private TableLayoutPanel tlpTong;
        private TableLayoutPanel tlpDuoi2;
        private TableLayoutPanel tlpMaxMin;
        private TableLayoutPanel tlpThay;

        private Label lbltitle;
        private Label Tketqua;
        private Label Tsapxep;
        private Label Ttimkiem;
        private Label Tsotimduoc;
        private Label Txoa;
        private Label Tsapxeptang;
        private Label Tthem;
        private Label Tcanthem;
        private Label Tsapxepthemtang;
        private Label Ttong;
        private Label Ttongmang;
        private Label Ttongchan;
        private Label Ttongle;
        private Label Tmaxmin;
        private Label Tgtln;
        private Label Tgtnn;
        private Label Tthaythe;
        private Label Tsothaythe;

        private Button button_nhapmang;
        private Button button_reset;
        private Button button_thoat;
        private Button button_thuchien;
        private Button button_tong;
        private Button button_tim;

        private RadioButton radioButton_tang;
        private RadioButton radioButton_giam;
        private RadioButton radioButton_giatritim;
        private RadioButton radioButton_vitritim;
        private RadioButton radioButton_giatrixoa;
        private RadioButton radioButton_vitrixoa;
        private RadioButton radioButton_giatrithem;
        private RadioButton radioButton_giatricanthay;
        private RadioButton radioButton_vitrithaythe;

        private TextBox Inputmang;
        private TextBox Outputmang;
        private TextBox Inputgiatritim;
        private TextBox Inputvitritim;
        private TextBox Outputtim;
        private TextBox Inputgiatrixoa;
        private TextBox Inputvitrixoa;
        private TextBox Inputgiatrithem;
        private TextBox Inputvitrithem;
        private TextBox Outputtongmang;
        private TextBox Outputtongchan;
        private TextBox Outputtongle;
        private TextBox Outputmax;
        private TextBox Outputmin;
        private TextBox Inputgiatrithay;
        private TextBox Inputvitrithay;
        private TextBox Inputsothaythe;
    }
}