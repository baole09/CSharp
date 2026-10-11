namespace bai5
{
    partial class Form5
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
            txtSo = new TextBox();
            btnThucHien = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtKetQua = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));
            // hàng 0: tiêu đề
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblTieuDe, 3);
            // hàng 1: nhãn + ô nhập
            tableLayoutPanel1.Controls.Add(lblNhapSo, 0, 1);
            tableLayoutPanel1.SetColumnSpan(lblNhapSo, 2);
            tableLayoutPanel1.Controls.Add(txtSo, 2, 1);
            // hàng 2: 3 nút
            tableLayoutPanel1.Controls.Add(btnThucHien, 0, 2);
            tableLayoutPanel1.Controls.Add(btnXoa, 1, 2);
            tableLayoutPanel1.Controls.Add(btnThoat, 2, 2);
            // hàng 3: kết quả
            tableLayoutPanel1.Controls.Add(txtKetQua, 0, 3);
            tableLayoutPanel1.SetColumnSpan(txtKetQua, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.Red;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Đọc Số Thành Chữ";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNhapSo
            // 
            lblNhapSo.Anchor = AnchorStyles.Left;
            lblNhapSo.AutoSize = true;
            lblNhapSo.Name = "lblNhapSo";
            lblNhapSo.TabIndex = 1;
            lblNhapSo.Text = "Nhập dãy số : ( từ 1 đến 999 )";
            // 
            // txtSo
            // 
            txtSo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSo.BorderStyle = BorderStyle.None;
            txtSo.MaxLength = 9;
            txtSo.Margin = new Padding(6);
            txtSo.Name = "txtSo";
            txtSo.TabIndex = 0;
            txtSo.TextChanged += txtSo_TextChanged;
            txtSo.KeyPress += txtSo_KeyPress;
            txtSo.Validating += txtSo_Validating;
            // 
            // btnThucHien
            // 
            btnThucHien.Dock = DockStyle.Fill;
            btnThucHien.Margin = new Padding(6, 6, 6, 6);
            btnThucHien.Name = "btnThucHien";
            btnThucHien.TabIndex = 1;
            btnThucHien.Text = "Thực hiện";
            btnThucHien.UseVisualStyleBackColor = true;
            btnThucHien.Click += btnThucHien_Click;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.Margin = new Padding(6, 6, 6, 6);
            btnXoa.Name = "btnXoa";
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Fill;
            btnThoat.Margin = new Padding(6, 6, 6, 6);
            btnThoat.Name = "btnThoat";
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtKetQua
            // 
            txtKetQua.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtKetQua.BackColor = Color.PeachPuff;
            txtKetQua.BorderStyle = BorderStyle.None;
            txtKetQua.ForeColor = Color.Blue;
            txtKetQua.Margin = new Padding(6);
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.TabIndex = 4;
            txtKetQua.TabStop = false;
            // 
            // Form5
            // 
            AcceptButton = btnThucHien;    // Enter = Thực hiện
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;       // Esc = Thoát
            ClientSize = new Size(520, 300);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(538, 347);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anh Bảo - Đọc Chữ Số";
            FormClosing += Form5_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private Label lblNhapSo;
        private TextBox txtSo;
        private Button btnThucHien;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtKetQua;
    }
}