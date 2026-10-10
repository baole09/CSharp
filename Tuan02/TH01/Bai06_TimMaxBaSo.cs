/*
 * CHƯƠNG TRÌNH TÌM GIÁ TRỊ LỚN NHẤT CỦA BA SỐ NGUYÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Xây dựng lớp có phương thức tìm giá trị lớn nhất của ba số nguyên.
 *
 * Ý tưởng:
 * max ← a
 * Nếu b > max: max ← b
 * Nếu c > max: max ← c
 *
 * Mã giả:
 * MAX(a, b, c)
 * 1   max ← a
 * 2   if b > max then max ← b
 * 3   if c > max then max ← c
 * 4   return max
 */

using System;

class Bai06_TimMaxBaSo
{
    public static int timMax(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap a: ");
        int a = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap b: ");
        int b = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap c: ");
        int c = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Gia tri lon nhat: {0}", timMax(a, b, c));
    }
}
