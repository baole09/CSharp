namespace bai2
{
    partial class Form2
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
            lblTenDangNhap = new Label();
            lblEmail = new Label();
            lblMatKhau = new Label();
            lblXacNhan = new Label();
            lblSao1 = new Label();
            lblSao2 = new Label();
            lblSao3 = new Label();
            txtTenDangNhap = new TextBox();
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            txtXacNhan = new TextBox();
            btnDangKy = new Button();
            chkHienMatKhau = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblTieuDe, 3);
            tableLayoutPanel1.Controls.Add(lblTenDangNhap, 0, 1);
            tableLayoutPanel1.Controls.Add(txtTenDangNhap, 1, 1);
            tableLayoutPanel1.Controls.Add(lblSao1, 2, 1);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 2);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 2);
            tableLayoutPanel1.Controls.Add(lblSao2, 2, 2);
            tableLayoutPanel1.Controls.Add(lblMatKhau, 0, 3);
            tableLayoutPanel1.Controls.Add(txtMatKhau, 1, 3);
            tableLayoutPanel1.Controls.Add(lblSao3, 2, 3);
            tableLayoutPanel1.Controls.Add(lblXacNhan, 0, 4);
            tableLayoutPanel1.Controls.Add(txtXacNhan, 1, 4);
            tableLayoutPanel1.Controls.Add(chkHienMatKhau, 1, 5);
            tableLayoutPanel1.Controls.Add(btnDangKy, 1, 6);
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
            lblTieuDe.ForeColor = Color.DodgerBlue;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Đăng ký tài khoản";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.Anchor = AnchorStyles.Left;
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.TabIndex = 1;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Địa chỉ email";
            // 
            // lblMatKhau
            // 
            lblMatKhau.Anchor = AnchorStyles.Left;
            lblMatKhau.AutoSize = true;
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblXacNhan
            // 
            lblXacNhan.Anchor = AnchorStyles.Left;
            lblXacNhan.AutoSize = true;
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.TabIndex = 4;
            lblXacNhan.Text = "Xác nhận mật khẩu";
            // 
            // lblSao1, lblSao2, lblSao3
            // 
            lblSao1.Anchor = AnchorStyles.Left;
            lblSao1.AutoSize = true;
            lblSao1.Name = "lblSao1";
            lblSao1.TabIndex = 5;
            lblSao1.Text = "(*)";
            lblSao2.Anchor = AnchorStyles.Left;
            lblSao2.AutoSize = true;
            lblSao2.Name = "lblSao2";
            lblSao2.TabIndex = 6;
            lblSao2.Text = "(*)";
            lblSao3.Anchor = AnchorStyles.Left;
            lblSao3.AutoSize = true;
            lblSao3.Name = "lblSao3";
            lblSao3.TabIndex = 7;
            lblSao3.Text = "(*)";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenDangNhap.BorderStyle = BorderStyle.None;
            txtTenDangNhap.Margin = new Padding(6, 6, 6, 6);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.TabIndex = 0;
            txtTenDangNhap.Validating += txtBatBuoc_Validating;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Margin = new Padding(6, 6, 6, 6);
            txtEmail.Name = "txtEmail";
            txtEmail.TabIndex = 1;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMatKhau.BorderStyle = BorderStyle.None;
            txtMatKhau.Margin = new Padding(6, 6, 6, 6);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.Validating += txtMatKhau_Validating;
            // 
            // txtXacNhan
            // 
            txtXacNhan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtXacNhan.BorderStyle = BorderStyle.None;
            txtXacNhan.Margin = new Padding(6, 6, 6, 6);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.TabIndex = 3;
            txtXacNhan.UseSystemPasswordChar = true;
            txtXacNhan.Validating += txtXacNhan_Validating;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.Anchor = AnchorStyles.Left;
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Margin = new Padding(6, 3, 3, 3);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 4;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnDangKy
            // 
            btnDangKy.Dock = DockStyle.Fill;
            btnDangKy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangKy.ForeColor = Color.DodgerBlue;
            btnDangKy.Margin = new Padding(6, 10, 6, 10);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.TabIndex = 4;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // Form2
            // 
            AcceptButton = btnDangKy;      // Enter = Đăng ký
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 380);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;             // để bắt phím Esc ở mức Form
            MinimumSize = new Size(518, 427);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private Label lblTenDangNhap;
        private Label lblEmail;
        private Label lblMatKhau;
        private Label lblXacNhan;
        private Label lblSao1;
        private Label lblSao2;
        private Label lblSao3;
        private TextBox txtTenDangNhap;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private TextBox txtXacNhan;
        private CheckBox chkHienMatKhau;
        private Button btnDangKy;
    }
}