/*
 * CHƯƠNG TRÌNH THÊM GIÁ TRỊ LẺ SAU CẶP CHẴN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số nguyên A có n phần tử.
 * Sau mỗi cặp hai phần tử kề nhau đều là số chẵn,
 * chèn thêm một giá trị lẻ vào giữa hai phần tử đó.
 *
 * Theo ví dụ:
 *     2 4 3 4 2 8 2 5
 *     → 2 3 4 3 4 5 2 3 8 9 2 5
 *
 * Giá trị được chèn:
 *     a[i] + 1
 *
 * Vì a[i] là số chẵn nên:
 *     a[i] + 1 là số lẻ.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Tạo mảng kết quả C.
 * Duyệt A từ trái sang phải.
 * Luôn đưa a[i] vào C.
 * Nếu i < n - 1 và a[i], a[i+1] đều chẵn:
 *     chèn a[i] + 1 vào C.
 * Sau khi duyệt xong, tạo mảng kết quả có đúng k phần tử.
 * Chép k phần tử đầu của C sang mảng kết quả.
 * Gán A ← mảng kết quả.
 * Mỗi phần tử của A chỉ được duyệt một lần.
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(n)
 *
 * Mã giả:
 * THEM-CHAN-LE(A, n)
 * 1   tạo C có 2n phần tử
 * 2   k ← 0
 * 3   for i ← 0 to n - 1
 * 4       do c[k] ← a[i]
 * 5          k ← k + 1
 * 6          if i < n - 1 và a[i] chẵn và a[i+1] chẵn
 * 7              then c[k] ← a[i] + 1
 * 8                   k ← k + 1
 * 9   tạo KQ có k phần tử
 * 10  for i ← 0 to k - 1
 * 11      do KQ[i] ← C[i]
 * 12  A ← KQ
 */

using System;

class ThemChanLe
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

    public static void themChanLe(ref int[] day)
    {
        int n = day.Length;

        // Mỗi phần tử có thể tạo thêm tối đa 1 phần tử
        int[] tam = new int[2 * n];
        int k = 0;

        for (int i = 0; i <= n - 1; i++)
        {
            tam[k] = day[i];
            k++;

            if (i < n - 1 &&
                laChan(day[i]) &&
                laChan(day[i + 1]))
            {
                tam[k] = day[i] + 1;
                k++;
            }
        }

        // Tạo mảng kết quả có đúng k phần tử
        int[] kq = new int[k];

        // Chép dữ liệu từ mảng tạm sang mảng kết quả
        for (int i = 0; i <= k - 1; i++)
            kq[i] = tam[i];

        day = kq;
    }

    public static void Main(string[] args)
    {
        int[] daySo = null;

        nhapDaySo(ref daySo);

        Console.WriteLine("* Mang truoc them:");
        inMangTraiSangPhai(daySo);

        themChanLe(ref daySo);

        Console.WriteLine("* Mang sau khi them:");
        inMangTraiSangPhai(daySo);
    }
}