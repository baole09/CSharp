namespace bai1
{
    public partial class Form1
    {
        private static readonly Color MauNut = Color.LightSkyBlue;                  // nền nút khi focus
        private static readonly Color MauVienThuong = Color.FromArgb(150, 165, 185); // viền ô nhập bình thường
        private static readonly Color MauVienChon = Color.DodgerBlue;               // viền ô nhập khi focus
        private static readonly Color MauVienKetQua = Color.ForestGreen;  // viền khi có kết quả
        private static readonly Color MauNenKetQua = Color.Honeydew;      // nền khi có kết quả
        private TextBox? _oDangChon;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GanHieuUngFocus(this);

            tableLayoutPanel1.Paint += VeVienOnhap;
            tableLayoutPanel1.Resize += (s, ev) => tableLayoutPanel1.Invalidate();
            txtKetQua.TextChanged += TxtKetQua_TextChanged;   // <-- thêm dòng này
        }

        private void GanHieuUngFocus(Control cha)
        {
            foreach (Control c in cha.Controls)
            {
                if (c is Button)
                {
                    c.Enter += BatMauNut;
                    c.Leave += TatMauNut;
                }
                else if (c is TextBox)
                {
                    c.Enter += BatVien;
                    c.Leave += TatVien;
                }

                if (c.HasChildren)
                    GanHieuUngFocus(c);
            }
        }
        private void TxtKetQua_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKetQua.Text))
                txtKetQua.ResetBackColor();
            else
                txtKetQua.BackColor = MauNenKetQua;

            tableLayoutPanel1.Invalidate();
        }
                // ===== NÚT: đổi màu nền =====
        private void BatMauNut(object? sender, EventArgs e)
        {
            var b = (Button)sender!;
            b.UseVisualStyleBackColor = false;
            b.BackColor = MauNut;
        }

        private void TatMauNut(object? sender, EventArgs e)
        {
            var b = (Button)sender!;
            b.ResetBackColor();
            b.UseVisualStyleBackColor = true;
        }

        // ===== Ô NHẬP: tự vẽ viền =====
        private void BatVien(object? sender, EventArgs e)
        {
            _oDangChon = (TextBox)sender!;
            tableLayoutPanel1.Invalidate();
        }

        private void TatVien(object? sender, EventArgs e)
        {
            if (_oDangChon == sender)
                _oDangChon = null;
            tableLayoutPanel1.Invalidate();
        }

        private void VeVienOnhap(object? sender, PaintEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is not TextBox t) continue;

                bool dangChon = t == _oDangChon;
                bool coKetQua = t == txtKetQua && !string.IsNullOrEmpty(t.Text);

                Rectangle r = t.Bounds;
                r.Inflate(3, 3);
                r.Width -= 1;
                r.Height -= 1;

                using var nen = new SolidBrush(t.BackColor);
                e.Graphics.FillRectangle(nen, r);

                Color mau = coKetQua ? MauVienKetQua
                        : dangChon ? MauVienChon
                        : MauVienThuong;
                float doDay = (coKetQua || dangChon) ? 2 : 1;

                using var pen = new Pen(mau, doDay);
                e.Graphics.DrawRectangle(pen, r);
            }
        }
    }
}