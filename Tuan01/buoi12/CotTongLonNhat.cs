/*
 * CHƯƠNG TRÌNH LIỆT KÊ CỘT CÓ TỔNG LỚN NHẤT
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập ma trận số thực A có n dòng và m cột.
 * Tính tổng các phần tử trên từng cột.
 * Liệt kê tất cả các cột có tổng lớn nhất.
 *
 * Ý tưởng:
 * A = (a[i,j]), với i = 0..n-1, j = 0..m-1
 * Tổng cột j:
 *     tong[j] = a[0,j] + a[1,j] + ... + a[n-1,j]
 * Tìm tổng lớn nhất:
 *     max ← tong[0]
 *     Nếu tong[j] > max:
 *         max ← tong[j]
 * Đếm số cột có tổng bằng max.
 * Tạo mảng kết quả có đúng số phần tử đã đếm.
 * Duyệt lại tong[] và đưa chỉ số các cột có tong[j] = max vào kết quả.
 *
 * Mã giả:
 * TongTungCot(A, n, m)
 * 1   tạo tong[0..m-1]
 * 2   for j ← 0 to m - 1
 * 3       do tong[j] ← 0
 * 4          for i ← 0 to n - 1
 * 5              do tong[j] ← tong[j] + a[i,j]
 * 6   return tong
 *
 * CotTongLonNhat(tong, m)
 * 1   max ← tong[0]
 * 2   for j ← 1 to m - 1
 * 3       do if tong[j] > max
 * 4              then max ← tong[j]
 * 5
 * 6   dem ← 0
 * 7   for j ← 0 to m - 1
 * 8       do if tong[j] = max
 * 9              then dem ← dem + 1
 * 10
 * 11  kq[0..dem-1]
 * 12  dem ← 0
 * 13  for j ← 0 to m - 1
 * 14      do if tong[j] = max
 * 15             then kq[dem] ← j
 * 16                  dem ← dem + 1
 * 17  return kq
 */

using System;

class CotTongLonNhat
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

    public static double[] tongTungCot(double[,] a)
    {
        int soDong = a.GetLength(0);
        int soCot = a.GetLength(1);

        double[] tong = new double[soCot];

        for (int ic = 0; ic <= soCot - 1; ic++)
        {
            tong[ic] = 0;

            for (int id = 0; id <= soDong - 1; id++)
                tong[ic] += a[id, ic];
        }

        return tong;
    }

    public static int[] cotTongLonNhat(double[] tong)
    {
        double max = tong[0];

        for (int ic = 1; ic <= tong.Length - 1; ic++)
        {
            if (tong[ic] > max)
                max = tong[ic];
        }

        int soCotLonNhat = 0;

        for (int ic = 0; ic <= tong.Length - 1; ic++)
        {
            if (tong[ic] == max)
                soCotLonNhat++;
        }

        int[] ketQua = new int[soCotLonNhat];
        int dem = 0;

        for (int ic = 0; ic <= tong.Length - 1; ic++)
        {
            if (tong[ic] == max)
            {
                ketQua[dem] = ic;
                dem++;
            }
        }

        return ketQua;
    }

    public static void inTongTungCot(double[] tong)
    {
        Console.Write("Tong tung cot:");

        for (int i = 0; i <= tong.Length - 1; i++)
            Console.Write(" {0}", tong[i]);

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        double[,] maTran = null;

        nhapMang(ref maTran);
        xuatMang(maTran);

        double[] tong = tongTungCot(maTran);

        inTongTungCot(tong);

        int[] danhSachCot =
            cotTongLonNhat(tong);

        Console.Write("Cac cot co tong lon nhat:");

        for (int i = 0; i <= danhSachCot.Length - 1; i++)
            Console.Write(" {0}", danhSachCot[i]);

        Console.WriteLine();
    }
}