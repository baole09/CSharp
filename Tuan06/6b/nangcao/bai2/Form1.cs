using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Lab06
{
    public class Form1 : LabForm
    {
        private readonly bool grades;
        private readonly ComboBox subject = new ComboBox();
        private readonly ListView list = new ListView();
        private readonly TextBox total = new TextBox();
        public Form1() : base("6b Nâng cao 2 Lọc điểm")
        {
            grades = true;
            subject.DropDownStyle = ComboBoxStyle.DropDownList;
            if (grades)
            {
                Field("Môn học để trống là tất cả", subject);
            }

            FlowLayoutPanel buttons = Row();
            Button(buttons, grades ? "Lọc dữ liệu" : "Hiển thị dữ liệu", LoadData);
            Button(buttons, "Thoát", Close);
            list.Width = 865;
            list.Height = 360;
            list.View = View.Details;
            list.FullRowSelect = true;
            list.GridLines = true;
            string[] headers = grades ? new[]
            {
                "STT",
                "Tên sinh viên",
                "Ngày sinh",
                "Tên môn học",
                "Điểm"
            }

            : new[]
            {
                "Mã lớp",
                "Tên lớp",
                "Mã khoa"
            };
            foreach (string header in headers)
            {
                list.Columns.Add(header, header == "STT" ? 50 : 190);
            }

            ContentPanel.Controls.Add(list);
            total.ReadOnly = true;
            if (grades)
            {
                Field("Tổng điểm", total);
            }

            Shown += delegate
            {
                Guard(delegate
                {
                    if (grades)
                    {
                        subject.Items.Add("");
                        foreach (DataRow row in Database.Read("QLSinhVien", "SELECT MaMonHoc,TenMonHoc FROM MonHoc ORDER BY MaMonHoc").Rows)
                        {
                            subject.Items.Add(row["MaMonHoc"].ToString());
                        }

                        subject.SelectedIndex = 0;
                        LoadData();
                    }
                });
            };
        }

        // Dùng chung cho lựa chọn ComboBox và kiểm tra kết quả lọc.
        public void FilterSubject(string code)
        {
            subject.SelectedIndex = subject.Items.IndexOf(code);
            LoadData();
        }

        public int VisibleCount
        {
            get
            {
                return list.Items.Count;
            }
        }

        public decimal VisibleTotal
        {
            get
            {
                return decimal.Parse(total.Text);
            }
        }

        public override void LoadData()
        {
            DataTable data;
            if (grades)
            {
                data = Database.Read("QLSinhVien", "SELECT s.HoTen,s.NgaySinh,m.TenMonHoc,d.Diem FROM Diem d " + "JOIN SinhVien s ON s.MaSinhVien=d.MaSinhVien JOIN MonHoc m ON m.MaMonHoc=d.MaMonHoc " + "WHERE (@ma='' OR d.MaMonHoc=@ma) ORDER BY s.MaSinhVien,d.MaMonHoc", Database.Param("@ma", subject.Text));
            }
            else
            {
                data = Database.Read("QLSinhVien", "SELECT MaLop,TenLop,MaKhoa FROM Lop ORDER BY MaLop");
            }

            list.Items.Clear();
            decimal sum = 0;
            foreach (DataRow row in data.Rows)
            {
                ListViewItem item;
                if (grades)
                {
                    item = new ListViewItem((list.Items.Count + 1).ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.SubItems.Add(((DateTime)row["NgaySinh"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["TenMonHoc"].ToString());
                    item.SubItems.Add(row["Diem"].ToString());
                    sum += Convert.ToDecimal(row["Diem"]);
                }
                else
                {
                    item = new ListViewItem(row["MaLop"].ToString());
                    item.SubItems.Add(row["TenLop"].ToString());
                    item.SubItems.Add(row["MaKhoa"].ToString());
                }

                list.Items.Add(item);
            }

            total.Text = sum.ToString(CultureInfo.CurrentCulture);
        }
    }
}
