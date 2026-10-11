namespace btvn
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
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 12F, 88F });
            tlpChinh = TaoBang("tlpChinh", new[] { 62F, 38F }, new[] { 100F });
            tlpTrai = TaoBang("tlpTrai", new[] { 100F }, new[] { 38F, 62F });
            tlpThongTin = TaoBang("tlpThongTin", new[] { 24F, 76F }, new[] { 33F, 33F, 34F });
            tlpNhom = TaoBang("tlpNhom", new[] { 33F, 35F, 32F }, new[] { 100F });
            tlpLoaiPhong = TaoBang("tlpLoaiPhong", new[] { 100F }, new[] { 33F, 33F, 34F });
            tlpTienNghi = TaoBang("tlpTienNghi", new[] { 100F }, new[] { 33F, 33F, 34F });
            tlpDichVu = TaoBang("tlpDichVu", new[] { 100F }, new[] { 33F, 33F, 34F });
            tlpPhai = TaoBang("tlpPhai", new[] { 100F }, new[] { 14F, 14F, 14F, 34F, 14F, 10F });
            tlpNutTren = TaoBang("tlpNutTren", new[] { 50F, 50F }, new[] { 100F });
            tlpTien = TaoBang("tlpTien", new[] { 34F, 66F }, new[] { 100F });
            tlpTongKet = TaoBang("tlpTongKet", new[] { 46F, 54F }, new[] { 50F, 50F });

            // ----- khởi tạo control -----
            lblTieuDe = new Label(); lblHoTen = new Label(); lblDiaChi = new Label(); lblSoNgay = new Label();
            lblThanhTien = new Label(); lblSoLuot = new Label(); lblTongTien = new Label();

            txtHoTen = new TextBox(); txtDiaChi = new TextBox(); txtSoNgay = new TextBox();
            txtThanhTien = new TextBox(); txtSoLuot = new TextBox(); txtTongTien = new TextBox();

            grpLoaiPhong = new GroupBox(); grpTienNghi = new GroupBox();
            grpDichVu = new GroupBox(); grpTongKet = new GroupBox();

            radioButton_phongdon = new RadioButton(); radioButton_phongdoi = new RadioButton();
            radioButton_phongba = new RadioButton();

            chkTivi = new CheckBox(); chkInternet = new CheckBox(); chkMayNuocNong = new CheckBox();
            chkKaraoke = new CheckBox(); chkAnSang = new CheckBox();

            btnThanhToan = new Button(); btnNhapMoi = new Button();
            btnTongKet = new Button(); btnThoat = new Button();

            // ----- tiêu đề -----
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.DarkOrange;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nhãn -----
            Nhan(lblHoTen, "lblHoTen", "Họ và tên :");
            Nhan(lblDiaChi, "lblDiaChi", "Địa chỉ :");
            Nhan(lblSoNgay, "lblSoNgay", "Số ngày ở :");
            Nhan(lblThanhTien, "lblThanhTien", "Thành tiền :");
            Nhan(lblSoLuot, "lblSoLuot", "Số lượt người :");
            Nhan(lblTongTien, "lblTongTien", "Tổng số tiền :");

            // ----- ô nhập thông tin -----
            NhapChu(txtHoTen, "txtHoTen", 50);
            NhapChu(txtDiaChi, "txtDiaChi", 100);

            NhapChu(txtSoNgay, "txtSoNgay", 4);
            txtSoNgay.KeyPress += txtSoNgay_KeyPress;

            txtHoTen.Validating += txtHoTen_Validating;
            txtDiaChi.Validating += txtDiaChi_Validating;
            txtSoNgay.Validating += txtSoNgay_Validating;

            // ----- ô kết quả (chỉ đọc) -----
            XuatKq(txtThanhTien, "txtThanhTien");
            XuatKq(txtSoLuot, "txtSoLuot");
            XuatKq(txtTongTien, "txtTongTien");

            // ----- nhóm Loại phòng (radio, giá/ngày lưu trong Tag) -----
            Nhom(grpLoaiPhong, "grpLoaiPhong", "Loại phòng");
            Radio(radioButton_phongdon, "radioButton_phongdon", "Phòng đơn", 300000m);
            Radio(radioButton_phongdoi, "radioButton_phongdoi", "Phòng đôi", 350000m);
            Radio(radioButton_phongba, "radioButton_phongba", "Phòng ba", 400000m);

            // ----- nhóm Tiện nghi (mỗi loại +10.000) -----
            Nhom(grpTienNghi, "grpTienNghi", "Tiện nghi");
            Check(chkTivi, "chkTivi", "Tivi", 10000m);
            Check(chkInternet, "chkInternet", "Internet", 10000m);
            Check(chkMayNuocNong, "chkMayNuocNong", "Máy nước nóng", 10000m);

            // ----- nhóm Dịch vụ (Karaoke 50.000 một lần, Ăn sáng 15.000/ngày) -----
            Nhom(grpDichVu, "grpDichVu", "Dịch vụ");
            Check(chkKaraoke, "chkKaraoke", "Karaoke", 50000m);
            Check(chkAnSang, "chkAnSang", "Ăn sáng", 15000m);

            Nhom(grpTongKet, "grpTongKet", "Thông tin tổng kết");

            // ----- nút -----
            Nut(btnThanhToan, "btnThanhToan", "Thanh toán");
            Nut(btnNhapMoi, "btnNhapMoi", "Nhập mới");
            Nut(btnTongKet, "btnTongKet", "Tổng Kết");
            Nut(btnThoat, "btnThoat", "Thoát");
            btnThanhToan.Click += btnThanhToan_Click;
            btnNhapMoi.Click += btnNhapMoi_Click;
            btnTongKet.Click += btnTongKet_Click;
            btnThoat.Click += btnThoat_Click;

            // ----- ghép bên trái -----
            tlpThongTin.Controls.Add(lblHoTen, 0, 0);
            tlpThongTin.Controls.Add(txtHoTen, 1, 0);
            tlpThongTin.Controls.Add(lblDiaChi, 0, 1);
            tlpThongTin.Controls.Add(txtDiaChi, 1, 1);
            tlpThongTin.Controls.Add(lblSoNgay, 0, 2);
            tlpThongTin.Controls.Add(txtSoNgay, 1, 2);

            tlpLoaiPhong.Controls.Add(radioButton_phongdon, 0, 0);
            tlpLoaiPhong.Controls.Add(radioButton_phongdoi, 0, 1);
            tlpLoaiPhong.Controls.Add(radioButton_phongba, 0, 2);
            grpLoaiPhong.Controls.Add(tlpLoaiPhong);

            tlpTienNghi.Controls.Add(chkTivi, 0, 0);
            tlpTienNghi.Controls.Add(chkInternet, 0, 1);
            tlpTienNghi.Controls.Add(chkMayNuocNong, 0, 2);
            grpTienNghi.Controls.Add(tlpTienNghi);

            tlpDichVu.Controls.Add(chkKaraoke, 0, 0);
            tlpDichVu.Controls.Add(chkAnSang, 0, 1);
            grpDichVu.Controls.Add(tlpDichVu);

            tlpNhom.Controls.Add(grpLoaiPhong, 0, 0);
            tlpNhom.Controls.Add(grpTienNghi, 1, 0);
            tlpNhom.Controls.Add(grpDichVu, 2, 0);

            tlpTrai.Controls.Add(tlpThongTin, 0, 0);
            tlpTrai.Controls.Add(tlpNhom, 0, 1);

            // ----- ghép bên phải -----
            tlpNutTren.Controls.Add(btnThanhToan, 0, 0);
            tlpNutTren.Controls.Add(btnNhapMoi, 1, 0);

            tlpTien.Controls.Add(lblThanhTien, 0, 0);
            tlpTien.Controls.Add(txtThanhTien, 1, 0);

            tlpTongKet.Controls.Add(lblSoLuot, 0, 0);
            tlpTongKet.Controls.Add(txtSoLuot, 1, 0);
            tlpTongKet.Controls.Add(lblTongTien, 0, 1);
            tlpTongKet.Controls.Add(txtTongTien, 1, 1);
            grpTongKet.Controls.Add(tlpTongKet);

            tlpPhai.Controls.Add(tlpNutTren, 0, 0);
            tlpPhai.Controls.Add(tlpTien, 0, 1);
            tlpPhai.Controls.Add(btnTongKet, 0, 2);
            tlpPhai.Controls.Add(grpTongKet, 0, 3);
            tlpPhai.Controls.Add(btnThoat, 0, 4);

            // ----- bảng gốc -----
            tlpChinh.Controls.Add(tlpTrai, 0, 0);
            tlpChinh.Controls.Add(tlpPhai, 1, 0);

            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpChinh, 0, 1);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnThanhToan;     // Enter = Thanh toán
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;         // Esc = Thoát
            ClientSize = new Size(780, 520);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(798, 567);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách sạn Thanh Thanh";
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

        private void NhapChu(TextBox t, string ten, int toiDa)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.MaxLength = toiDa;
            t.Name = ten;
            t.TextChanged += Nhap_TextChanged;
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

        private void Radio(RadioButton r, string ten, string chu, decimal gia)
        {
            r.Anchor = AnchorStyles.Left;
            r.AutoSize = true;
            r.Margin = new Padding(12, 3, 3, 3);
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
            c.Margin = new Padding(12, 3, 3, 3);
            c.Name = ten;
            c.Tag = gia;
            c.Text = chu;
            c.UseVisualStyleBackColor = true;
            c.CheckedChanged += DuLieuThayDoi;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(6, 8, 6, 8);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpChinh;
        private TableLayoutPanel tlpTrai;
        private TableLayoutPanel tlpThongTin;
        private TableLayoutPanel tlpNhom;
        private TableLayoutPanel tlpLoaiPhong;
        private TableLayoutPanel tlpTienNghi;
        private TableLayoutPanel tlpDichVu;
        private TableLayoutPanel tlpPhai;
        private TableLayoutPanel tlpNutTren;
        private TableLayoutPanel tlpTien;
        private TableLayoutPanel tlpTongKet;

        private Label lblTieuDe;
        private Label lblHoTen;
        private Label lblDiaChi;
        private Label lblSoNgay;
        private Label lblThanhTien;
        private Label lblSoLuot;
        private Label lblTongTien;

        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private TextBox txtSoNgay;
        private TextBox txtThanhTien;
        private TextBox txtSoLuot;
        private TextBox txtTongTien;

        private GroupBox grpLoaiPhong;
        private GroupBox grpTienNghi;
        private GroupBox grpDichVu;
        private GroupBox grpTongKet;

        private RadioButton radioButton_phongdon;
        private RadioButton radioButton_phongdoi;
        private RadioButton radioButton_phongba;

        private CheckBox chkTivi;
        private CheckBox chkInternet;
        private CheckBox chkMayNuocNong;
        private CheckBox chkKaraoke;
        private CheckBox chkAnSang;

        private Button btnThanhToan;
        private Button btnNhapMoi;
        private Button btnTongKet;
        private Button btnThoat;
    }
}