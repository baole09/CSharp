/*
 * CHƯƠNG TRÌNH XỬ LÝ MA TRẬN VÀ TÁCH SỐ CHẴN, LẺ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 19/09/2026
 *
 * Phát biểu đề bài:
 * Sinh ngẫu nhiên mảng A[nxm] trong đoạn [10, 100],
 * với n,m nhập từ bàn phím. In mảng và trả về hai mảng:
 * mảng các số chẵn và mảng các số lẻ.
 *
 * Ý tưởng:
 * A = (a[id, ic]), 10 <= a[id, ic] <= 100
 * Sinh ngẫu nhiên từng phần tử.
 * Đếm số chẵn, số lẻ.
 * Tạo hai mảng đúng kích thước rồi đưa phần tử vào.
 *
 * Mã giả:
 * SINH-MA-TRAN(n, m)
 * 1   tạo A[n, m]
 * 2   for id ← 0 to n - 1
 * 3       for ic ← 0 to m - 1
 * 4           a[id, ic] ← số ngẫu nhiên trong [10, 100]
 * 5   return A
 * TACH-CHAN-LE(A)
 * 6   đếm số chẵn và số lẻ
 * 7   tạo Chan, Le
 * 8   duyệt A và đưa phần tử vào mảng tương ứng
 * 9   return Chan, Le
 */

using System;

class Bai17_MaTranChanLe
{
    const int MAX_DIM = 100;

    public static void sinhMaTran(ref int[,] a)
    {
        int n, m;

        do
        {
            Console.Write("Nhap so dong: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n <= 0 || n > MAX_DIM);

        do
        {
            Console.Write("Nhap so cot: ");
            m = int.Parse(Console.ReadLine() ?? "0");
        }
        while (m <= 0 || m > MAX_DIM);

        a = new int[n, m];
        Random random = new Random();

        for (int id = 0; id <= n - 1; id++)
            for (int ic = 0; ic <= m - 1; ic++)
                a[id, ic] = random.Next(10, 101);
    }

    public static void xuatMaTran(int[,] a)
    {
        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
                Console.Write("{0,5}", a[id, ic]);
            Console.WriteLine();
        }
    }

    public static void tachChanLe(int[,] a, out int[] chan, out int[] le)
    {
        int soChan = 0, soLe = 0;

        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
            {
                if (a[id, ic] % 2 == 0) soChan++;
                else soLe++;
            }
        }

        chan = new int[soChan];
        le = new int[soLe];

        int demChan = 0, demLe = 0;

        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
            {
                if (a[id, ic] % 2 == 0)
                {
                    chan[demChan] = a[id, ic];
                    demChan++;
                }
                else
                {
                    le[demLe] = a[id, ic];
                    demLe++;
                }
            }
        }
    }

    public static void xuatDay(int[] day)
    {
        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write("{0} ", day[i]);
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[,] a = null;
        sinhMaTran(ref a);

        Console.WriteLine("Ma tran:");
        xuatMaTran(a);

        tachChanLe(a, out int[] chan, out int[] le);

        Console.Write("Mang cac so chan: ");
        xuatDay(chan);
        Console.Write("Mang cac so le: ");
        xuatDay(le);
    }
}
