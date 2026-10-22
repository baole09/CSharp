using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System;

// 6a Nâng cao Quản lý sinh viên: giao diện, sự kiện, kiểm tra dữ liệu và câu SQL của bài này.
namespace Lab06
{
    public class Form1 : LabForm
    {
        private readonly string table;
        private readonly bool advanced;
        private readonly Dictionary<string, Control> inputs = new Dictionary<string, Control>();
        private readonly DataGridView grid = new DataGridView();
        private readonly Label status = new Label();
        public Form1() : base("6a Nâng cao Quản lý sinh viên")
        {
            table = "SinhVien";
            advanced = false;
            foreach (string column in StudentService.Columns(table))
            {
                bool foreign = advanced && ((table == "Lop" && column == "MaKhoa") || (table == "SinhVien" && column == "MaLop") || (table == "Diem" && column != "Diem"));
                Control input;
                if (foreign)
                {
                    ComboBox combo = new ComboBox();
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                    input = combo;
                }
                else
                {
                    input = new TextBox();
                }

                inputs.Add(column, input);
                Field(LabelFor(column), input);
            }

            FlowLayoutPanel buttons = Row();
            Button(buttons, "Thêm", delegate
            {
                Save("INSERT");
            });
            Button(buttons, "Xóa", delegate
            {
                if (MessageBox.Show("Xóa dữ liệu đã nhập?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save("DELETE");
                }
            });
            Button(buttons, "Sửa", delegate
            {
                Save("UPDATE");
            });
            Button(buttons, "Nhập mới", Clear);
            Button(buttons, "Tải lại", LoadData);
            Button(buttons, "Thoát", Close);
            status.AutoSize = true;
            status.Text = "6a: xóa chỉ cần khóa; riêng sinh viên cần thêm họ tên. Ngày: dd/MM/yyyy.";
            ContentPanel.Controls.Add(status);
            grid.Width = 865;
            grid.Height = 260;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.CellClick += delegate
            {
                SelectRow();
            };
            ContentPanel.Controls.Add(grid);
            Shown += delegate
            {
                Guard(LoadData);
            };
        }

        public static string LabelFor(string column)
        {
            switch (column)
            {
                case "MaKhoa":
                    return "Mã khoa";
                case "TenKhoa":
                    return "Tên khoa";
                case "MaLop":
                    return "Mã lớp";
                case "TenLop":
                    return "Tên lớp";
                case "MaSinhVien":
                    return "Mã sinh viên";
                case "HoTen":
                    return "Họ tên sinh viên";
                case "NgaySinh":
                    return "Ngày sinh dd/MM/yyyy";
                case "MaMonHoc":
                    return "Mã môn học";
                case "TenMonHoc":
                    return "Tên môn học";
                default:
                    return "Điểm";
            }
        }

        public override void LoadData()
        {
            foreach (KeyValuePair<string, Control> pair in inputs)
            {
                ComboBox combo = pair.Value as ComboBox;
                if (combo == null)
                {
                    continue;
                }

                string saved = combo.Text;
                string parent = pair.Key == "MaKhoa" ? "Khoa" : pair.Key == "MaLop" ? "Lop" : pair.Key == "MaSinhVien" ? "SinhVien" : "MonHoc";
                combo.Items.Clear();
                foreach (DataRow row in StudentService.All(parent).Rows)
                {
                    combo.Items.Add(row[pair.Key].ToString());
                }

                combo.SelectedIndex = combo.Items.IndexOf(saved);
            }

            grid.DataSource = StudentService.All(table);
            status.Text = "Đã tải " + grid.Rows.Count + " dòng từ SQL Server. Chọn dòng để nạp thông tin.";
        }

        public void Save(string action)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Control> pair in inputs)
            {
                values[pair.Key] = pair.Value.Text.Trim();
            }

            StudentService.Save(table, advanced, action, values);
            LoadData();
            status.Text = "Thành công: " + action + ". Dữ liệu đã được lưu trong SQL Server.";
        }

