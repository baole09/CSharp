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
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 12F, 31F, 9F, 39F, 9F });
            tlpNhap = TaoBang("tlpNhap", new[] { 30F, 70F }, new[] { 25F, 25F, 25F, 25F });
            tlpNut = TaoBang("tlpNut", new[] { 40F, 15F, 15F, 15F, 15F }, new[] { 100F });
            tlpTong = TaoBang("tlpTong", new[] { 56F, 16F, 28F }, new[] { 100F });

            // ----- khởi tạo control -----
            lblTieuDe = new Label(); lblSoTK = new Label(); lblTenKH = new Label();
            lblDiaChi = new Label(); lblSoTien = new Label(); lblTongTien = new Label();
            txtSoTK = new TextBox(); txtTenKH = new TextBox(); txtDiaChi = new TextBox();
            txtSoTien = new TextBox(); txtTongTien = new TextBox();
            lvTK = new ListView();
            btnThem = new Button(); btnLuu = new Button(); btnXoa = new Button(); btnThoat = new Button();

            // ----- tiêu đề -----
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.Blue;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nhãn (căn phải, sát ô nhập) -----
            NhanPhai(lblSoTK, "lblSoTK", "Số tài khoản");
            NhanPhai(lblTenKH, "lblTenKH", "Tên khách hàng");
            NhanPhai(lblDiaChi, "lblDiaChi", "Địa chỉ khách hàng");
            NhanPhai(lblSoTien, "lblSoTien", "Số tiền trong tài khoản");
            NhanPhai(lblTongTien, "lblTongTien", "Tổng tiền");

            // ----- ô nhập -----
            NhapChu(txtSoTK, "txtSoTK", 15, HorizontalAlignment.Left, true);
            NhapChu(txtTenKH, "txtTenKH", 50, HorizontalAlignment.Left, false);
            NhapChu(txtDiaChi, "txtDiaChi", 100, HorizontalAlignment.Left, false);
            NhapChu(txtSoTien, "txtSoTien", 12, HorizontalAlignment.Right, true);

            // ----- ô tổng tiền (chỉ đọc) -----
            txtTongTien.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTongTien.BorderStyle = BorderStyle.None;
            txtTongTien.Margin = new Padding(6, 4, 6, 4);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.TabStop = false;
            txtTongTien.TextAlign = HorizontalAlignment.Right;

            // ----- ListView -----
            lvTK.Columns.Add("STT", 50);
            lvTK.Columns.Add("Số tài khoản", 120);
            lvTK.Columns.Add("Tên khách hàng", 150);
            lvTK.Columns.Add("Địa chỉ", 110);
            lvTK.Columns.Add("Số tiền", 100, HorizontalAlignment.Right);
            lvTK.Dock = DockStyle.Fill;
            lvTK.FullRowSelect = true;
            lvTK.GridLines = true;
            lvTK.HideSelection = false;
            lvTK.Margin = new Padding(6);
            lvTK.MultiSelect = false;
            lvTK.Name = "lvTK";
            lvTK.UseCompatibleStateImageBehavior = false;
            lvTK.View = View.Details;
            lvTK.SelectedIndexChanged += lvTK_SelectedIndexChanged;
            lvTK.Resize += (s, e) => CanCotListView();

            // ----- nút -----
            Nut(btnThem, "btnThem", "Thêm");
            Nut(btnLuu, "btnLuu", "Lưu");
            Nut(btnXoa, "btnXoa", "Xóa");
            Nut(btnThoat, "btnThoat", "Thoát");
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;

            // ----- ghép -----
            tlpNhap.Controls.Add(lblSoTK, 0, 0);
            tlpNhap.Controls.Add(txtSoTK, 1, 0);
            tlpNhap.Controls.Add(lblTenKH, 0, 1);
            tlpNhap.Controls.Add(txtTenKH, 1, 1);
            tlpNhap.Controls.Add(lblDiaChi, 0, 2);
            tlpNhap.Controls.Add(txtDiaChi, 1, 2);
            tlpNhap.Controls.Add(lblSoTien, 0, 3);
            tlpNhap.Controls.Add(txtSoTien, 1, 3);

            tlpNut.Controls.Add(btnThem, 1, 0);
            tlpNut.Controls.Add(btnLuu, 2, 0);
            tlpNut.Controls.Add(btnXoa, 3, 0);
            tlpNut.Controls.Add(btnThoat, 4, 0);

            tlpTong.Controls.Add(lblTongTien, 1, 0);
            tlpTong.Controls.Add(txtTongTien, 2, 0);

            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpNhap, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpNut, 0, 2);
            tableLayoutPanel1.Controls.Add(lvTK, 0, 3);
            tableLayoutPanel1.Controls.Add(tlpTong, 0, 4);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnLuu;           // Enter = Lưu
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;         // Esc = Thoát
            ClientSize = new Size(640, 560);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(658, 607);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBaiTap2";
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

        private static void NhanPhai(Label l, string ten, string chu)
        {
            l.Anchor = AnchorStyles.Right;
            l.AutoSize = true;
            l.Margin = new Padding(3, 3, 6, 3);
            l.Name = ten;
            l.Text = chu;
        }

        // chiSo: true thì chỉ cho gõ chữ số
        private void NhapChu(TextBox t, string ten, int toiDa, HorizontalAlignment canh, bool chiSo)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.MaxLength = toiDa;
            t.Name = ten;
            t.TextAlign = canh;
            t.TextChanged += txt_TextChanged;
            if (chiSo) t.KeyPress += txtSo_KeyPress;
        }

        private static void Nut(Button b, string ten, string chu)
        {
            b.Dock = DockStyle.Fill;
            b.Margin = new Padding(4, 4, 4, 4);
            b.Name = ten;
            b.Text = chu;
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpNhap;
        private TableLayoutPanel tlpNut;
        private TableLayoutPanel tlpTong;

        private Label lblTieuDe;
        private Label lblSoTK;
        private Label lblTenKH;
        private Label lblDiaChi;
        private Label lblSoTien;
        private Label lblTongTien;
        private TextBox txtSoTK;
        private TextBox txtTenKH;
        private TextBox txtDiaChi;
        private TextBox txtSoTien;
        private TextBox txtTongTien;

        private ListView lvTK;

        private Button btnThem;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThoat;
    }
}