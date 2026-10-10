/*
 * CHƯƠNG TRÌNH SẮP XẾP CHẴN LẺ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số nguyên A có n phần tử.
 * Sắp xếp dãy sao cho các số chẵn ở trước và tăng dần,
 * các số lẻ ở sau và giảm dần.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Xây dựng quan hệ thứ tự truocHon(x, y):
 *     x đứng trước y nếu x phải được đặt trước y.
 * Hai phần tử khác loại:
 *     x chẵn, y lẻ -> x đứng trước y.
 * Hai phần tử đều chẵn:
 *     x < y -> x đứng trước y.
 * Hai phần tử đều lẻ:
 *     x > y -> x đứng trước y.
 * Dùng Interchange Sort để đưa các phần tử về đúng thứ tự.
 * Nếu truocHon(a[j], a[i]) thì a[j] phải đứng trước a[i],
 * do đó hoán vị a[i] và a[j].
 * Độ phức tạp:
 *     Thời gian: O(n^2)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * SapChanLe(A, n)
 * 1   for i ← 0 to n - 2
 * 2       do
 * 3           for j ← i + 1 to n - 1
 * 4               do
 * 5                   if dungTruoc(a[j], a[i])
 * 6                       then tmp ← a[i]
 * 7                            a[i] ← a[j]
 * 8                            a[j] ← tmp
 */

using System;

class SapChanLe
{
    const int MAX_N = 500;

    public static void nhapDaySo(ref int[] day)
    {
        int n;

        do
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n < 0 || n > MAX_N);

        day = new int[n];

        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    public static void inMangTraiSangPhai(int[] day)
    {
        Console.Write("Day so co {0} phan tu:", day.Length);

        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write(" {0}", day[i]);

        Console.WriteLine();
    }

    private static bool laChan(int x)
    {
        return x % 2 == 0;
    }

    private static bool dungTruoc(int x, int y)
    {
        bool xChan = laChan(x);
        bool yChan = laChan(y);

        if (xChan != yChan)
            return xChan;

        if (xChan)
            return x < y;

        return x > y;
    }

    public static void sapChanLe(int[] day)
    {
        for (int i = 0; i <= day.Length - 2; i++)
        {
            for (int j = i + 1; j <= day.Length - 1; j++)
            {
                if (dungTruoc(day[j], day[i]))
                {
                    int tmp = day[i];
                    day[i] = day[j];
                    day[j] = tmp;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        int[] daySo = null;

        nhapDaySo(ref daySo);

        Console.WriteLine("* Mang truoc khi sap xep:");
        inMangTraiSangPhai(daySo);

        sapChanLe(daySo);

        Console.WriteLine("* Mang sau khi sap xep:");
        inMangTraiSangPhai(daySo);
    }
}