        private void SelectRow()
        {
            if (grid.CurrentRow == null)
            {
                return;
            }

            foreach (KeyValuePair<string, Control> pair in inputs)
            {
                object value = grid.CurrentRow.Cells[pair.Key].Value;
                pair.Value.Text = value is DateTime ? ((DateTime)value).ToString("dd/MM/yyyy") : Convert.ToString(value);
            }
        }

        private void Clear()
        {
            foreach (Control input in inputs.Values)
            {
                ComboBox combo = input as ComboBox;
                if (combo != null)
                {
                    combo.SelectedIndex = -1;
                }
                else
                {
                    input.Text = "";
                }
            }

            grid.ClearSelection();
        }
    }
}

namespace Lab06
{
    // Tên bảng/cột chỉ lấy từ danh sách cố định, dữ liệu người dùng luôn truyền bằng tham số.
    public static class StudentService
    {
        public static string[] Columns(string table)
        {
            switch (table)
            {
                case "Khoa":
                    return new[]
                    {
                        "MaKhoa",
                        "TenKhoa"
                    };
                case "MonHoc":
                    return new[]
                    {
                        "MaMonHoc",
                        "TenMonHoc"
                    };
                case "Lop":
                    return new[]
                    {
                        "MaLop",
                        "TenLop",
                        "MaKhoa"
                    };
                case "SinhVien":
                    return new[]
                    {
                        "MaSinhVien",
                        "HoTen",
                        "NgaySinh",
                        "MaLop"
                    };
                case "Diem":
                    return new[]
                    {
                        "MaSinhVien",
                        "MaMonHoc",
                        "Diem"
                    };
                default:
                    throw new ArgumentException("Bảng không hợp lệ.");
            }
        }

        public static bool Exists(string table, string column, string value)
        {
            if (!Columns(table).Contains(column))
            {
                throw new ArgumentException("Cột không hợp lệ.");
            }

            // ExecuteReader ở Database.Read: không nuốt lỗi kết nối thành lỗi trùng mã.
            return Database.Read("QLSinhVien", "SELECT 1 FROM " + table + " WHERE " + column + "=@key", Database.Param("@key", value)).Rows.Count > 0;
        }

        public static DataTable All(string table)
        {
            string[] columns = Columns(table);
            return Database.Read("QLSinhVien", "SELECT " + string.Join(",", columns) + " FROM " + table + " ORDER BY " + columns[0]);
        }

