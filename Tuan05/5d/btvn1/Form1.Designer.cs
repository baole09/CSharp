namespace btvn1
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
            SuspendLayout();

            // ----- bảng bố cục -----
            tableLayoutPanel1 = new TableLayoutPanel
            {
                Name = "tableLayoutPanel1",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(12, 8, 12, 12)
            };
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));

            // ----- nhãn hiển thị thời gian -----
            lblThoiGian = new Label();
            lblThoiGian.Dock = DockStyle.Fill;
            lblThoiGian.Font = new Font("Consolas", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Text = "30:00";
            lblThoiGian.TextAlign = ContentAlignment.MiddleCenter;

            // ----- nút Bắt đầu / Tạm dừng / Tiếp tục -----
            btnBatDau = new Button();
            btnBatDau.Dock = DockStyle.Fill;
            btnBatDau.Margin = new Padding(40, 6, 40, 6);
            btnBatDau.Name = "btnBatDau";
            btnBatDau.Text = "Bắt đầu";
            btnBatDau.UseVisualStyleBackColor = true;
            btnBatDau.Click += btnBatDau_Click;

            // ----- bộ định thời -----
            timer1 = new System.Windows.Forms.Timer(components);
            timer1.Interval = 200;           // kiểm tra 5 lần mỗi giây để hiển thị đúng giây
            timer1.Tick += timer1_Tick;

            tableLayoutPanel1.Controls.Add(lblThoiGian, 0, 0);
            tableLayoutPanel1.Controls.Add(btnBatDau, 0, 1);

            // 
            // Form1
            // 
            AcceptButton = btnBatDau;        // Enter = Bắt đầu / Tạm dừng / Tiếp tục
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 170);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(260, 170);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đồng hồ";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblThoiGian;
        private Button btnBatDau;
        private System.Windows.Forms.Timer timer1;
    }
}