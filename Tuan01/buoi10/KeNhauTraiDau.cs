/*
 * CHƯƠNG TRÌNH ĐẾM CẶP KỀ NHAU TRÁI DẤU
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 16/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số thực A có n phần tử.
 * Đếm số cặp kề nhau (a[i], a[i+1]) mà hai phần tử trái dấu.
 *
 * Quy ước:
 * 0 không mang dấu -> cặp chứa 0 KHÔNG được tính là trái dấu.
 *
 * Ý tưởng:
 *
 * A = (a0, a1, ..., a[n-1])
 *
 * Xét từng cặp kề nhau:
 *     (a[i], a[i+1]), 0 <= i <= n - 2
 *
 * Hai số trái dấu khi:
 *     a[i] * a[i+1] < 0
 *
 * Nếu a[i] = 0 hoặc a[i+1] = 0:
 *     ai * ai+1 = 0
 *     -> không được tính.
 *
 * Mã giả:
 *
 * KeNhauTraiDau(A, n)
 * 1   dem ← 0
 * 2
 * 3   for i ← 0 to n - 2
 * 4       do
 * 5           if ai * ai+1 < 0
 * 6               then dem ← dem + 1
 * 7
 * 8   return dem
 */

using System;

class KeNhauTraiDau
{
    const int MAX_N = 500;

    public static void nhapDaySo(ref double[] day)
    {
        int n;

        do
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n <= 0 || n > MAX_N);

        day = new double[n];

        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = double.Parse(Console.ReadLine() ?? "0");
        }
    }

    public static void inMangTraiSangPhai(double[] day)
    {
        Console.Write("Day so co {0} phan tu:", day.Length);

        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write(" {0}", day[i]);

        Console.WriteLine();
    }

    public static void demKeNhauTraiDau(
        double[] day,
        ref int dem)
    {
        dem = 0;

        for (int i = 0; i <= day.Length - 2; i++)
        {
            if (day[i] * day[i + 1] < 0)
                dem++;
        }
    }

    public static void Main(string[] args)
    {
        double[] daySo = null;
        int ketQua = 0;

        nhapDaySo(ref daySo);
        inMangTraiSangPhai(daySo);

        demKeNhauTraiDau(daySo, ref ketQua);

        Console.WriteLine(
            "So luong cac cap ke nhau ma trai dau: {0}.",
            ketQua);
    }
}