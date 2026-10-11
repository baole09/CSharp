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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblA = new Label();
            lblB = new Label();
            lblKetQua = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtKetQua = new TextBox();
            btnCong = new Button();
            btnTru = new Button();
            btnNhan = new Button();
            btnChia = new Button();
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            // hàng 0: a, b
            tableLayoutPanel1.Controls.Add(lblA, 0, 0);
            tableLayoutPanel1.Controls.Add(txtA, 1, 0);
            tableLayoutPanel1.Controls.Add(lblB, 2, 0);
            tableLayoutPanel1.Controls.Add(txtB, 3, 0);
            // hàng 1: kết quả
            tableLayoutPanel1.Controls.Add(lblKetQua, 0, 1);
            tableLayoutPanel1.Controls.Add(txtKetQua, 1, 1);
            tableLayoutPanel1.SetColumnSpan(txtKetQua, 3);
            // hàng 2: 4 nút
            tableLayoutPanel1.Controls.Add(btnCong, 0, 2);
            tableLayoutPanel1.Controls.Add(btnTru, 1, 2);
            tableLayoutPanel1.Controls.Add(btnNhan, 2, 2);
            tableLayoutPanel1.Controls.Add(btnChia, 3, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblA
            // 
            lblA.Anchor = AnchorStyles.Right;
            lblA.AutoSize = true;
            lblA.Name = "lblA";
            lblA.TabIndex = 0;
            lblA.Text = "a =";
            // 
            // txtA
            // 
            txtA.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtA.Margin = new Padding(3, 3, 26, 3);   // chừa chỗ cho icon ErrorProvider
            txtA.Name = "txtA";
            txtA.BorderStyle = BorderStyle.None;
            txtA.TabIndex = 1;
            txtA.KeyPress += txtSo_KeyPress;
            txtA.Validating += txtSo_Validating;
            // 
            // lblB
            // 
            lblB.Anchor = AnchorStyles.Right;
            lblB.AutoSize = true;
            lblB.Name = "lblB";
            lblB.TabIndex = 2;
            lblB.Text = "b =";
            // 
            // txtB
            // 
            txtB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtB.Margin = new Padding(3, 3, 26, 3);
            txtB.Name = "txtB";
            txtB.BorderStyle = BorderStyle.None;
            txtB.TabIndex = 3;
            txtB.KeyPress += txtSo_KeyPress;
            txtB.Validating += txtSo_Validating;
            // 
            // lblKetQua
            // 
            lblKetQua.Anchor = AnchorStyles.Right;
            lblKetQua.AutoSize = true;
            lblKetQua.Name = "lblKetQua";
            lblKetQua.TabIndex = 4;
            lblKetQua.Text = "Kết quả";
            // 
            // txtKetQua
            // 
            txtKetQua.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.TabIndex = 5;
            txtKetQua.TabStop = false;
            txtKetQua.BorderStyle = BorderStyle.None;
            // 
            // btnCong
            // 
            btnCong.Dock = DockStyle.Fill;
            btnCong.Margin = new Padding(6, 8, 6, 8);
            btnCong.Name = "btnCong";
            btnCong.TabIndex = 6;
            btnCong.Text = "+";
            btnCong.UseVisualStyleBackColor = true;
            btnCong.Click += btnPhepToan_Click;
            // 
            // btnTru
            // 
            btnTru.Dock = DockStyle.Fill;
            btnTru.Margin = new Padding(6, 8, 6, 8);
            btnTru.Name = "btnTru";
            btnTru.TabIndex = 7;
            btnTru.Text = "-";
            btnTru.UseVisualStyleBackColor = true;
            btnTru.Click += btnPhepToan_Click;
            // 
            // btnNhan
            // 
            btnNhan.Dock = DockStyle.Fill;
            btnNhan.Margin = new Padding(6, 8, 6, 8);
            btnNhan.Name = "btnNhan";
            btnNhan.TabIndex = 8;
            btnNhan.Text = "x";
            btnNhan.UseVisualStyleBackColor = true;
            btnNhan.Click += btnPhepToan_Click;
            // 
            // btnChia
            // 
            btnChia.Dock = DockStyle.Fill;
            btnChia.Margin = new Padding(6, 8, 6, 8);
            btnChia.Name = "btnChia";
            btnChia.TabIndex = 9;
            btnChia.Text = "/";
            btnChia.UseVisualStyleBackColor = true;
            btnChia.Click += btnPhepToan_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            errorProvider1.SetIconPadding(txtA, 6);
            errorProvider1.SetIconPadding(txtB, 6);
            // 
            // Form1
            // 
            AcceptButton = btnCong;        // Enter = phép cộng
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 175);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;             // để bắt phím Esc ở mức Form
            MinimumSize = new Size(498, 222);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cộng trừ nhân chia";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblA;
        private Label lblB;
        private Label lblKetQua;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtKetQua;
        private Button btnCong;
        private Button btnTru;
        private Button btnNhan;
        private Button btnChia;
        private ErrorProvider errorProvider1;
    }
}