namespace bai4
{
    partial class Form4
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
            lblNhapSo = new Label();
            lblDay = new Label();
            lblTong = new Label();
            lblChan = new Label();
            lblLe = new Label();
            txtSo = new TextBox();
            txtDay = new TextBox();
            txtTong = new TextBox();
            txtChan = new TextBox();
            txtLe = new TextBox();
            btnNhap = new Button();
            btnTinhTong = new Button();
            btnTiepTuc = new Button();
            btnThoat = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
            // hàng 0: tiêu đề
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblTieuDe, 4);
            // hàng 1: nhập số + nút Nhập
            tableLayoutPanel1.Controls.Add(lblNhapSo, 0, 1);
            tableLayoutPanel1.Controls.Add(txtSo, 1, 1);
            tableLayoutPanel1.SetColumnSpan(txtSo, 2);
            tableLayoutPanel1.Controls.Add(btnNhap, 3, 1);
            // hàng 2: dãy vừa nhập
            tableLayoutPanel1.Controls.Add(lblDay, 0, 2);
            tableLayoutPanel1.Controls.Add(txtDay, 1, 2);
            tableLayoutPanel1.SetColumnSpan(txtDay, 3);
            // hàng 3: tổng
            tableLayoutPanel1.Controls.Add(lblTong, 0, 3);
            tableLayoutPanel1.Controls.Add(txtTong, 1, 3);
            tableLayoutPanel1.SetColumnSpan(txtTong, 3);
            // hàng 4: tổng chẵn, tổng lẻ
            tableLayoutPanel1.Controls.Add(lblChan, 0, 4);
            tableLayoutPanel1.Controls.Add(txtChan, 1, 4);
            tableLayoutPanel1.Controls.Add(lblLe, 2, 4);
            tableLayoutPanel1.Controls.Add(txtLe, 3, 4);
            // hàng 5: 3 nút
            tableLayoutPanel1.Controls.Add(btnTinhTong, 0, 5);
            tableLayoutPanel1.SetColumnSpan(btnTinhTong, 2);
            tableLayoutPanel1.Controls.Add(btnTiepTuc, 2, 5);
            tableLayoutPanel1.Controls.Add(btnThoat, 3, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.Red;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Nhập Dãy Số và Tính Tổng";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNhapSo
            // 
            lblNhapSo.Anchor = AnchorStyles.Left;
            lblNhapSo.AutoSize = true;
            lblNhapSo.Name = "lblNhapSo";
            lblNhapSo.TabIndex = 1;
            lblNhapSo.Text = "Nhập số :";
            // 
            // lblDay
            // 
            lblDay.Anchor = AnchorStyles.Left;
            lblDay.AutoSize = true;
            lblDay.Name = "lblDay";
            lblDay.TabIndex = 2;
            lblDay.Text = "Dãy vừa nhập :";
            // 
            // lblTong
            // 
            lblTong.Anchor = AnchorStyles.Left;
            lblTong.AutoSize = true;
            lblTong.Name = "lblTong";
            lblTong.TabIndex = 3;
            lblTong.Text = "Tổng các phần tử :";
            // 
            // lblChan
            // 
            lblChan.Anchor = AnchorStyles.Left;
            lblChan.AutoSize = true;
            lblChan.Name = "lblChan";
            lblChan.TabIndex = 4;
            lblChan.Text = "Tổng Chẵn :";
            // 
            // lblLe
            // 
            lblLe.Anchor = AnchorStyles.Left;
            lblLe.AutoSize = true;
            lblLe.Name = "lblLe";
            lblLe.TabIndex = 5;
            lblLe.Text = "Tổng Lẻ :";
            // 
            // txtSo
            // 
            txtSo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSo.BorderStyle = BorderStyle.None;
            txtSo.MaxLength = 9;
            txtSo.Margin = new Padding(6);
            txtSo.Name = "txtSo";
            txtSo.TabIndex = 0;
            txtSo.KeyPress += txtSo_KeyPress;
            txtSo.Validating += txtSo_Validating;
            // 
            // txtDay
            // 
            txtDay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDay.BorderStyle = BorderStyle.None;
            txtDay.Margin = new Padding(6);
            txtDay.Name = "txtDay";
            txtDay.ReadOnly = true;
            txtDay.TabIndex = 6;
            txtDay.TabStop = false;
            // 
            // txtTong
            // 
            txtTong.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTong.BorderStyle = BorderStyle.None;
            txtTong.Margin = new Padding(6);
            txtTong.Name = "txtTong";
            txtTong.ReadOnly = true;
            txtTong.TabIndex = 7;
            txtTong.TabStop = false;
            // 
            // txtChan
            // 
            txtChan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtChan.BorderStyle = BorderStyle.None;
            txtChan.Margin = new Padding(6);
            txtChan.Name = "txtChan";
            txtChan.ReadOnly = true;
            txtChan.TabIndex = 8;
            txtChan.TabStop = false;
            // 
            // txtLe
            // 
            txtLe.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLe.BorderStyle = BorderStyle.None;
            txtLe.Margin = new Padding(6);
            txtLe.Name = "txtLe";
            txtLe.ReadOnly = true;
            txtLe.TabIndex = 9;
            txtLe.TabStop = false;
            // 
            // btnNhap
            // 
            btnNhap.Dock = DockStyle.Fill;
            btnNhap.Margin = new Padding(6, 4, 6, 4);
            btnNhap.Name = "btnNhap";
            btnNhap.TabIndex = 1;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnTinhTong
            // 
            btnTinhTong.Dock = DockStyle.Fill;
            btnTinhTong.Margin = new Padding(6, 10, 6, 10);
            btnTinhTong.Name = "btnTinhTong";
            btnTinhTong.TabIndex = 2;
            btnTinhTong.Text = "Tính Tổng";
            btnTinhTong.UseVisualStyleBackColor = true;
            btnTinhTong.Click += btnTinhTong_Click;
            // 
            // btnTiepTuc
            // 
            btnTiepTuc.Dock = DockStyle.Fill;
            btnTiepTuc.Margin = new Padding(6, 10, 6, 10);
            btnTiepTuc.Name = "btnTiepTuc";
            btnTiepTuc.TabIndex = 3;
            btnTiepTuc.Text = "Tiếp Tục";
            btnTiepTuc.UseVisualStyleBackColor = true;
            btnTiepTuc.Click += btnTiepTuc_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Fill;
            btnThoat.Margin = new Padding(6, 10, 6, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form4
            // 
            AcceptButton = btnNhap;        // Enter = Nhập
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;       // Esc = Thoát
            ClientSize = new Size(560, 380);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(578, 427);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dãy số và Tính Tổng";
            FormClosing += Form4_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private Label lblNhapSo;
        private Label lblDay;
        private Label lblTong;
        private Label lblChan;
        private Label lblLe;
        private TextBox txtSo;
        private TextBox txtDay;
        private TextBox txtTong;
        private TextBox txtChan;
        private TextBox txtLe;
        private Button btnNhap;
        private Button btnTinhTong;
        private Button btnTiepTuc;
        private Button btnThoat;
    }
}