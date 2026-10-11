namespace btvn
{
    public partial class Form1
    {
        private static readonly Color MauNut = Color.LightSkyBlue;                   // nền nút khi focus
        private static readonly Color MauVienThuong = Color.FromArgb(150, 165, 185); // viền bình thường
        private static readonly Color MauVienChon = Color.DodgerBlue;                // viền khi focus
        private static readonly Color MauVienLoi = Color.Red;                        // viền khi lỗi

        private TextBox? _oDangChon;
        private readonly HashSet<TextBox> _oLoi = new();
        private readonly ToolTip _tip = new();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GanHieuUngFocus(this);
        }

        // Đặt/xóa trạng thái lỗi. msg rỗng = hết lỗi
        private void DatLoi(TextBox t, string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                _oLoi.Remove(t);
                _tip.SetToolTip(t, "");
            }
            else
            {
                _oLoi.Add(t);
                _tip.SetToolTip(t, msg);   // rê chuột vào ô để xem lý do
            }
            t.Parent?.Invalidate();
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
                else if (c is TableLayoutPanel tlp)
                {
                    tlp.Paint += VeVienOnhap;
                    tlp.Resize += (s, ev) => tlp.Invalidate();
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

        // ===== Ô NHẬP: tự vẽ viền =====
        private void BatVien(object? sender, EventArgs e)
        {
            _oDangChon = (TextBox)sender!;
            _oDangChon.Parent?.Invalidate();
        }

        private void TatVien(object? sender, EventArgs e)
        {
            var t = (TextBox)sender!;
            if (_oDangChon == t)
                _oDangChon = null;
            t.Parent?.Invalidate();
        }

        private void VeVienOnhap(object? sender, PaintEventArgs e)
        {
            var tlp = (TableLayoutPanel)sender!;

            foreach (Control c in tlp.Controls)
            {
                if (c is not TextBox t) continue;

                bool loi = _oLoi.Contains(t);
                bool dangChon = t == _oDangChon;

                Rectangle r = t.Bounds;
                r.Inflate(3, 3);
                r.Width -= 1;
                r.Height -= 1;

                Color mauNen = t.Enabled ? t.BackColor : SystemColors.Control;
                using var nen = new SolidBrush(mauNen);
                e.Graphics.FillRectangle(nen, r);

                Color mau = !t.Enabled ? Color.Silver
                          : loi ? MauVienLoi
                          : dangChon ? MauVienChon
                          : MauVienThuong;
                float doDay = (t.Enabled && (loi || dangChon)) ? 2 : 1;

                using var pen = new Pen(mau, doDay);
                e.Graphics.DrawRectangle(pen, r);
            }
        }
    }
}