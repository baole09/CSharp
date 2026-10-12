using System.Globalization;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== Nhập số: chỉ cho gõ chữ số =====
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSo_TextChanged(object? sender, EventArgs e)
        {
            DatLoi(txtSo, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Kiểm tra dữ liệu nhập: số nguyên dương =====
        private bool KiemTraSo(out int so, out string loi)
        {
            so = 0;
            loi = "";
            string s = txtSo.Text.Trim();

            if (s.Length == 0)
                loi = "Chưa nhập số.";
            else if (!int.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out so))
                loi = "Dữ liệu phải là số nguyên dương.";
            else if (so < 1)
                loi = "Số phải lớn hơn 0.";

            DatLoi(txtSo, loi);
            return loi.Length == 0;
        }

        // Rời ô: ô rỗng thì bỏ qua (chỉ báo lỗi khi bấm Cập nhật), có chữ thì kiểm tra
        private void txtSo_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSo.Text))
                DatLoi(txtSo, "");
            else
                KiemTraSo(out _, out _);
        }

        // ===== Cập nhật: thêm số vào combobox =====
        private void btnCapNhat_Click(object? sender, EventArgs e)
        {
            if (!KiemTraSo(out int so, out string loi))
            {
                MessageBox.Show(loi, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo.Focus();
                txtSo.SelectAll();
                return;
            }

            // Kiểm tra số đã có trong combobox chưa trước khi thêm
            if (cboSo.Items.Contains(so))
            {
                string msg = $"Số {so} đã có trong combobox.";
                DatLoi(txtSo, msg);
                MessageBox.Show(msg, "Trùng số", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSo.Focus();
                txtSo.SelectAll();
                return;
            }

            cboSo.Items.Add(so);
            txtSo.Clear();    // xóa dữ liệu trong ô nhập
            txtSo.Focus();    // đặt con trỏ lại ô nhập
        }

        // ===== Chọn một số trong combobox: liệt kê các ước số vào listbox =====
        private void cboSo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            lstUoc.Items.Clear();
            if (cboSo.SelectedItem is not int n) return;

            var ds = new List<int>();
            for (int i = 1; (long)i * i <= n; i++)
            {
                if (n % i != 0) continue;
                ds.Add(i);
                if (i != n / i) ds.Add(n / i);   // ước số đối ứng
            }
            ds.Sort();

            foreach (int u in ds)
                lstUoc.Items.Add(u);
        }

        // Lấy số đang chọn và danh sách ước số đang có trên listbox
        private bool CoDanhSach(out int so, out List<int> uoc)
        {
            so = 0;
            uoc = lstUoc.Items.Cast<int>().ToList();

            if (uoc.Count == 0 || cboSo.SelectedItem is not int)
            {
                MessageBox.Show("Chưa có danh sách ước số. Hãy chọn một số trong combobox.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            so = (int)cboSo.SelectedItem;
            return true;
        }

        private static bool LaNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; (long)i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        // ===== Tổng các ước số =====
        private void btnTongUoc_Click(object? sender, EventArgs e)
        {
            if (!CoDanhSach(out int so, out var uoc)) return;

            long tong = uoc.Sum(x => (long)x);
            MessageBox.Show($"Các ước số của {so}: {string.Join(", ", uoc)}\n\nTổng các ước số = {tong}",
                            "Tổng các ước số", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Số lượng các ước số chẵn =====
        private void btnUocChan_Click(object? sender, EventArgs e)
        {
            if (!CoDanhSach(out int so, out var uoc)) return;

            var chan = uoc.Where(x => x % 2 == 0).ToList();
            string chiTiet = chan.Count == 0 ? "(không có)" : string.Join(", ", chan);
            MessageBox.Show($"Các ước số của {so}: {string.Join(", ", uoc)}\n\n" +
                            $"Các ước số chẵn: {chiTiet}\nSố lượng các ước số chẵn = {chan.Count}",
                            "Số lượng ước số chẵn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Số lượng các ước số nguyên tố =====
        private void btnUocNguyenTo_Click(object? sender, EventArgs e)
        {
            if (!CoDanhSach(out int so, out var uoc)) return;

            var nguyenTo = uoc.Where(LaNguyenTo).ToList();
            string chiTiet = nguyenTo.Count == 0 ? "(không có)" : string.Join(", ", nguyenTo);
            MessageBox.Show($"Các ước số của {so}: {string.Join(", ", uoc)}\n\n" +
                            $"Các ước số nguyên tố: {chiTiet}\nSố lượng các ước số nguyên tố = {nguyenTo.Count}",
                            "Số lượng ước số nguyên tố", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing) return;
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
