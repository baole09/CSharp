namespace nangcao
{
    public partial class Form1
    {
        private static readonly Color MauNut = Color.LightSkyBlue;   // nền nút khi focus

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GanHieuUngFocus(this);
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

                if (c.HasChildren)
                    GanHieuUngFocus(c);
            }
        }

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
    }
}