# 6a Mẫu Quản lý khoa

1. Mở `Database/QLSinhVien.sql` trong SQL Server Management Studio, bấm Execute. File có đủ bảng, khóa và dữ liệu mẫu.
2. Mở file `.csproj` trong thư mục này hoặc chọn bài trong `Lab06.sln`.
3. Trong `Database.cs`, đổi biến `server` nếu cần (mặc định `.` dùng Windows Authentication).
4. Bấm F5.

`Form1.cs` chứa đầy đủ giao diện, sự kiện và xử lý dữ liệu của bài. `Database.cs` quản lý kết nối và truy vấn. `LabForm.cs` tạo các hàng control. Tất cả source đều ở trong thư mục bài, có thể chép riêng thư mục để mở project.
