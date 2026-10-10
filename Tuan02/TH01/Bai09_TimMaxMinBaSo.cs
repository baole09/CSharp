/*
 * CHƯƠNG TRÌNH TÌM GIÁ TRỊ LỚN NHẤT VÀ NHỎ NHẤT
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Xây dựng lớp có phương thức tìm giá trị lớn nhất và nhỏ nhất
 * của ba số thực bằng tham chiếu out.
 *
 * Ý tưởng:
 * max ← a, min ← a
 * So sánh b và c với max, min.
 * Trả về max và min bằng out.
 *
 * Mã giả:
 * MAX-MIN(a, b, c, out max, out min)
 * 1   max ← a
 * 2   min ← a
 * 3   if b > max then max ← b
 * 4   if c > max then max ← c
 * 5   if b < min then min ← b
 * 6   if c < min then min ← c
 */

using System;

class Bai09_TimMaxMinBaSo
{
    public static void timMaxMin(double a, double b, double c,
                                 out double max, out double min)
    {
        max = a;
        min = a;

        if (b > max) max = b;
        if (c > max) max = c;
        if (b < min) min = b;
        if (c < min) min = c;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap c: ");
        double c = double.Parse(Console.ReadLine() ?? "0");

        timMaxMin(a, b, c, out double max, out double min);

        Console.WriteLine("Gia tri lon nhat: {0}", max);
        Console.WriteLine("Gia tri nho nhat: {0}", min);
    }
}
