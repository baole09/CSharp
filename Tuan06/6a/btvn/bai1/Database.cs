using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab06
{
    // Một kết nối cho mỗi thao tác; using luôn đóng kết nối khi có lỗi.
    public static class Database
    {
        public static string ConnectionString(string catalog)
        {
            // Đổi tên máy chủ tại đây nếu máy dùng SQL Express hoặc LocalDB.
            string server = @".";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = catalog;
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            builder.ConnectTimeout = 5;
            return builder.ConnectionString;
        }

        public static DataTable Read(string catalog, string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString(catalog)))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(((ICloneable)parameter).Clone());
                }

                connection.Open();
                // SqlDataReader dùng cho bảng hiển thị, ComboBox và kiểm tra khóa.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public static int Execute(string catalog, string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString(catalog)))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(((ICloneable)parameter).Clone());
                }

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static SqlParameter Param(string name, object value)
        {
            SqlParameter parameter = new SqlParameter(name, value ?? DBNull.Value);
            return parameter;
        }
    }
}
