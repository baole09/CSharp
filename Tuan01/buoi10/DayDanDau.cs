/*
 * CHƯƠNG TRÌNH KIỂM TRA DÃY ĐAN DẤU
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 16/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số thực A có n phần tử. Kiểm tra A có phải là dãy đan dấu.
 *
 * Ý tưởng:
 * A = (a0, a1, ..., a[n-1])
 *
 * dau(x) =
 *     -1, nếu x < 0
 *      0, nếu x = 0
 *      1, nếu x > 0
 *
 * A đan dấu <=> 
 * ∀i ∈ {0,...,n-2}:
 * dau(a[i]) * dau(a[i+1]) < 0
 *
 * Nếu tồn tại i:
 * dau(a[i]) * dau(a[i+1]) >= 0
 * => A không đan dấu.
 *
 * Sử dụng biến cờ danDau để lưu trạng thái.
 * Thoát sớm khi phát hiện một cặp phần tử kề nhau
 * không trái dấu.
 *
 * Mã giả:
 *
 * DayDanDau(A, n)
 * 1   if n = 1
 * 2       then return dau(a[0]) ≠ 0
 * 3
 * 4   danDau ← TRUE
 * 5   i ← 0
 * 6   while i ≤ n - 2 and danDau = TRUE
 * 7       do
 * 8           if dau(a[i]) * dau(a[i+1]) ≥ 0
 * 9               then danDau ← FALSE
 * 10          i ← i + 1
 * 11
 * 12  return danDau
 */
using System;

class DayDanDau
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
    private static int dau(double x)
    {
        if (x == 0) return 0;
        return x < 0 ? -1 : 1;
    }

    public static bool laDanDau(double[] day)
    {
        // Dãy 1 phần tử: quy ước là đan dấu nếu phần tử đó khác 0
        if (day.Length == 1)
            return dau(day[0]) != 0;

        bool coHieu = true;   // giả sử dãy đan dấu
        for (int i = 0; i <= day.Length - 2 && coHieu; i++)
        {
            if (dau(day[i]) * dau(day[i + 1]) >= 0)   // cùng dấu hoặc có phần tử 0
                coHieu = false;
        }
        return coHieu;
    }

    public static void Main(string[] args)
    {
        double[] a = null;
        nhapDaySo(ref a);
        inMangTraiSangPhai(a);

        if (laDanDau(a))
            Console.WriteLine("Day so tren la day dan dau.");
        else
            Console.WriteLine("Day so tren khong la day dan dau.");
    }
}

