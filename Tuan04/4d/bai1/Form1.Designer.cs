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
            tableLayoutPanel1 = new TableLayoutPanel();
            lbltitle = new Label();
            grpChon = new GroupBox();
            tlpChon = new TableLayoutPanel();
            radioButton_bacnhat = new RadioButton();
            radioButton_bachai = new RadioButton();
            Ta = new Label();
            Tb = new Label();
            Tc = new Label();
            Tketqua = new Label();
            Inputa = new TextBox();
            Inputb = new TextBox();
            Inputc = new TextBox();
            Outputketqua = new TextBox();
            button_giai = new Button();
            button_thoat = new Button();
            tableLayoutPanel1.SuspendLayout();
            grpChon.SuspendLayout();
            tlpChon.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));  // 0 tiêu đề
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26F));  // 1 nhóm radio
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));  // 2 a
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));  // 3 b
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));  // 4 c
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));  // 5 kết quả
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));  // 6 phần dư
            tableLayoutPanel1.Controls.Add(lbltitle, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lbltitle, 3);
            tableLayoutPanel1.Controls.Add(grpChon, 0, 1);
            tableLayoutPanel1.SetColumnSpan(grpChon, 3);
            tableLayoutPanel1.Controls.Add(Ta, 0, 2);
            tableLayoutPanel1.Controls.Add(Inputa, 1, 2);
            tableLayoutPanel1.Controls.Add(button_giai, 2, 2);
            tableLayoutPanel1.Controls.Add(Tb, 0, 3);
            tableLayoutPanel1.Controls.Add(Inputb, 1, 3);
            tableLayoutPanel1.Controls.Add(button_thoat, 2, 3);
            tableLayoutPanel1.Controls.Add(Tc, 0, 4);
            tableLayoutPanel1.Controls.Add(Inputc, 1, 4);
            tableLayoutPanel1.Controls.Add(Tketqua, 0, 5);
            tableLayoutPanel1.Controls.Add(Outputketqua, 1, 5);
            tableLayoutPanel1.SetColumnSpan(Outputketqua, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12, 8, 12, 8);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lbltitle
            // 
            lbltitle.Dock = DockStyle.Fill;
            lbltitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitle.ForeColor = Color.Red;
            lbltitle.Name = "lbltitle";
            lbltitle.TabIndex = 0;
            lbltitle.Text = "GIẢI PHƯƠNG TRÌNH";
            lbltitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpChon
            // 
            grpChon.Controls.Add(tlpChon);
            grpChon.Dock = DockStyle.Fill;
            grpChon.Margin = new Padding(6);
            grpChon.Name = "grpChon";
            grpChon.TabIndex = 1;
            grpChon.TabStop = false;
            grpChon.Text = "Bạn vui lòng chọn";
            // 
            // tlpChon
            // 
            tlpChon.ColumnCount = 1;
            tlpChon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpChon.RowCount = 2;
            tlpChon.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpChon.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpChon.Controls.Add(radioButton_bacnhat, 0, 0);
            tlpChon.Controls.Add(radioButton_bachai, 0, 1);
            tlpChon.Dock = DockStyle.Fill;
            tlpChon.Name = "tlpChon";
            tlpChon.TabIndex = 0;
            // 
            // radioButton_bacnhat
            // 
            radioButton_bacnhat.Anchor = AnchorStyles.Left;
            radioButton_bacnhat.AutoSize = true;
            radioButton_bacnhat.Margin = new Padding(30, 3, 3, 3);
            radioButton_bacnhat.Name = "radioButton_bacnhat";
            radioButton_bacnhat.TabIndex = 0;
            radioButton_bacnhat.Text = "Phương trình bậc nhất";
            radioButton_bacnhat.UseVisualStyleBackColor = true;
            radioButton_bacnhat.CheckedChanged += radiobutton_bacnhat_CheckedChanged;
            // 
            // radioButton_bachai
            // 
            radioButton_bachai.Anchor = AnchorStyles.Left;
            radioButton_bachai.AutoSize = true;
            radioButton_bachai.Margin = new Padding(30, 3, 3, 3);
            radioButton_bachai.Name = "radioButton_bachai";
            radioButton_bachai.TabIndex = 1;
            radioButton_bachai.Text = "Phương trình bậc hai";
            radioButton_bachai.UseVisualStyleBackColor = true;
            radioButton_bachai.CheckedChanged += radiobutton_bachai_CheckedChanged;
            // 
            // Ta
            // 
            Ta.Anchor = AnchorStyles.Left;
            Ta.AutoSize = true;
            Ta.Name = "Ta";
            Ta.TabIndex = 2;
            Ta.Text = "Nhập a";
            // 
            // Tb
            // 
            Tb.Anchor = AnchorStyles.Left;
            Tb.AutoSize = true;
            Tb.Name = "Tb";
            Tb.TabIndex = 3;
            Tb.Text = "Nhập b";
            // 
            // Tc
            // 
            Tc.Anchor = AnchorStyles.Left;
            Tc.AutoSize = true;
            Tc.Name = "Tc";
            Tc.TabIndex = 4;
            Tc.Text = "Nhập c";
            // 
            // Tketqua
            // 
            Tketqua.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Tketqua.AutoSize = true;
            Tketqua.Margin = new Padding(3, 12, 3, 0);
            Tketqua.Name = "Tketqua";
            Tketqua.TabIndex = 5;
            Tketqua.Text = "Kết quả";
            // 
            // Inputa
            // 
            Inputa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Inputa.BorderStyle = BorderStyle.None;
            Inputa.Margin = new Padding(6);
            Inputa.Name = "Inputa";
            Inputa.TabIndex = 0;
            Inputa.TextAlign = HorizontalAlignment.Right;
            Inputa.TextChanged += txtDuLieu_TextChanged;
            Inputa.KeyPress += txtDuLieu_KeyPress;
            // 
            // Inputb
            // 
            Inputb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Inputb.BorderStyle = BorderStyle.None;
            Inputb.Margin = new Padding(6);
            Inputb.Name = "Inputb";
            Inputb.TabIndex = 1;
            Inputb.TextAlign = HorizontalAlignment.Right;
            Inputb.TextChanged += txtDuLieu_TextChanged;
            Inputb.KeyPress += txtDuLieu_KeyPress;
            // 
            // Inputc
            // 
            Inputc.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Inputc.BorderStyle = BorderStyle.None;
            Inputc.Margin = new Padding(6);
            Inputc.Name = "Inputc";
            Inputc.TabIndex = 2;
            Inputc.TextAlign = HorizontalAlignment.Right;
            Inputc.TextChanged += txtDuLieu_TextChanged;
            Inputc.KeyPress += txtDuLieu_KeyPress;
            // 
            // Outputketqua
            // 
            Outputketqua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Outputketqua.BorderStyle = BorderStyle.None;
            Outputketqua.ForeColor = Color.DimGray;
            Outputketqua.Margin = new Padding(6);
            Outputketqua.Multiline = true;
            Outputketqua.Name = "Outputketqua";
            Outputketqua.ReadOnly = true;
            Outputketqua.TabIndex = 5;
            Outputketqua.TabStop = false;
            // 
            // button_giai
            // 
            button_giai.Dock = DockStyle.Fill;
            button_giai.Margin = new Padding(12, 6, 6, 6);
            button_giai.Name = "button_giai";
            button_giai.TabIndex = 3;
            button_giai.Text = "Giải";
            button_giai.UseVisualStyleBackColor = true;
            button_giai.Click += button_giai_Click;
            // 
            // button_thoat
            // 
            button_thoat.Dock = DockStyle.Fill;
            button_thoat.Margin = new Padding(12, 6, 6, 6);
            button_thoat.Name = "button_thoat";
            button_thoat.TabIndex = 4;
            button_thoat.Text = "Thoát";
            button_thoat.UseVisualStyleBackColor = true;
            button_thoat.Click += button_thoat_Click;
            // 
            // Form1
            // 
            AcceptButton = button_giai;     // Enter = Giải
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_thoat;    // Esc = Thoát
            ClientSize = new Size(400, 520);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(418, 567);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giải phương trình bậc 1-2";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tlpChon.ResumeLayout(false);
            tlpChon.PerformLayout();
            grpChon.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lbltitle;
        private GroupBox grpChon;
        private TableLayoutPanel tlpChon;
        private RadioButton radioButton_bacnhat;
        private RadioButton radioButton_bachai;
        private Label Ta;
        private Label Tb;
        private Label Tc;
        private Label Tketqua;
        private TextBox Inputa;
        private TextBox Inputb;
        private TextBox Inputc;
        private TextBox Outputketqua;
        private Button button_giai;
        private Button button_thoat;
    }
}