/*
 * CHƯƠNG TRÌNH KIỂM TRA SỐ NGUYÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Làm lại bài 3, nhưng thông báo lỗi khi x hay y không phải là số nguyên.
 *
 * Ý tưởng:
 * Dùng int.TryParse để kiểm tra dữ liệu nhập.
 * Nếu x hoặc y không phải số nguyên: xuất thông báo lỗi.
 * Ngược lại: tính x^y.
 *
 * Mã giả:
 * KIEM-TRA-SO-NGUYEN()
 * 1   nhập sx, sy
 * 2   nếu sx không chuyển được sang số nguyên: xuất lỗi
 * 3   nếu sy không chuyển được sang số nguyên: xuất lỗi
 * 4   tính x^y
 * 5   xuất kết quả
 */

using System;

class Bai04_KiemTraSoNguyen
{
    static long luyThua(int x, int y)
    {
        long ketQua = 1;
        for (int i = 1; i <= y; i++)
            ketQua *= x;
        return ketQua;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen x: ");
        string sx = Console.ReadLine() ?? "";
        Console.Write("Nhap so nguyen y: ");
        string sy = Console.ReadLine() ?? "";

        if (!int.TryParse(sx, out int x))
        {
            Console.WriteLine("Loi: x khong phai la so nguyen.");
            return;
        }

        if (!int.TryParse(sy, out int y))
        {
            Console.WriteLine("Loi: y khong phai la so nguyen.");
            return;
        }

        if (y < 0)
        {
            Console.WriteLine("Loi: y phai la so nguyen khong am.");
            return;
        }

        Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, luyThua(x, y));
    }
}
