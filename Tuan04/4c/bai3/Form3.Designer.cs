namespace bai3
{
    partial class Form3
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
            lblA = new Label();
            lblB = new Label();
            lblUCLN = new Label();
            lblBCNN = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtUCLN = new TextBox();
            txtBCNN = new TextBox();
            btnThucHien = new Button();
            btnTiepTuc = new Button();
            btnThoat = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            // hàng 0: tiêu đề
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblTieuDe, 3);
            // hàng 1-4: nhãn + ô
            tableLayoutPanel1.Controls.Add(lblA, 0, 1);
            tableLayoutPanel1.Controls.Add(txtA, 1, 1);
            tableLayoutPanel1.SetColumnSpan(txtA, 2);
            tableLayoutPanel1.Controls.Add(lblB, 0, 2);
            tableLayoutPanel1.Controls.Add(txtB, 1, 2);
            tableLayoutPanel1.SetColumnSpan(txtB, 2);
            tableLayoutPanel1.Controls.Add(lblUCLN, 0, 3);
            tableLayoutPanel1.Controls.Add(txtUCLN, 1, 3);
            tableLayoutPanel1.SetColumnSpan(txtUCLN, 2);
            tableLayoutPanel1.Controls.Add(lblBCNN, 0, 4);
            tableLayoutPanel1.Controls.Add(txtBCNN, 1, 4);
            tableLayoutPanel1.SetColumnSpan(txtBCNN, 2);
            // hàng 5: 3 nút
            tableLayoutPanel1.Controls.Add(btnThucHien, 0, 5);
            tableLayoutPanel1.Controls.Add(btnTiepTuc, 1, 5);
            tableLayoutPanel1.Controls.Add(btnThoat, 2, 5);
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
            lblTieuDe.Text = "Ước Số Chung - Bội Số Chung";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblA
            // 
            lblA.Anchor = AnchorStyles.Left;
            lblA.AutoSize = true;
            lblA.Name = "lblA";
            lblA.TabIndex = 1;
            lblA.Text = "Nhập số a :";
            // 
            // lblB
            // 
            lblB.Anchor = AnchorStyles.Left;
            lblB.AutoSize = true;
            lblB.Name = "lblB";
            lblB.TabIndex = 2;
            lblB.Text = "Nhập số b :";
            // 
            // lblUCLN
            // 
            lblUCLN.Anchor = AnchorStyles.Left;
            lblUCLN.AutoSize = true;
            lblUCLN.Name = "lblUCLN";
            lblUCLN.TabIndex = 3;
            lblUCLN.Text = "Ước số chung lớn nhất :";
            // 
            // lblBCNN
            // 
            lblBCNN.Anchor = AnchorStyles.Left;
            lblBCNN.AutoSize = true;
            lblBCNN.Name = "lblBCNN";
            lblBCNN.TabIndex = 4;
            lblBCNN.Text = "Bội số chung nhỏ nhất :";
            // 
            // txtA
            // 
            txtA.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtA.BorderStyle = BorderStyle.None;
            txtA.MaxLength = 9;
            txtA.Margin = new Padding(6);
            txtA.Name = "txtA";
            txtA.TabIndex = 0;
            txtA.KeyPress += txtSo_KeyPress;
            txtA.Validating += txtSo_Validating;
            // 
            // txtB
            // 
            txtB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtB.BorderStyle = BorderStyle.None;
            txtB.MaxLength = 9;
            txtB.Margin = new Padding(6);
            txtB.Name = "txtB";
            txtB.TabIndex = 1;
            txtB.KeyPress += txtSo_KeyPress;
            txtB.Validating += txtSo_Validating;
            // 
            // txtUCLN
            // 
            txtUCLN.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUCLN.BorderStyle = BorderStyle.None;
            txtUCLN.Margin = new Padding(6);
            txtUCLN.Name = "txtUCLN";
            txtUCLN.ReadOnly = true;
            txtUCLN.TabIndex = 5;
            txtUCLN.TabStop = false;
            // 
            // txtBCNN
            // 
            txtBCNN.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBCNN.BorderStyle = BorderStyle.None;
            txtBCNN.Margin = new Padding(6);
            txtBCNN.Name = "txtBCNN";
            txtBCNN.ReadOnly = true;
            txtBCNN.TabIndex = 6;
            txtBCNN.TabStop = false;
            // 
            // btnThucHien
            // 
            btnThucHien.Dock = DockStyle.Fill;
            btnThucHien.Margin = new Padding(6, 10, 6, 10);
            btnThucHien.Name = "btnThucHien";
            btnThucHien.TabIndex = 2;
            btnThucHien.Text = "Thực Hiện";
            btnThucHien.UseVisualStyleBackColor = true;
            btnThucHien.Click += btnThucHien_Click;
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
            // Form3
            // 
            AcceptButton = btnThucHien;    // Enter = Thực Hiện
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;       // Esc = Thoát
            ClientSize = new Size(520, 360);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(538, 407);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ước Số - Bội Số";
            FormClosing += Form3_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private Label lblA;
        private Label lblB;
        private Label lblUCLN;
        private Label lblBCNN;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtUCLN;
        private TextBox txtBCNN;
        private Button btnThucHien;
        private Button btnTiepTuc;
        private Button btnThoat;
    }
}