namespace BTVN_Tuan5
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // ===== Mở một form con trong form chính (mỗi form chỉ mở một cửa sổ) =====
        private void MoForm<T>() where T : Form, new()
        {
            // Form đã mở rồi thì đưa lên trước, không mở thêm bản thứ hai
            var dangMo = MdiChildren.OfType<T>().FirstOrDefault();
            if (dangMo != null)
            {
                if (dangMo.WindowState == FormWindowState.Minimized)
                    dangMo.WindowState = FormWindowState.Normal;
                dangMo.Activate();
                return;
            }

            // MdiParent = this để form hiện bên trong form chính; đặt vị trí giữa vùng làm việc
            var f = new T { MdiParent = this, StartPosition = FormStartPosition.Manual };
            foreach (var menu in f.Controls.OfType<MenuStrip>())
                menu.AllowMerge = false;
            var vung = Controls.OfType<MdiClient>().First().ClientSize;
            f.Location = new Point(Math.Max(0, (vung.Width - f.Width) / 2),
                                   Math.Max(0, (vung.Height - f.Height) / 2));
            f.Show();
        }

        // ===== Đóng tất cả form con =====
        private void mnuDongTatCa_Click(object? sender, EventArgs e)
        {
            foreach (var f in MdiChildren.ToList())
                f.Close();
        }

        // ===== Thoát =====
        private void mnuThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua frmMain_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng form chính: mục Thoát, nút X, Alt+F4 =====
        private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