        public static void Save(string table, bool advanced, string action, Dictionary<string, string> values)
        {
            string[] columns = Columns(table);
            int keyCount = table == "Diem" ? 2 : 1;
            for (int i = 0; i < keyCount; i++)
            {
                Require(values[columns[i]], columns[i]);
            }

            if (action == "INSERT")
            {
                foreach (string column in columns)
                {
                    Require(values[column], column);
                }
            }

            if (action == "UPDATE")
            {
                // 6a SinhVien/Lop cho phép sửa riêng từng trường; bỏ trống giữ nguyên.
                bool partial = !advanced && (table == "SinhVien" || table == "Lop");
                if (!columns.Skip(keyCount).Any(c => values[c] != ""))
                {
                    throw new ArgumentException("Nhập ít nhất một trường cần sửa.");
                }

                if (!partial)
                {
                    foreach (string column in columns.Skip(keyCount))
                    {
                        Require(values[column], column);
                    }
                }
            }

            if (action == "DELETE" && table == "SinhVien" && !advanced)
            {
                Require(values["HoTen"], "Họ tên để đối chiếu khi xóa");
            }

            Dictionary<string, object> parsed = new Dictionary<string, object>();
            foreach (string column in columns)
            {
                parsed[column] = values[column];
            }

            if (action != "DELETE")
            {
                DateTime birth;
                if (table == "SinhVien" && values["NgaySinh"] != "")
                {
                    if (!DateTime.TryParseExact(values["NgaySinh"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birth))
                    {
                        throw new ArgumentException("Ngày sinh phải có dạng dd/MM/yyyy.");
                    }

                    if (advanced && DateTime.Today.Year - birth.Year < 17)
                    {
                        throw new ArgumentException("Sinh viên phải từ 17 tuổi theo năm sinh.");
                    }

                    parsed["NgaySinh"] = birth;
                }

                decimal grade;
                if (table == "Diem")
                {
                    if (!decimal.TryParse(values["Diem"].Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out grade) || grade < 0 || grade > 10)
                    {
                        throw new ArgumentException("Điểm phải là số trong đoạn 0 đến 10.");
                    }

                    parsed["Diem"] = grade;
                }

                // Kiểm tra khóa ngoại bằng SqlDataReader trước khi ghi dữ liệu.
                CheckForeign(table, values);
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            string where = string.Join(" AND ", columns.Take(keyCount).Select(c => c + "=@" + c));
            foreach (string column in columns.Take(keyCount))
            {
                parameters.Add(Database.Param("@" + column, parsed[column]));
            }

            bool exists = Database.Read("QLSinhVien", "SELECT 1 FROM " + table + " WHERE " + where, parameters.ToArray()).Rows.Count > 0;
            if (action == "INSERT" && exists)
            {
                throw new ArgumentException("Trùng khóa chính. Không thể thêm.");
            }

            if (action != "INSERT" && !exists)
            {
                throw new ArgumentException("Không tìm thấy khóa chính cần thao tác.");
            }

            if (action == "DELETE")
            {
                CheckDelete(table, values);
                if (table == "SinhVien" && !advanced)
                {
                    where += " AND HoTen=@HoTen";
                    parameters.Add(Database.Param("@HoTen", values["HoTen"]));
                }
            }

            List<string> changed = columns.Skip(keyCount).Where(c => values[c] != "").ToList();
            string sql;
            if (action == "INSERT")
            {
                changed = columns.Skip(keyCount).ToList();
                sql = "INSERT INTO SinhVien (MaSinhVien,HoTen,NgaySinh,MaLop) VALUES (@MaSinhVien,@HoTen,@NgaySinh,@MaLop)";
            }
            else if (action == "UPDATE")
            {
                sql = "UPDATE SinhVien SET " + string.Join(",", changed.Select(c => c + "=@" + c)) + " WHERE " + where;
            }
            else
            {
                sql = "DELETE FROM SinhVien WHERE " + where;
            }

            if (action != "DELETE")
            {
                foreach (string column in changed)
                {
                    parameters.Add(Database.Param("@" + column, parsed[column]));
                }
            }

            if (Database.Execute("QLSinhVien", sql, parameters.ToArray()) != 1)
            {
                throw new ArgumentException("Không có dòng được cập nhật; kiểm tra mã và họ tên.");
            }
        }

        private static void CheckForeign(string table, Dictionary<string, string> values)
        {
            if (table == "Lop" && values["MaKhoa"] != "" && !Exists("Khoa", "MaKhoa", values["MaKhoa"]))
            {
                throw new ArgumentException("Mã khoa chưa tồn tại.");
            }

            if (table == "SinhVien" && values["MaLop"] != "" && !Exists("Lop", "MaLop", values["MaLop"]))
            {
                throw new ArgumentException("Mã lớp chưa tồn tại.");
            }

            if (table == "Diem" && (!Exists("SinhVien", "MaSinhVien", values["MaSinhVien"]) || !Exists("MonHoc", "MaMonHoc", values["MaMonHoc"])))
            {
                throw new ArgumentException("Sinh viên hoặc môn học chưa tồn tại.");
            }
        }

        private static void CheckDelete(string table, Dictionary<string, string> values)
        {
            string child = null;
            string column = null;
            if (table == "Khoa")
            {
                child = "Lop";
                column = "MaKhoa";
            }

            if (table == "Lop")
            {
                child = "SinhVien";
                column = "MaLop";
            }

            if (table == "SinhVien")
            {
                child = "Diem";
                column = "MaSinhVien";
            }

            if (table == "MonHoc")
            {
                child = "Diem";
                column = "MaMonHoc";
            }

            if (child != null && Exists(child, column, values[column]))
            {
                throw new ArgumentException("Dữ liệu đang được tham chiếu ở bảng " + child + ". Xóa dữ liệu con trước.");
            }
        }

        private static void Require(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Không được bỏ trống " + name + ".");
            }
        }
    }
}
