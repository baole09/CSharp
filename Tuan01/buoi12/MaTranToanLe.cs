/*
 * CHƯƠNG TRÌNH KIỂM TRA MA TRẬN TOÀN LẺ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập ma trận số nguyên A có n dòng và m cột.
 * Kiểm tra ma trận A có phải là ma trận toàn lẻ hay không.
 *
 * Ý tưởng:
 * A = (a[i,j]), với i = 0..n-1, j = 0..m-1
 * Ma trận A toàn lẻ khi:
 *     a[i,j] % 2 ≠ 0 với mọi i,j
 * Duyệt từng phần tử của ma trận.
 * Nếu a[i,j] % 2 = 0:
 *     kết luận A không toàn lẻ và dừng ngay.
 * Nếu duyệt hết ma trận mà không gặp phần tử chẵn:
 *     kết luận A toàn lẻ.
 * Độ phức tạp:
 *     Thời gian: O(n × m)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * LaToanLe(A, n, m)
 * 1   for i ← 0 to n - 1
 * 2       do for j ← 0 to m - 1
 * 3           do if a[i,j] % 2 = 0
 * 4                  then return FALSE
 * 5   return TRUE
 */

using System;

class MaTranToanLe
{
    const int MAX_DIM = 100;

    public static void nhapMang(ref int[,] a)
    {
        int soDong;
        int soCot;

        do
        {
            Console.Write("Moi ban nhap so dong: ");
            soDong = int.Parse(Console.ReadLine() ?? "0");
        }
        while (soDong <= 0 || soDong > MAX_DIM);

        do
        {
            Console.Write("Moi ban nhap so cot: ");
            soCot = int.Parse(Console.ReadLine() ?? "0");
        }
        while (soCot <= 0 || soCot > MAX_DIM);

        a = new int[soDong, soCot];

        for (int id = 0; id <= soDong - 1; id++)
        {
            for (int ic = 0; ic <= soCot - 1; ic++)
            {
                Console.Write(
                    "+ Nhap phan tu [{0}, {1}] = ",
                    id,
                    ic);

                a[id, ic] =
                    int.Parse(Console.ReadLine() ?? "0");
            }
        }
    }

    public static void xuatMang(int[,] a)
    {
        Console.WriteLine(
            "Mang co {0} dong x {1} cot:",
            a.GetLength(0),
            a.GetLength(1));

        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
                Console.Write("{0,7}", a[id, ic]);

            Console.WriteLine();
        }
    }

    public static bool laToanLe(int[,] a)
    {
        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
            {
                if (a[id, ic] % 2 == 0)
                    return false;
            }
        }

        return true;
    }

    public static void Main(string[] args)
    {
        int[,] maTran = null;

        nhapMang(ref maTran);
        xuatMang(maTran);

        if (laToanLe(maTran))
            Console.WriteLine("Mang A toan le!");
        else
            Console.WriteLine("Mang A khong toan le.");
    }
}