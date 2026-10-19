namespace nangcao
{
    // Form "Nhập học viên mới". Khi bấm Cập nhật, gọi hàm _them(hoTen, lop) của form chính.
    internal class FormNhap : Form
    {
        private readonly Action<string, string> _them;

        private readonly TextBox txtHoTen = new();
        private readonly ComboBox cboLop = new();
        private readonly Button btnCapNhat = new();
        private readonly Button btnTroVe = new();

        public FormNhap(Action<string, string> them)
        {
            _them = them;

            // ----- thuộc tính form -----
            AcceptButton = btnCapNhat;     // Enter = Cập nhật
            CancelButton = btnTroVe;       // Esc = Trở về
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập học viên mới";

            // ----- control -----
            var lblHoTen = new Label { Text = "Họ và Tên", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblLop = new Label { Text = "Lớp", AutoSize = true, Anchor = AnchorStyles.Left };

            txtHoTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtHoTen.Margin = new Padding(3, 6, 3, 6);

            cboLop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            cboLop.Margin = new Padding(3, 6, 3, 6);
            cboLop.SelectedIndex = 0;

            btnCapNhat.Dock = DockStyle.Fill;
            btnCapNhat.Margin = new Padding(10, 8, 10, 8);
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;

            btnTroVe.Dock = DockStyle.Fill;
            btnTroVe.Margin = new Padding(10, 8, 10, 8);
            btnTroVe.Text = "Trở về";
            btnTroVe.UseVisualStyleBackColor = true;
            btnTroVe.Click += btnTroVe_Click;

            // ----- bố cục: 2 cột (nhãn, ô nhập) × 3 hàng -----
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(16, 12, 16, 12)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 28F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 28F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 44F));

            var tlpNut = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            tlpNut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpNut.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpNut.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpNut.Controls.Add(btnCapNhat, 0, 0);
            tlpNut.Controls.Add(btnTroVe, 1, 0);

            tlp.Controls.Add(lblHoTen, 0, 0);
            tlp.Controls.Add(txtHoTen, 1, 0);
            tlp.Controls.Add(lblLop, 0, 1);
            tlp.Controls.Add(cboLop, 1, 1);
            tlp.Controls.Add(tlpNut, 0, 2);
            tlp.SetColumnSpan(tlpNut, 2);

            Controls.Add(tlp);
            ActiveControl = txtHoTen;
        }

        // ===== Cập nhật: thêm họ tên vào listbox của lớp đã chọn trên form chính =====
        private void btnCapNhat_Click(object? sender, EventArgs e)
        {
            string hoTen = string.Join(" ", txtHoTen.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            if (hoTen.Length == 0)
            {
                MessageBox.Show("Hãy nhập họ tên học viên.", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();       // đặt con trỏ vào ô Họ và Tên
                return;
            }

            _them(hoTen, (string)cboLop.SelectedItem!);

            txtHoTen.Clear();           // để nhập tiếp học viên khác
            txtHoTen.Focus();
        }

        // ===== Trở về: đóng form nhập, về form chính =====
        private void btnTroVe_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}