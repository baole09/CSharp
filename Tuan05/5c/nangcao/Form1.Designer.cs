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
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 42F, 58F }, new[] { 100F });
            tlpTrai = TaoBang("tlpTrai", new[] { 100F }, new[] { 12F, 88F });
            // hàng đầu của cột phải để trống cho thẳng hàng với nút "Nhập tên ngẫu nhiên"
            tlpPhai = TaoBang("tlpPhai", new[] { 100F },
                new[] { 12F, 12.5714F, 12.5714F, 12.5714F, 12.5714F, 12.5714F, 12.5714F, 12.5716F });

            // ----- khởi tạo control -----
            lstTen = new ListBox();
            btnNgauNhien = new Button(); btnXoaChon = new Button(); btnXoaSon = new Button();
            btnXoaHoLe = new Button(); btnHoa = new Button(); btnThuong = new Button();
            btnVietHoaDau = new Button(); btnXoaTatCa = new Button();

            // ----- danh sách tên (chọn nhiều) -----
            lstTen.Dock = DockStyle.Fill;
            lstTen.FormattingEnabled = true;
            lstTen.Margin = new Padding(6);
            lstTen.Name = "lstTen";
            lstTen.SelectionMode = SelectionMode.MultiExtended;
            lstTen.MouseDoubleClick += lstTen_MouseDoubleClick;

            // ----- nút -----
            Nut(btnNgauNhien, "btnNgauNhien", "Nhập tên ngẫu nhiên");
            Nut(btnXoaChon, "btnXoaChon", "Xóa Phần tử đang chọn");
            Nut(btnXoaSon, "btnXoaSon", "Xóa phần tử có tên là Sơn");
            Nut(btnXoaHoLe, "btnXoaHoLe", "Xóa Phần tử có họ là Lê");
            Nut(btnHoa, "btnHoa", "Chuyển PT đang chọn thành chữ HOA");
            Nut(btnThuong, "btnThuong", "Chuyển PT đang chọn thành chữ thường");
            Nut(btnVietHoaDau, "btnVietHoaDau", "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ");
            Nut(btnXoaTatCa, "btnXoaTatCa", "Xóa tất cả các Phần tử");

            btnNgauNhien.Click += btnNgauNhien_Click;
            btnXoaChon.Click += btnXoaChon_Click;
            btnXoaSon.Click += btnXoaSon_Click;
            btnXoaHoLe.Click += btnXoaHoLe_Click;
            btnHoa.Click += btnHoa_Click;
            btnThuong.Click += btnThuong_Click;
            btnVietHoaDau.Click += btnVietHoaDau_Click;
            btnXoaTatCa.Click += btnXoaTatCa_Click;

            // ----- ghép -----
            tlpTrai.Controls.Add(btnNgauNhien, 0, 0);
            tlpTrai.Controls.Add(lstTen, 0, 1);

            tlpPhai.Controls.Add(btnXoaChon, 0, 1);
            tlpPhai.Controls.Add(btnXoaSon, 0, 2);
            tlpPhai.Controls.Add(btnXoaHoLe, 0, 3);
            tlpPhai.Controls.Add(btnHoa, 0, 4);
            tlpPhai.Controls.Add(btnThuong, 0, 5);
            tlpPhai.Controls.Add(btnVietHoaDau, 0, 6);
            tlpPhai.Controls.Add(btnXoaTatCa, 0, 7);

            tableLayoutPanel1.Controls.Add(tlpTrai, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpPhai, 1, 0);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 460);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(578, 507);
            Name = "Form1";
            FormClosing += Form1_FormClosing;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmChuoi";
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
            b.UseVisualStyleBackColor = true;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpTrai;
        private TableLayoutPanel tlpPhai;

        private ListBox lstTen;

        private Button btnNgauNhien;
        private Button btnXoaChon;
        private Button btnXoaSon;
        private Button btnXoaHoLe;
        private Button btnHoa;
        private Button btnThuong;
        private Button btnVietHoaDau;
        private Button btnXoaTatCa;
    }
}