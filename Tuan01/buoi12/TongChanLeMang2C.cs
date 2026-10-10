/*
 * CHƯƠNG TRÌNH TÍNH TỔNG CÁC SỐ CHẴN, LẺ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập ma trận số nguyên A có n dòng và m cột.
 * Tính tổng các phần tử chẵn và tổng các phần tử lẻ trong ma trận.
 *
 * Ý tưởng:
 * A = (a[i,j]), với i = 0..n-1, j = 0..m-1
 * Khởi tạo:
 *     tongChan ← 0
 *     tongLe ← 0
 * Duyệt toàn bộ ma trận theo từng dòng.
 * Nếu a[i,j] % 2 = 0:
 *     tongChan ← tongChan + a[i,j]
 * Ngược lại:
 *     tongLe ← tongLe + a[i,j]
 * Mỗi phần tử được xét đúng một lần.
 * Độ phức tạp:
 *     Thời gian: O(n × m)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * tongChanLe(A, n, m)
 * 1   tongChan ← 0
 * 2   tongLe ← 0
 * 3   for i ← 0 to n - 1
 * 4       do for j ← 0 to m - 1
 * 5           do if a[i,j] % 2 = 0
 * 6                  then tongChan ← tongChan + a[i,j]
 * 7                  else tongLe ← tongLe + a[i,j]
 * 8   return tongChan, tongLe
 */

using System;

class TongChanLeMang2C
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

    public static void tongChanLe(
        int[,] a,
        ref long tongChan,
        ref long tongLe)
    {
        tongChan = 0;
        tongLe = 0;

        for (int id = 0; id <= a.GetLength(0) - 1; id++)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
            {
                if (a[id, ic] % 2 == 0)
                    tongChan += a[id, ic];
                else
                    tongLe += a[id, ic];
            }
        }
    }

    public static void Main(string[] args)
    {
        int[,] maTran = null;

        long tongChan = 0;
        long tongLe = 0;

        nhapMang(ref maTran);
        xuatMang(maTran);

        tongChanLe(
            maTran,
            ref tongChan,
            ref tongLe);

        Console.WriteLine(
            "Tong cac so chan la {0} va tong so le la {1}.",
            tongChan,
            tongLe);
    }
}