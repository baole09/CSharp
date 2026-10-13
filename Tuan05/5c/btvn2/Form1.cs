using System.Globalization;

namespace btvn2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== Ô nhập: chỉ cho gõ chữ số (số tự nhiên) =====
        private void txtN_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtN_TextChanged(object? sender, EventArgs e)
        {
            DatLoi(txtN, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Kiểm tra dữ liệu nhập =====
        private bool KiemTraN(out long n, out string loi)
        {
            n = 0;
            loi = "";
            string s = txtN.Text.Trim();

            if (s.Length == 0)
                loi = "Chưa nhập số.";
            else if (!long.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out n))
                loi = "Dữ liệu phải là số tự nhiên.";

            DatLoi(txtN, loi);
            return loi.Length == 0;
        }

        // ===== Tiện ích với listbox =====
        private List<long> LayTatCa() => lstSo.Items.Cast<long>().ToList();

        // Báo và trả về true nếu danh sách rỗng
        private bool Rong()
        {
            if (lstSo.Items.Count > 0) return false;

            MessageBox.Show("Danh sách đang rỗng.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        // ===== Nhập: thêm số N vào listbox =====
        private void btnNhap_Click(object? sender, EventArgs e)
        {
            if (!KiemTraN(out long n, out string loi))
            {
                MessageBox.Show(loi, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtN.Focus();
                txtN.SelectAll();
                return;
            }

            lstSo.Items.Add(n);

            // Cuộn để thấy phần tử vừa thêm
            int hienThi = Math.Max(1, lstSo.ClientSize.Height / lstSo.ItemHeight);
            lstSo.TopIndex = Math.Max(0, lstSo.Items.Count - hienThi);

            txtN.Clear();
            txtN.Focus();
        }

        // ===== Tổng các phần tử =====
        private void btnTong_Click(object? sender, EventArgs e)
        {
            if (Rong()) return;

            decimal tong = LayTatCa().Sum(x => (decimal)x);   // decimal để tổng không bị tràn
            MessageBox.Show($"Tổng các phần tử trong listbox = {tong}", "Tổng",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Xóa phần tử đầu và cuối =====
        private void btnXoaDauCuoi_Click(object? sender, EventArgs e)
        {
            if (Rong()) return;

            lstSo.Items.RemoveAt(lstSo.Items.Count - 1);   // xóa cuối trước để chỉ số đầu không lệch
            if (lstSo.Items.Count > 0)
                lstSo.Items.RemoveAt(0);
        }

        // ===== Xóa các phần tử đang chọn =====
        private void btnXoaChon_Click(object? sender, EventArgs e)
        {
            var chon = lstSo.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();

            if (chon.Count == 0)
            {
                MessageBox.Show("Chưa chọn phần tử nào trong listbox.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstSo.BeginUpdate();
            foreach (int i in chon)               // xóa từ cuối lên
                lstSo.Items.RemoveAt(i);
            lstSo.EndUpdate();
        }

        // ===== Biến đổi mọi phần tử (giữ nguyên trạng thái chọn) =====
        private void BienDoiTatCa(Func<long, long> bienDoi)
        {
            if (Rong()) return;

            var cu = LayTatCa();
            var chon = lstSo.SelectedIndices.Cast<int>().ToList();

            // Tính trước toàn bộ; nếu có phần tử bị tràn thì không đổi gì cả
            long[] moi;
            try
            {
                moi = cu.Select(bienDoi).ToArray();
            }
            catch (OverflowException)
            {
                MessageBox.Show("Có phần tử vượt quá giới hạn của kiểu số nên không thể thực hiện.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstSo.BeginUpdate();
            for (int i = 0; i < moi.Length; i++)
                lstSo.Items[i] = moi[i];
            foreach (int i in chon)               // gán phần tử làm mất chọn nên chọn lại
                lstSo.SetSelected(i, true);
            lstSo.EndUpdate();
        }

        private void btnTang2_Click(object? sender, EventArgs e) =>
            BienDoiTatCa(x => checked(x + 2));

        private void btnBinhPhuong_Click(object? sender, EventArgs e) =>
            BienDoiTatCa(x => checked(x * x));

        // ===== Chọn các phần tử chẵn / lẻ =====
        private void ChonTheoTinhChan(bool chan)
        {
            if (Rong()) return;

            int dem = 0;
            lstSo.BeginUpdate();
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                bool laChan = (long)lstSo.Items[i] % 2 == 0;
                if (laChan == chan)
                {
                    lstSo.SetSelected(i, true);
                    dem++;
                }
            }
            lstSo.EndUpdate();

            if (dem == 0)
                MessageBox.Show(chan ? "Không có số chẵn nào trong danh sách."
                                     : "Không có số lẻ nào trong danh sách.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChonChan_Click(object? sender, EventArgs e) => ChonTheoTinhChan(true);

        private void btnChonLe_Click(object? sender, EventArgs e) => ChonTheoTinhChan(false);

        // ===== Kết thúc (Esc cũng gọi nút này) =====
        private void btnKetThuc_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        // ===== Hỏi xác nhận trước khi đóng form: nút X, Alt+F4, Kết thúc, Esc =====
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
