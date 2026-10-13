namespace btvn3
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
            tableLayoutPanel1 = TaoBang("tableLayoutPanel1", new[] { 40F, 60F }, new[] { 100F });
            tlpPhai = TaoBang("tlpPhai", new[] { 36F, 64F }, new[] { 13F, 13F, 14F, 20F, 14F, 26F });

            // ----- khởi tạo control -----
            tvDanhBa = new TreeView();
            lblFirstName = new Label(); lblLastName = new Label();
            txtFirstName = new TextBox(); txtLastName = new TextBox();
            btnAdd = new Button(); btnExit = new Button();

            // ----- TreeView danh bạ -----
            tvDanhBa.Dock = DockStyle.Fill;
            tvDanhBa.HideSelection = false;
            tvDanhBa.Margin = new Padding(6);
            tvDanhBa.Name = "tvDanhBa";

            // ----- nhãn và ô nhập -----
            Nhan(lblFirstName, "lblFirstName", "First Name");
            Nhan(lblLastName, "lblLastName", "Last Name");
            NhapChu(txtFirstName, "txtFirstName");
            NhapChu(txtLastName, "txtLastName");

            // ----- nút -----
            Nut(btnAdd, "btnAdd", "Add");
            Nut(btnExit, "btnExit", "Exit");
            btnAdd.Click += btnAdd_Click;
            btnExit.Click += btnExit_Click;

            // ----- ghép -----
            tlpPhai.Controls.Add(lblFirstName, 0, 0);
            tlpPhai.Controls.Add(txtFirstName, 1, 0);
            tlpPhai.Controls.Add(lblLastName, 0, 1);
            tlpPhai.Controls.Add(txtLastName, 1, 1);
            tlpPhai.Controls.Add(btnAdd, 1, 2);
            tlpPhai.Controls.Add(btnExit, 1, 4);

            tableLayoutPanel1.Controls.Add(tvDanhBa, 0, 0);
            tableLayoutPanel1.Controls.Add(tlpPhai, 1, 0);
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);

            // 
            // Form1
            // 
            AcceptButton = btnAdd;           // Enter = Add
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;          // Esc = Exit
            ClientSize = new Size(560, 420);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(578, 467);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBTVN2";
            Load += Form1_Load;
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

        private void NhapChu(TextBox t, string ten)
        {
            t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t.BorderStyle = BorderStyle.None;
            t.Margin = new Padding(6, 4, 6, 4);
            t.MaxLength = 50;
            t.Name = ten;
            t.TextChanged += txt_TextChanged;
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
        private TableLayoutPanel tlpPhai;

        private TreeView tvDanhBa;
        private Label lblFirstName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnAdd;
        private Button btnExit;
    }
}