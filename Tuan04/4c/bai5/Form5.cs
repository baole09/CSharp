namespace bai5
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // ===== Chặn nhập khác chữ số =====
        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Sửa số thì kết quả cũ không còn đúng nên xóa đi
        private void txtSo_TextChanged(object? sender, EventArgs e)
        {
            txtKetQua.Clear();
        }

        // ===== Kiểm tra ô nhập: số nguyên từ 1 đến 999 =====
        // ===== Kiểm tra ô nhập: số nguyên từ 1 đến 999 =====
        private bool KiemTraSo(out int so, out string loi)
        {
            so = 0;
            loi = "";

            if (string.IsNullOrWhiteSpace(txtSo.Text))
                loi = "Chưa nhập số.";
            else if (!int.TryParse(txtSo.Text, out so))
                loi = "Dữ liệu phải là số nguyên.";
            else if (so < 1)
                loi = "Số phải lớn hơn 0 (chỉ nhận từ 1 đến 999).";
            else if (so > 999)
                loi = $"Số {so} lớn hơn 999. Vui lòng nhập số từ 1 đến 999.";
            else
            {
                DatLoi(txtSo, "");
                return true;
            }

            DatLoi(txtSo, loi);
            return false;
        }

        // Rời ô: ô rỗng thì bỏ qua (chỉ báo lỗi khi bấm Thực hiện)
        private void txtSo_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSo.Text))
                DatLoi(txtSo, "");
            else
                KiemTraSo(out _, out _);
        }

        // ===== Thực hiện =====
        private void btnThucHien_Click(object? sender, EventArgs e)
        {
            if (!KiemTraSo(out int so, out string loi))
            {
                MessageBox.Show(loi, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetQua.Clear();
                txtSo.Focus();
                return;
            }

            txtKetQua.Text = DocSo(so);
        }
        // ===== Đọc số 1..999 thành chữ =====
        private static string DocSo(int n)
        {
            string[] chu = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };

            int tram = n / 100;
            int chuc = n / 10 % 10;
            int donvi = n % 10;

            var tu = new List<string>();

            if (tram > 0)
            {
                tu.Add(chu[tram]);
                tu.Add("Trăm");
            }

            if (chuc > 1)
            {
                tu.Add(chu[chuc]);
                tu.Add("Mươi");
            }
            else if (chuc == 1)
            {
                tu.Add("Mười");
            }
            else if (donvi > 0 && tram > 0)
            {
                tu.Add("Lẻ");           // vd: 105 = Một Trăm Lẻ Năm
            }

            if (donvi > 0)
            {
                if (donvi == 1 && chuc > 1) tu.Add("Mốt");        // 21, 31, ...
                else if (donvi == 5 && chuc >= 1) tu.Add("Lăm");  // 15, 25, 115, ...
                else tu.Add(chu[donvi]);
            }

            return string.Join(" ", tu);
        }

        // ===== Xóa: trả form về trạng thái ban đầu =====
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            txtSo.Clear();
            txtKetQua.Clear();
            DatLoi(txtSo, "");
            txtSo.Focus();
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form5_FormClosing để hỏi xác nhận
        }

        private void Form5_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}