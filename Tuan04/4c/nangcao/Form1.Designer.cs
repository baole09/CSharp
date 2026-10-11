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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTieuDe = new Label();
            tlpGhe = new TableLayoutPanel();
            lblThanhTien = new Label();
            txtThanhTien = new TextBox();
            btnChon = new Button();
            btnHuyBo = new Button();
            btnKetThuc = new Button();
            tableLayoutPanel1.SuspendLayout();
            tlpGhe.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21F));
            // hàng 0: màn ảnh
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblTieuDe, 3);
            // hàng 1: sơ đồ ghế
            tableLayoutPanel1.Controls.Add(tlpGhe, 0, 1);
            tableLayoutPanel1.SetColumnSpan(tlpGhe, 3);
            // hàng 2: thành tiền
            tableLayoutPanel1.Controls.Add(lblThanhTien, 0, 2);
            tableLayoutPanel1.Controls.Add(txtThanhTien, 1, 2);
            tableLayoutPanel1.SetColumnSpan(txtThanhTien, 2);
            // hàng 3: 3 nút
            tableLayoutPanel1.Controls.Add(btnChon, 0, 3);
            tableLayoutPanel1.Controls.Add(btnHuyBo, 1, 3);
            tableLayoutPanel1.Controls.Add(btnKetThuc, 2, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.DarkOrange;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "MÀN ẢNH";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpGhe  (15 nút ghế được thêm bằng code trong Form1.cs)
            // 
            tlpGhe.ColumnCount = 5;
            for (int i = 0; i < 5; i++)
                tlpGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpGhe.RowCount = 3;
            for (int i = 0; i < 3; i++)
                tlpGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpGhe.Dock = DockStyle.Fill;
            tlpGhe.Name = "tlpGhe";
            tlpGhe.TabIndex = 1;
            // 
            // lblThanhTien
            // 
            lblThanhTien.Anchor = AnchorStyles.Left;
            lblThanhTien.AutoSize = true;
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.TabIndex = 2;
            lblThanhTien.Text = "Thành Tiền :";
            // 
            // txtThanhTien
            // 
            txtThanhTien.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtThanhTien.BorderStyle = BorderStyle.None;
            txtThanhTien.Margin = new Padding(6);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.ReadOnly = true;
            txtThanhTien.TabIndex = 3;
            txtThanhTien.TabStop = false;
            txtThanhTien.TextAlign = HorizontalAlignment.Right;
            // 
            // btnChon
            // 
            btnChon.Dock = DockStyle.Fill;
            btnChon.Margin = new Padding(6, 10, 6, 10);
            btnChon.Name = "btnChon";
            btnChon.TabIndex = 0;
            btnChon.Text = "Chọn";
            btnChon.UseVisualStyleBackColor = true;
            btnChon.Click += btnChon_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Dock = DockStyle.Fill;
            btnHuyBo.Margin = new Padding(6, 10, 6, 10);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.TabIndex = 1;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnKetThuc
            // 
            btnKetThuc.Dock = DockStyle.Fill;
            btnKetThuc.Margin = new Padding(6, 10, 6, 10);
            btnKetThuc.Name = "btnKetThuc";
            btnKetThuc.TabIndex = 2;
            btnKetThuc.Text = "Kết thúc";
            btnKetThuc.UseVisualStyleBackColor = true;
            btnKetThuc.Click += btnKetThuc_Click;
            // 
            // Form1
            // 
            AcceptButton = btnChon;        // Enter = Chọn
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnKetThuc;     // Esc = Kết thúc
            ClientSize = new Size(440, 520);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(458, 567);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán vé rạp chiếu phim";
            FormClosing += Form1_FormClosing;
            tlpGhe.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private TableLayoutPanel tlpGhe;
        private Label lblThanhTien;
        private TextBox txtThanhTien;
        private Button btnChon;
        private Button btnHuyBo;
        private Button btnKetThuc;
    }
}