using System.Globalization;

namespace btvn
{
    public partial class Form1 : Form
    {
        private bool _daThanhToan;     // khách hiện tại đã được thanh toán chưa

        // Bộ đếm trong ngày (reset về 0 khi bấm Tổng kết)
        private int _soLuot;
        private decimal _tongTien;

        public Form1()
        {
            InitializeComponent();
        }

        private RadioButton[] DsPhong => new[]
        {
            radioButton_phongdon, radioButton_phongdoi, radioButton_phongba
        };

        private CheckBox[] DsTienNghi => new[]
        {
            chkTivi, chkInternet, chkMayNuocNong
        };

        private CheckBox[] TatCaCheck => new[]
        {
            chkTivi, chkInternet, chkMayNuocNong, chkKaraoke, chkAnSang
        };

        private static string Tien(decimal v) =>
            v.ToString("0", CultureInfo.InvariantCulture) + " VND";

        // ===== Form_Load: ba nút mờ, con trỏ vào ô họ tên =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;
            ActiveControl = txtHoTen;
        }

        // ===== Kiểm tra đủ thông tin =====
        private bool LayDuLieu(out int soNgay)
        {
            soNgay = 0;

            return !string.IsNullOrWhiteSpace(txtHoTen.Text)
                && !string.IsNullOrWhiteSpace(txtDiaChi.Text)
                && int.TryParse(txtSoNgay.Text, out soNgay) && soNgay > 0
                && DsPhong.Any(r => r.Checked);
        }

        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            // Đã thanh toán thì chỉ sáng lại sau khi Nhập mới (tránh tính trùng một khách)
            btnThanhToan.Enabled = !_daThanhToan && LayDuLieu(out _);
        }

        private void Nhap_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
            DuLieuThayDoi(sender, e);
        }

        // ===== Số ngày ở chỉ cho nhập số =====
        private void txtSoNgay_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===== Kiểm tra khi rời ô (không đặt e.Cancel) =====
        private void txtHoTen_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            DatLoi(txtHoTen, string.IsNullOrWhiteSpace(txtHoTen.Text)
                ? "Tên khách hàng không được để trống" : "");
        }

        private void txtDiaChi_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            DatLoi(txtDiaChi, string.IsNullOrWhiteSpace(txtDiaChi.Text)
                ? "Địa chỉ không được để trống" : "");
        }

        private void txtSoNgay_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoNgay.Text))
                DatLoi(txtSoNgay, "Chưa nhập số ngày ở");
            else if (!int.TryParse(txtSoNgay.Text, out int n) || n < 1)
                DatLoi(txtSoNgay, "Số ngày ở phải từ 1 trở lên");
            else
                DatLoi(txtSoNgay, "");
        }

        // ===== Thanh toán =====
        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if (!LayDuLieu(out int soNgay))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: họ tên, địa chỉ, số ngày ở (từ 1 trở lên) và chọn loại phòng.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaPhong = (decimal)DsPhong.First(r => r.Checked).Tag!;

            decimal tien = giaPhong * soNgay;                                        // phòng theo ngày
            tien += DsTienNghi.Where(c => c.Checked).Sum(c => (decimal)c.Tag!);      // tiện nghi: một lần
            if (chkKaraoke.Checked) tien += (decimal)chkKaraoke.Tag!;                // karaoke: một lần
            if (chkAnSang.Checked) tien += (decimal)chkAnSang.Tag! * soNgay;         // ăn sáng: theo ngày

            txtThanhTien.Text = Tien(tien);

            // Lưu lại cho phần tổng kết cuối ngày
            _soLuot++;
            _tongTien += tien;

            _daThanhToan = true;
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
        }

        // ===== Nhập mới: về trạng thái ban đầu =====
        private void btnNhapMoi_Click(object? sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Clear();
            txtThanhTien.Clear();

            foreach (var r in DsPhong) r.Checked = false;
            foreach (var c in TatCaCheck) c.Checked = false;

            DatLoi(txtHoTen, "");
            DatLoi(txtDiaChi, "");
            DatLoi(txtSoNgay, "");

            _daThanhToan = false;
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;   // Tổng kết giữ nguyên vì số liệu trong ngày vẫn còn

            txtHoTen.Focus();
        }

        // ===== Tổng kết: ghi số liệu rồi đưa bộ đếm về 0 =====
        private void btnTongKet_Click(object? sender, EventArgs e)
        {
            txtSoLuot.Text = _soLuot.ToString();
            txtTongTien.Text = Tien(_tongTien);

            _soLuot = 0;
            _tongTien = 0;

            btnTongKet.Enabled = false;
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}