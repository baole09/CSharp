/*
 * CHƯƠNG TRÌNH TÍNH LŨY THỪA HAI SỐ NGUYÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập hai số nguyên x, y. Tính x^y và xuất kết quả.
 *
 * Ý tưởng:
 * Nhập x, y.
 * kq ← 1
 * Lặp y lần:
 *     kq ← kq * x
 * Xuất kq.
 *
 * Mã giả:
 * TINH-LUY-THUA(x, y)
 * 1   kq ← 1
 * 2   for i ← 1 to y
 * 3       do kq ← kq * x
 * 4   return kq
 */

using System;

class Bai03_NhapSoNguyen
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
        int x = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap so nguyen y: ");
        int y = int.Parse(Console.ReadLine() ?? "0");

        if (y < 0)
        {
            Console.WriteLine("y phai la so nguyen khong am.");
            return;
        }

        Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, luyThua(x, y));
    }
}
