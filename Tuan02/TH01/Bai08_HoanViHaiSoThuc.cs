/*
 * CHƯƠNG TRÌNH HOÁN VỊ HAI SỐ THỰC BẰNG REF
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Xây dựng lớp có phương thức hoán vị hai số thực.
 *
 * Ý tưởng:
 * Dùng biến tạm:
 *     tam ← x
 *     x ← y
 *     y ← tam
 *
 * Mã giả:
 * HOAN-VI(ref x, ref y)
 * 1   tam ← x
 * 2   x ← y
 * 3   y ← tam
 */

using System;

class Bai08_HoanViHaiSoThuc
{
    public static void hoanVi(ref double x, ref double y)
    {
        double tam = x;
        x = y;
        y = tam;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap x: ");
        double x = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap y: ");
        double y = double.Parse(Console.ReadLine() ?? "0");

        hoanVi(ref x, ref y);

        Console.WriteLine("Sau khi hoan vi: x = {0}, y = {1}", x, y);
    }
}
