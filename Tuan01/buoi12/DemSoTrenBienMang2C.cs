/*
 * CHƯƠNG TRÌNH ĐẾM SỐ TRÊN BIÊN MA TRẬN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập ma trận số thực A có n dòng và m cột.
 * Đếm số phần tử dương, số phần tử âm và số phần tử bằng 0 nằm trên đường biên của ma trận.
 *
 * Ý tưởng:
 * A = (a[i,j]), với i = 0..n-1, j = 0..m-1
 *
 * Phần tử a[i,j] thuộc biên khi:
 *     i = 0 hoặc i = n - 1
 *     hoặc j = 0 hoặc j = m - 1
 *
 * Nếu a[i,j] = 0:
 *     soKhong ← soKhong + 1
 *
 * Nếu a[i,j] > 0:
 *     soDuong ← soDuong + 1
 *
 * Nếu a[i,j] < 0:
 *     soAm ← soAm + 1
 *
 * Chỉ xét các phần tử thuộc đường biên.
 *
 * Mã giả:
 * DemSoTrenBien(A, n, m)
 * 1   soDuong ← 0
 * 2   soAm ← 0
 * 3   soKhong ← 0
 * 4
 * 5   for i ← 0 to n - 1
 * 6       do for j ← 0 to m - 1
 * 7           do if i = 0 hoặc i = n - 1 hoặc j = 0 hoặc j = m - 1
 * 8                  then if a[i,j] = 0
 * 9                           then soKhong ← soKhong + 1
 * 10                       else if a[i,j] > 0
 * 11                           then soDuong ← soDuong + 1
 * 12                       else
 * 13                           soAm ← soAm + 1
 * 14
 * 15  return soDuong, soAm, soKhong
 */

using System;

class DemSoTrenBienMang2C
{
    const int MAX_DIM = 100;

    public static void nhapMang(ref double[,] a)
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

        a = new double[soDong, soCot];

        for (int id = 0; id <= soDong - 1; id++)
        {
            for (int ic = 0; ic <= soCot - 1; ic++)
            {
                Console.Write(
                    "+ Nhap phan tu [{0}, {1}] = ",
                    id,
                    ic);

                a[id, ic] =
                    double.Parse(Console.ReadLine() ?? "0");
            }
        }
    }

    public static void xuatMang(double[,] a)
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

    private static bool thuocBien(
        int id,
        int ic,
        int soDong,
        int soCot)
    {
        return id == 0 ||
               id == soDong - 1 ||
               ic == 0 ||
               ic == soCot - 1;
    }

    public static void demSoTrenBien(
        double[,] a,
        ref int soDuong,
        ref int soAm,
        ref int soKhong)
    {
        soDuong = 0;
        soAm = 0;
        soKhong = 0;

        int soDong = a.GetLength(0);
        int soCot = a.GetLength(1);

        for (int id = 0; id <= soDong - 1; id++)
        {
            for (int ic = 0; ic <= soCot - 1; ic++)
            {
                if (!thuocBien(id, ic, soDong, soCot))
                    continue;

                if (a[id, ic] == 0)
                    soKhong++;
                else if (a[id, ic] > 0)
                    soDuong++;
                else
                    soAm++;
            }
        }
    }

    public static void Main(string[] args)
    {
        double[,] maTran = null;

        int soDuong = 0;
        int soAm = 0;
        int soKhong = 0;

        nhapMang(ref maTran);
        xuatMang(maTran);

        demSoTrenBien(
            maTran,
            ref soDuong,
            ref soAm,
            ref soKhong);

        Console.WriteLine(
            "Tren duong bien co {0} so duong, {1} so am va {2} so khong.",
            soDuong,
            soAm,
            soKhong);
    }
}