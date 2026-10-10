/*
 * CHƯƠNG TRÌNH KIỂM TRA SỐ NGUYÊN TỐ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Xây dựng lớp có phương thức kiểm tra n có phải là số nguyên tố hay không.
 *
 * Ý tưởng:
 * n < 2 => không phải số nguyên tố.
 * Duyệt i từ 2 đến i*i <= n.
 * Nếu n chia hết cho i => không phải số nguyên tố.
 * Nếu không có ước => là số nguyên tố.
 *
 * Mã giả:
 * LA-NGUYEN-TO(n)
 * 1   if n < 2 then return false
 * 2   for i ← 2 while i*i <= n
 * 3       if n % i = 0 then return false
 * 4   return true
 */

using System;

class Bai07_KiemTraSoNguyenTo
{
    public static bool laSoNguyenTo(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i * i <= n; i++)
            if (n % i == 0)
                return false;

        return true;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine(
            laSoNguyenTo(n)
                ? "{0} la so nguyen to."
                : "{0} khong phai la so nguyen to.", n);
    }
}
