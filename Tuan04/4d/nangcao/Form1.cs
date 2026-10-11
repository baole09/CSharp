using System.Globalization;
using System.Text;

namespace nangcao
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo Vn = new("vi-VN");

        // Kết quả của lần Tính tiền gần nhất (chờ Thanh toán)
        private bool _daTinh;
        private decimal _tienDaTinh;
        private int _soKhachDaTinh;

        // Số liệu cộng dồn các nhóm khách đã thanh toán
        private long _tongKhach;
        private decimal _tongTien;

        public Form1()
        {
            InitializeComponent();
        }

        private RadioButton[] DsNuoc => new[]
        {
            radioButton_cafeden, radioButton_cafeda, radioButton_cafesua,
            radioButton_cafekem, radioButton_cafesuada
        };

        private CheckBox[] DsThucAn => new[]
        {
            chkBanhMyTrung, chkMyXaoBo, chkBanhMyCa, chkMyCay, chkMyTomTrung
        };

        private static string Tien(decimal v) => v.ToString("N0", Vn) + "đ";

        // ===== Form_Load: ba nút mờ, con trỏ vào ô tên =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
            ActiveControl = txtTen;
        }

        // ===== Kiểm tra đủ thông tin =====
        private bool LayDuLieu(out string ten, out int soKhach)
        {
            ten = txtTen.Text.Trim();
            soKhach = 0;

            return ten.Length > 0
                && int.TryParse(txtSoKhach.Text, out soKhach) && soKhach > 0
                && DsNuoc.Any(r => r.Checked)
                && DsThucAn.Any(c => c.Checked);
        }

        // Dữ liệu đổi thì cập nhật nút Tính tiền; kết quả đã tính trước đó không còn đúng
        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            btnTinhTien.Enabled = LayDuLieu(out _, out _);

            if (_daTinh)
            {
                _daTinh = false;
                btnThanhToan.Enabled = false;
            }
        }

        private void Nhap_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
            DuLieuThayDoi(sender, e);
        }

        // ===== Số khách hàng chỉ cho nhập số =====
        private void txtSoKhach_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===== Kiểm tra khi rời ô (không đặt e.Cancel) =====
        private void txtTen_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
                DatLoi(txtTen, "Tên khách hàng không được để trống");
            else
                DatLoi(txtTen, "");
        }

        private void txtSoKhach_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoKhach.Text))
                DatLoi(txtSoKhach, "Chưa nhập số khách hàng");
            else if (!int.TryParse(txtSoKhach.Text, out int n) || n < 1)
                DatLoi(txtSoKhach, "Số khách hàng phải từ 1 trở lên");
            else
                DatLoi(txtSoKhach, "");
        }

        // ===== Tính tiền =====
        private void btnTinhTien_Click(object? sender, EventArgs e)
        {
            if (!LayDuLieu(out string ten, out int soKhach))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: tên khách hàng, số khách hàng (từ 1 trở lên), " +
                                "một loại nước uống và ít nhất một món ăn.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuoc = DsNuoc.First(r => r.Checked);
            var monAn = DsThucAn.Where(c => c.Checked).ToList();
            bool sinhVien = chkSinhVien.Checked;

            decimal giaNuoc = (decimal)nuoc.Tag!;
            decimal giaMonAn = monAn.Sum(c => (decimal)c.Tag!);
            decimal donGia = giaNuoc + giaMonAn;               // tiền cho một khách
            decimal tien = donGia * soKhach;
            if (sinhVien) tien *= 0.8m;                        // giảm 20% cho sinh viên

            var sb = new StringBuilder();
            sb.AppendLine($"Khách hàng: {ten}");
            sb.AppendLine($"Số khách: {soKhach}");
            sb.AppendLine($"Nước uống: {nuoc.Text} ({Tien(giaNuoc)})");
            sb.AppendLine("Thức ăn: " + string.Join(", ", monAn.Select(c => $"{c.Text} ({Tien((decimal)c.Tag!)})")));
            sb.AppendLine($"Giá cho một khách: {Tien(donGia)}");
            sb.AppendLine(sinhVien ? "Sinh viên: có (giảm 20%)" : "Sinh viên: không");
            sb.AppendLine();
            sb.Append($"Thành tiền: {Tien(tien)}");

            MessageBox.Show(sb.ToString(), "Tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _daTinh = true;
            _tienDaTinh = tien;
            _soKhachDaTinh = soKhach;

            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        // ===== Đưa phần nhập về trạng thái ban đầu =====
        private void LamMoiNhap()
        {
            txtTen.Clear();
            txtSoKhach.Clear();
            chkSinhVien.Checked = false;

            foreach (var r in DsNuoc) r.Checked = false;
            foreach (var c in DsThucAn) c.Checked = false;

            DatLoi(txtTen, "");
            DatLoi(txtSoKhach, "");

            _daTinh = false;
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;

            txtTen.Focus();
        }

        // ===== Nhập lại =====
        private void btnNhapLai_Click(object? sender, EventArgs e)
        {
            LamMoiNhap();
        }

        // ===== Thanh toán: ghi vào ô tổng, sẵn sàng cho nhóm mới =====
        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if (!_daTinh) return;

            _tongKhach += _soKhachDaTinh;
            _tongTien += _tienDaTinh;

            txtTongKhach.Text = _tongKhach.ToString("N0", Vn);
            txtTongTien.Text = Tien(_tongTien);

            LamMoiNhap();
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