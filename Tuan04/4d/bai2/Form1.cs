using System.Globalization;

namespace bai2
{
    public partial class Form1 : Form
    {
        private readonly MangSoNguyen _mang = new();

        public Form1()
        {
            InitializeComponent();
            CapNhatOnhap();   // ban đầu các ô tìm / xóa / thêm / thay thế đều mờ
        }

        // Enter = Thực Hiện (đang ở ô nhập mảng thì Enter = Nhập mảng).
        // Nếu đang focus một nút thì để nút đó tự xử lý Enter.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl is not Button)
            {
                if (ActiveControl == Inputmang) button_nhapmang.PerformClick();
                else button_thuchien.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ===== Tiện ích hiển thị =====
        private void HienMang() => Outputmang.Text = _mang.ToString();

        private void XoaKetQua()
        {
            Outputtim.Clear();
            Outputtongmang.Clear();
            Outputtongchan.Clear();
            Outputtongle.Clear();
            Outputmax.Clear();
            Outputmin.Clear();
        }

        private void BaoLoi(string noiDung, TextBox? oLoi = null)
        {
            MessageBox.Show(noiDung, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            oLoi?.Focus();
        }

        private string ThongBaoViTri(int viTri, bool chen)
        {
            int n = _mang.SoPhanTu;
            if (n == 0 && !chen) return "Mảng đang rỗng.";
            return $"Vị trí {viTri} không hợp lệ. Vị trí hợp lệ từ 0 đến {(chen ? n : n - 1)}.";
        }

        // ===== Bật/tắt các ô nhập theo radio đang chọn =====
        private void Bat(TextBox t, bool bat)
        {
            t.Enabled = bat;
            if (!bat)
            {
                t.Clear();
                DatLoi(t, "");
            }
        }

        private void Radio_CheckedChanged(object? sender, EventArgs e)
        {
            CapNhatOnhap();
        }

        private void CapNhatOnhap()
        {
            Bat(Inputgiatritim, radioButton_giatritim.Checked);
            Bat(Inputvitritim, radioButton_vitritim.Checked);

            Bat(Inputgiatrixoa, radioButton_giatrixoa.Checked);
            Bat(Inputvitrixoa, radioButton_vitrixoa.Checked);

            bool them = radioButton_giatrithem.Checked;
            Bat(Inputgiatrithem, them);
            Bat(Inputvitrithem, them);

            Bat(Inputgiatrithay, radioButton_giatricanthay.Checked);
            Bat(Inputvitrithay, radioButton_vitrithaythe.Checked);
            Bat(Inputsothaythe, radioButton_giatricanthay.Checked || radioButton_vitrithaythe.Checked);
        }

        // ===== Chặn nhập =====
        private void Inputmang_KeyPress(object? sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsControl(c) || char.IsDigit(c) || c == ' ' || c == ',' || c == '-') return;
            e.Handled = true;
        }

        private void txtSo_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var txt = (TextBox)sender!;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == '-')
            {
                bool dauChuoi = txt.SelectionStart == 0;
                bool daCoTru = txt.Text.Contains('-') && !txt.SelectedText.Contains('-');
                if (dauChuoi && !daCoTru) return;
            }

            e.Handled = true;
        }

        private void txt_TextChanged(object? sender, EventArgs e)
        {
            DatLoi((TextBox)sender!, "");   // sửa lại thì bỏ viền đỏ
        }

        // ===== Nhập mảng =====
        private void button_nhapmang_Click(object? sender, EventArgs e)
        {
            string[] mau = Inputmang.Text.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (mau.Length == 0)
            {
                DatLoi(Inputmang, "Chưa nhập mảng");
                BaoLoi("Chưa nhập mảng. Hãy nhập các số nguyên cách nhau bởi khoảng trắng.", Inputmang);
                return;
            }

            var ds = new List<int>();
            foreach (string s in mau)
            {
                if (!int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int v))
                {
                    DatLoi(Inputmang, $"\"{s}\" không phải số nguyên hợp lệ");
                    BaoLoi($"\"{s}\" không phải số nguyên hợp lệ.", Inputmang);
                    return;
                }
                ds.Add(v);
            }

