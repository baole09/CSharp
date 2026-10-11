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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTieuDe = new Label();
            lblManHinh = new Label();
            tlpPhim = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tlpPhim.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69F));
            tableLayoutPanel1.Controls.Add(lblTieuDe, 0, 0);
            tableLayoutPanel1.Controls.Add(lblManHinh, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpPhim, 0, 2);
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
            lblTieuDe.Text = "Máy Tính Bỏ Túi";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblManHinh
            // 
            lblManHinh.BackColor = Color.White;
            lblManHinh.BorderStyle = BorderStyle.FixedSingle;
            lblManHinh.Dock = DockStyle.Fill;
            lblManHinh.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManHinh.ForeColor = Color.Blue;
            lblManHinh.Margin = new Padding(6);
            lblManHinh.Name = "lblManHinh";
            lblManHinh.TabIndex = 1;
            lblManHinh.Text = "0";
            lblManHinh.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tlpPhim  (16 phím được thêm bằng code trong Form1.cs)
            // 
            tlpPhim.ColumnCount = 4;
            for (int i = 0; i < 4; i++)
                tlpPhim.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPhim.RowCount = 4;
            for (int i = 0; i < 4; i++)
                tlpPhim.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpPhim.Dock = DockStyle.Fill;
            tlpPhim.Name = "tlpPhim";
            tlpPhim.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 460);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;             // để nhận phím gõ từ bàn phím
            MinimumSize = new Size(378, 507);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Máy Tính Bỏ Túi";
            KeyPress += Form1_KeyPress;
            tlpPhim.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTieuDe;
        private Label lblManHinh;
        private TableLayoutPanel tlpPhim;
    }
}