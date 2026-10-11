namespace nangcao
{
    public partial class Form1
    {
        private static readonly Color MauNut = Color.LightSkyBlue;                   // nền nút khi focus
        private static readonly Color MauVienThuong = Color.FromArgb(150, 165, 185); // viền ô thành tiền

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GanHieuUngFocus(this);

            tableLayoutPanel1.Paint += VeVienThanhTien;
            tableLayoutPanel1.Resize += (s, ev) => tableLayoutPanel1.Invalidate();
        }

        private void GanHieuUngFocus(Control cha)
        {
            foreach (Control c in cha.Controls)
            {
                // Bỏ qua các nút ghế: chúng tự quản lý màu theo trạng thái
                if (c is Button && (c.Tag as string) != "ghe")
                {
                    c.Enter += BatMauNut;
                    c.Leave += TatMauNut;
                }

                if (c.HasChildren)
                    GanHieuUngFocus(c);
            }
        }

        // ===== NÚT: đổi màu nền khi focus =====
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

        // ===== Ô THÀNH TIỀN: tự vẽ viền =====
        private void VeVienThanhTien(object? sender, PaintEventArgs e)
        {
            Rectangle r = txtThanhTien.Bounds;
            r.Inflate(3, 3);
            r.Width -= 1;
            r.Height -= 1;

            using var nen = new SolidBrush(txtThanhTien.BackColor);
            e.Graphics.FillRectangle(nen, r);

            using var pen = new Pen(MauVienThuong, 1);
            e.Graphics.DrawRectangle(pen, r);
        }
    }
}