namespace nangcao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== Form_Load: dữ liệu mẫu theo đề =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            lstLopA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            lstLopB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Ánh Minh", "Bảo Lâm" });
        }

        private void NhacChonHocVien(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===== Nhập học viên mới: mở form nhập =====
        private void mnuNhapMoi_Click(object? sender, EventArgs e)
        {
            using var f = new FormNhap(ThemHocVien);
            f.ShowDialog(this);
        }

        // Hàm form nhập gọi lại để thêm học viên vào đúng lớp
        private void ThemHocVien(string hoTen, string lop)
        {
            ListBox lst = lop == "Lớp A" ? lstLopA : lstLopB;

            lst.Items.Add(hoTen);
            lst.ClearSelected();
            lst.SelectedIndex = lst.Items.Count - 1;   // chọn và cuộn tới học viên vừa thêm
        }

        // ===== Chuyển các học viên đang chọn từ lớp này sang lớp kia =====
        private void ChuyenLop(ListBox nguon, ListBox dich, string tenLopNguon)
        {
            if (nguon.SelectedItems.Count == 0)
            {
                NhacChonHocVien($"Hãy chọn học viên trong {tenLopNguon} trước khi chuyển lớp.");
                return;
            }

            var chi = nguon.SelectedIndices.Cast<int>().OrderBy(i => i).ToList();
            var ten = chi.Select(i => nguon.Items[i]).ToList();   // giữ đúng thứ tự ban đầu

            nguon.BeginUpdate();
            foreach (int i in chi.OrderByDescending(i => i))      // xóa từ cuối lên để chỉ số không lệch
                nguon.Items.RemoveAt(i);
            nguon.EndUpdate();

            dich.Items.AddRange(ten.ToArray());
        }

        private void mnuChuyenB_Click(object? sender, EventArgs e)
        {
            // Chuyển các mục đang chọn trong Lớp A sang Lớp B
            ChuyenLop(lstLopA, lstLopB, "Lớp A");
        }

        private void mnuChuyenA_Click(object? sender, EventArgs e)
        {
            // Chuyển các mục đang chọn trong Lớp B sang Lớp A
            ChuyenLop(lstLopB, lstLopA, "Lớp B");
        }

        // ===== Xóa các học viên đang chọn ở cả Lớp A và Lớp B =====
        private void mnuXoa_Click(object? sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0 && lstLopB.SelectedItems.Count == 0)
            {
                NhacChonHocVien("Hãy chọn học viên cần xóa trước.");
                return;
            }

            foreach (var lst in new[] { lstLopA, lstLopB })
            {
                var chi = lst.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();

                lst.BeginUpdate();
                foreach (int i in chi)
                    lst.Items.RemoveAt(i);
                lst.EndUpdate();
            }
        }

        // ===== Kết thúc: đi qua Form1_FormClosing để hỏi xác nhận =====
        private void mnuKetThuc_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // ===== Hỏi xác nhận trước khi đóng form: mục Kết thúc, nút X, Alt+F4 =====
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
