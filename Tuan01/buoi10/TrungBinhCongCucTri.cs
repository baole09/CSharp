/*
 * CHƯƠNG TRÌNH TÍNH TRUNG BÌNH CỘNG CÁC PHẦN TỬ CỰC TRỊ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 16/09/2026
 *
 * Phát biểu đề bài:
 * -Nhập dãy số thực A có n phần tử.
 * -Tìm các phần tử cực trị trong dãy.
 * -Tính trung bình cộng các phần tử cực trị.
 *
 * -Định nghĩa cực trị:
 * Phần tử ai với 0 < i < n - 1 là cực trị khi: (a[i] >= a[i-1] và a[i] >= a[i+1]) || (a[i] <= a[i-1] và a[i] <= a[i+1])
 *
 * -Hai phần tử đầu và cuối không được xét vì thiếu một phía lân cận.
 *
 * Ý tưởng:
 *
 * A = (a[0], a[1], ..., a[n-1])
 * Xét:
 *     a[i], 1 <= i <= n - 2
 * Cực đại:
 *     a[i] >= a[i-1] và a[i] >= a[i+1]
 * Cực tiểu:
 *     a[i] <= a[i-1] và a[i] <= a[i+1]
 * Nếu ai là cực trị:
 *     dem ← dem + 1
 *     tong ← tong + ai
 * Trung bình cộng: TBC = tong / dem
 * Nếu dem = 0: Dãy không có phần tử cực trị.
 *
 * Mã giả:
 *
 * TrungBinhCongCucTri(A, n)
 * 1   dem ← 0
 * 2   tong ← 0
 * 3   for i ← 1 to n - 2
 * 4       do
 * 5           if (a[i] >= a[i-1] và a[i] >= a[i+1])
 * 6              hoặc (a[i] <= a[i-1] và a[i] <= a[i+1])
 * 7               then
 * 8                   dem ← dem + 1
 * 9                  tong ← tong + ai
 * 10  if dem = 0
 * 11      then return
 * 12  TBC ← tong / dem
 * 13  return TBC
 */

using System;

class TrungBinhCongCucTri
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
        while (n < 0 || n > MAX_N);

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

    private static bool laCucTri(double[] day, int i)
    {
        bool cucDai =
            day[i] >= day[i - 1] &&
            day[i] >= day[i + 1];

        bool cucTieu =
            day[i] <= day[i - 1] &&
            day[i] <= day[i + 1];

        return cucDai || cucTieu;
    }

    public static int thongKeCucTri(
        double[] day,
        ref double tong)
    {
        int dem = 0;
        tong = 0;

        for (int i = 1; i <= day.Length - 2; i++)
        {
            if (laCucTri(day, i))
            {
                dem++;
                tong += day[i];
            }
        }

        return dem;
    }

    public static void lietKeCucTri(double[] day)
    {
        for (int i = 1; i <= day.Length - 2; i++)
        {
            if (laCucTri(day, i))
                Console.Write(" {0}", day[i]);
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        double[] daySo = null;
        double tong = 0;

        nhapDaySo(ref daySo);
        inMangTraiSangPhai(daySo);

        int dem = thongKeCucTri(
            daySo,
            ref tong);

        if (dem == 0)
        {
            Console.WriteLine(
                "Day so khong co phan tu cuc tri.");
            return;
        }

        Console.Write(
            "Day so co {0} phan tu cuc tri:",
            dem);

        lietKeCucTri(daySo);

        Console.WriteLine(
            "Tong cac phan tu cuc tri co trong day so: {0}.",
            tong);

        Console.WriteLine(
            "Trung binh cong cac phan tu cuc tri: {0:F2}.",
            tong / dem);
    }
}