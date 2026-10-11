namespace btvn
{
    public partial class Form1
    {
        private static readonly Color MauNhan = Color.LightSkyBlue;   // nền phím khi đang nhấn

        // Phím không nhận focus nên đổi màu theo thao tác chuột
        private void GanHieuUngNhan(Button b)
        {
            b.MouseDown += (s, e) =>
            {
                b.UseVisualStyleBackColor = false;   // bắt buộc để BackColor có tác dụng
                b.BackColor = MauNhan;
            };
            b.MouseUp += (s, e) => KhoiPhuc(b);
            b.MouseLeave += (s, e) => KhoiPhuc(b);
        }

        private static void KhoiPhuc(Button b)
        {
            b.ResetBackColor();
            b.UseVisualStyleBackColor = true;
        }
    }
}