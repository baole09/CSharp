namespace btvn2
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
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 100F }, new[] { 13F, 75F, 12F });
            tlpThan = TaoBang("tlpThan", new[] { 42F, 58F }, new[] { 100F });
            tlpTrai = TaoBang("tlpTrai", new[] { 100F }, new[] { 8F, 12F, 12F, 68F });
            tlpPhai = TaoBang("tlpPhai", new[] { 100F },
                new[] { 9F, 13F, 13F, 13F, 13F, 13F, 13F, 13F });

            // ----- khởi tạo control -----
            lblTieuDe = new Label(); lblListbox = new Label(); lblXuLy = new Label();
            txtN = new TextBox(); lstSo = new ListBox();
            btnNhap = new Button(); btnTong = new Button(); btnXoaDauCuoi = new Button();
            btnXoaChon = new Button(); btnTang2 = new Button(); btnBinhPhuong = new Button();
            btnChonChan = new Button(); btnChonLe = new Button(); btnKetThuc = new Button();

            // ----- tiêu đề -----
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.RoyalBlue;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "LISTBOX";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nhãn -----
            Nhan(lblListbox, "lblListbox", "Listbox");
            Nhan(lblXuLy, "lblXuLy", "Xử lý Listbox");

            // ----- ô nhập số N -----
            txtN.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtN.BorderStyle = BorderStyle.None;
            txtN.Margin = new Padding(6, 4, 6, 4);
            txtN.MaxLength = 9;
            txtN.Name = "txtN";
            txtN.KeyPress += txtN_KeyPress;
            txtN.TextChanged += txtN_TextChanged;

            // ----- listbox chọn nhiều phần tử -----
            lstSo.Dock = DockStyle.Fill;
            lstSo.FormattingEnabled = true;
            lstSo.IntegralHeight = false;
            lstSo.Margin = new Padding(6);
            lstSo.Name = "lstSo";
            lstSo.SelectionMode = SelectionMode.MultiExtended;

            // ----- nút -----
            Nut(btnNhap, "btnNhap", "&Nhập");
            Nut(btnTong, "btnTong", "Tổng các phần tử trong List");
            Nut(btnXoaDauCuoi, "btnXoaDauCuoi", "Xóa Phần tử đầu và cuối");
            Nut(btnXoaChon, "btnXoaChon", "Xóa Phần tử đang chọn");
            Nut(btnTang2, "btnTang2", "Tăng mỗi phần tử lên 2");
            Nut(btnBinhPhuong, "btnBinhPhuong", "Thay bằng bình phương");
            Nut(btnChonChan, "btnChonChan", "Chọn số chẵn");
            Nut(btnChonLe, "btnChonLe", "Chọn số lẻ");
            Nut(btnKetThuc, "btnKetThuc", "&KẾT THÚC");

            btnNhap.Click += btnNhap_Click;
            btnTong.Click += btnTong_Click;
            btnXoaDauCuoi.Click += btnXoaDauCuoi_Click;
            btnXoaChon.Click += btnXoaChon_Click;
            btnTang2.Click += btnTang2_Click;
            btnBinhPhuong.Click += btnBinhPhuong_Click;
            btnChonChan.Click += btnChonChan_Click;
            btnChonLe.Click += btnChonLe_Click;
            btnKetThuc.Click += btnKetThuc_Click;

            // ----- ghép -----
            tlpTrai.Controls.Add(lblListbox, 0, 0);
            tlpTrai.Controls.Add(txtN, 0, 1);
            tlpTrai.Controls.Add(btnNhap, 0, 2);
            tlpTrai.Controls.Add(lstSo, 0, 3);

            tlpPhai.Controls.Add(lblXuLy, 0, 0);
            tlpPhai.Controls.Add(btnTong, 0, 1);
            tlpPhai.Controls.Add(btnXoaDauCuoi, 0, 2);
            tlpPhai.Controls.Add(btnXoaChon, 0, 3);
            tlpPhai.Controls.Add(btnTang2, 0, 4);
            tlpPhai.Controls.Add(btnBinhPhuong, 0, 5);
            tlpPhai.Controls.Add(btnChonChan, 0, 6);
            tlpPhai.Controls.Add(btnChonLe, 0, 7);

            tlpThan.Controls.Add(tlpTrai, 0, 0);
            tlpThan.Controls.Add(tlpPhai, 1, 0);

            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpThan, 0, 1);
            tableLayoutPanel1.Controls.Add(btnKetThuc, 0, 2);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnNhap;          // Enter = Nhập
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnKetThuc;       // Esc = Kết thúc
            ClientSize = new Size(500, 560);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(518, 607);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmListbox";
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
        private TableLayoutPanel tlpThan;
        private TableLayoutPanel tlpTrai;
        private TableLayoutPanel tlpPhai;

        private Label lblTieuDe;
        private Label lblListbox;
        private Label lblXuLy;
        private TextBox txtN;
        private ListBox lstSo;

        private Button btnNhap;
        private Button btnTong;
        private Button btnXoaDauCuoi;
        private Button btnXoaChon;
        private Button btnTang2;
        private Button btnBinhPhuong;
        private Button btnChonChan;
        private Button btnChonLe;
        private Button btnKetThuc;
    }
}