            DatLoi(Inputmang, "");
            _mang.Nhap(ds);
            HienMang();
            XoaKetQua();   // mảng đổi nên các kết quả cũ không còn đúng
        }

        // ===== Reset: về trạng thái ban đầu =====
        private void button_reset_Click(object? sender, EventArgs e)
        {
            Inputmang.Clear();
            DatLoi(Inputmang, "");
            _mang.Nhap(Array.Empty<int>());
            Outputmang.Clear();
            XoaKetQua();

            radioButton_tang.Checked = false;
            radioButton_giam.Checked = false;
            radioButton_giatritim.Checked = false;
            radioButton_vitritim.Checked = false;
            radioButton_giatrixoa.Checked = false;
            radioButton_vitrixoa.Checked = false;
            radioButton_giatrithem.Checked = false;
            radioButton_giatricanthay.Checked = false;
            radioButton_vitrithaythe.Checked = false;

            CapNhatOnhap();
            Inputmang.Focus();
        }

        // Đọc một ô thành số nguyên; lỗi thì ghi vào dsLoi và viền đỏ
        private int DocInt(TextBox t, string ten, List<string> dsLoi)
        {
            string s = t.Text.Trim();

            if (s.Length == 0)
            {
                Loi($"{ten} chưa được nhập.");
                return 0;
            }
            if (!int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int v))
            {
                Loi($"{ten} phải là số nguyên hợp lệ.");
                return 0;
            }

            DatLoi(t, "");
            return v;

            void Loi(string m)
            {
                DatLoi(t, m);
                dsLoi.Add(m);
            }
        }

        // ===== Thực Hiện: chạy mọi nhóm đang được chọn =====
        private void button_thuchien_Click(object? sender, EventArgs e)
        {
            bool sap = radioButton_tang.Checked || radioButton_giam.Checked;
            bool timGt = radioButton_giatritim.Checked;
            bool timVt = radioButton_vitritim.Checked;
            bool xoaGt = radioButton_giatrixoa.Checked;
            bool xoaVt = radioButton_vitrixoa.Checked;
            bool them = radioButton_giatrithem.Checked;
            bool thayGt = radioButton_giatricanthay.Checked;
            bool thayVt = radioButton_vitrithaythe.Checked;

            if (!(sap || timGt || timVt || xoaGt || xoaVt || them || thayGt || thayVt))
            {
                BaoLoi("Chưa chọn thao tác nào. Hãy chọn Sắp xếp, Tìm kiếm, Xóa, Thêm hoặc Thay thế.");
                return;
            }
            if (_mang.Rong)
            {
                BaoLoi("Chưa có mảng. Hãy nhập mảng rồi bấm \"Nhập mảng\" trước.");
                return;
            }

            // 1. Đọc và kiểm tra định dạng mọi ô cần dùng (chưa thay đổi gì cả)
            var dsLoi = new List<string>();
            int gtTim = 0, vtTim = 0, gtXoa = 0, vtXoa = 0, gtThem = 0, vtThem = 0;
            int gtThay = 0, vtThay = 0, soThay = 0;

            if (timGt) gtTim = DocInt(Inputgiatritim, "Giá trị cần tìm", dsLoi);
            if (timVt) vtTim = DocInt(Inputvitritim, "Vị trí cần tìm", dsLoi);
            if (xoaGt) gtXoa = DocInt(Inputgiatrixoa, "Giá trị cần xóa", dsLoi);
            if (xoaVt) vtXoa = DocInt(Inputvitrixoa, "Vị trí cần xóa", dsLoi);
            if (them)
            {
                gtThem = DocInt(Inputgiatrithem, "Giá trị cần thêm", dsLoi);
                vtThem = DocInt(Inputvitrithem, "Vị trí cần thêm", dsLoi);
            }
            if (thayGt) gtThay = DocInt(Inputgiatrithay, "Giá trị cần thay thế", dsLoi);
            if (thayVt) vtThay = DocInt(Inputvitrithay, "Vị trí cần thay thế", dsLoi);
            if (thayGt || thayVt) soThay = DocInt(Inputsothaythe, "Số thay thế", dsLoi);

            if (dsLoi.Count > 0)
            {
                var cacO = new[] { Inputgiatritim, Inputvitritim, Inputgiatrixoa, Inputvitrixoa,
                                   Inputgiatrithem, Inputvitrithem, Inputgiatrithay, Inputvitrithay, Inputsothaythe };
                BaoLoi(string.Join("\n", dsLoi), cacO.FirstOrDefault(o => _oLoi.Contains(o)));
                return;
            }

            // 2. Sắp xếp
            if (sap)
            {
                if (radioButton_tang.Checked) _mang.SapXepTang();
                else _mang.SapXepGiam();
                HienMang();
                XoaKetQua();
            }

            // 3. Xóa (cần mảng đang tăng dần)
            if (xoaGt || xoaVt)
            {
                if (!_mang.DaSapTang())
                {
                    BaoLoi("Mảng chưa được sắp xếp tăng. Hãy chọn \"Sắp xếp Tăng\" trước khi xóa.");
                    return;
                }

                bool ok = xoaGt ? _mang.XoaGiaTri(gtXoa) : _mang.XoaTaiViTri(vtXoa);
                if (!ok)
                {
                    BaoLoi(xoaGt ? $"Không tìm thấy giá trị {gtXoa} trong mảng."
                                 : ThongBaoViTri(vtXoa, false),
                           xoaGt ? Inputgiatrixoa : Inputvitrixoa);
                    return;
                }

                HienMang();
                XoaKetQua();
                radioButton_giatrixoa.Checked = false;   // bỏ chọn để lần sau không xóa lại
                radioButton_vitrixoa.Checked = false;
            }

            // 4. Thêm (cần mảng đang tăng dần)
            if (them)
            {
                if (!_mang.DaSapTang())
                {
                    BaoLoi("Mảng chưa được sắp xếp tăng. Hãy chọn \"Sắp xếp Tăng\" trước khi thêm.");
                    return;
                }
                if (!_mang.ThemTaiViTri(gtThem, vtThem))
                {
                    BaoLoi(ThongBaoViTri(vtThem, true), Inputvitrithem);
                    return;
                }

                HienMang();
                XoaKetQua();
                radioButton_giatrithem.Checked = false;
            }

            // 5. Thay thế
            if (thayGt || thayVt)
            {
                bool ok = thayGt ? _mang.ThayTheGiaTri(gtThay, soThay) : _mang.ThayTheViTri(vtThay, soThay);
                if (!ok)
                {
                    BaoLoi(thayGt ? $"Không tìm thấy giá trị {gtThay} trong mảng."
                                  : ThongBaoViTri(vtThay, false),
                           thayGt ? Inputgiatrithay : Inputvitrithay);
                    return;
                }

                HienMang();
                XoaKetQua();
                radioButton_giatricanthay.Checked = false;
                radioButton_vitrithaythe.Checked = false;
            }

            // 6. Tìm kiếm (làm sau cùng để kết quả theo mảng mới nhất)
            if (timGt)
            {
                var viTri = _mang.TimViTri(gtTim);
                if (viTri.Count == 0)
                {
                    Outputtim.Clear();
                    MessageBox.Show($"Không tìm thấy giá trị {gtTim} trong mảng.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Outputtim.Text = string.Join(", ", viTri);
                }
            }
            else if (timVt)
            {
                if (vtTim < 0 || vtTim >= _mang.SoPhanTu)
                {
                    Outputtim.Clear();
                    BaoLoi(ThongBaoViTri(vtTim, false), Inputvitritim);
                    return;
                }
                Outputtim.Text = _mang.LayGiaTri(vtTim).ToString();
            }
        }

        // ===== Tổng mảng, tổng chẵn, tổng lẻ =====
        private void button_tong_Click(object? sender, EventArgs e)
        {
            if (_mang.Rong)
            {
                BaoLoi("Chưa có mảng. Hãy nhập mảng trước.");
                return;
            }

            Outputtongmang.Text = _mang.TongMang().ToString();
            Outputtongchan.Text = _mang.TongChan().ToString();
            Outputtongle.Text = _mang.TongLe().ToString();
        }

        // ===== Lớn nhất, nhỏ nhất =====
        private void button_tim_Click(object? sender, EventArgs e)
        {
            if (_mang.Rong)
            {
                BaoLoi("Chưa có mảng. Hãy nhập mảng trước.");
                return;
            }

            Outputmax.Text = _mang.GiaTriLonNhat().ToString();
            Outputmin.Text = _mang.GiaTriNhoNhat().ToString();
        }

        // ===== Thoát (Esc cũng gọi nút này) =====
        private void button_thoat_Click(object? sender, EventArgs e)
        {
            Close();   // đi qua Form1_FormClosing để hỏi xác nhận
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}