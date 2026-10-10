/*
 * CHƯƠNG TRÌNH ĐẾM SỐ ÂM, SỐ KHÔNG VÀ SỐ DƯƠNG
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 15/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số thực A có n phần tử.
 * Đếm số lượng phần tử âm, số lượng phần tử không và số lượng phần tử dương trong dãy.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Khởi tạo:
 *     soAm = 0
 *     soKhong = 0
 *     soDuong = 0
 * Duyệt A từ trái sang phải.
 * Với mỗi a[i]:
 *     Nếu a[i] < 0: soAm ← soAm + 1
 *     Nếu a[i] = 0: soKhong ← soKhong + 1
 *     Nếu a[i] > 0: soDuong ← soDuong + 1
 * Sau khi duyệt hết dãy: xuất soAm, soKhong, soDuong.
 *
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * DemDau(A, n)
 * 1   soAm ← 0
 * 2   soKhong ← 0
 * 3   soDuong ← 0
 * 4   for i ← 0 to n - 1
 * 5       do if a[i] < 0
 * 6              then soAm ← soAm + 1
 * 7          else if a[i] = 0
 * 8              then soKhong ← soKhong + 1
 * 9          else
 * 10             soDuong ← soDuong + 1
 * 11  return soAm, soKhong, soDuong
 */

using System;

class DemDau
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

    public static void demDau(
        double[] day,
        ref int soAm,
        ref int soKhong,
        ref int soDuong)
    {
        soAm = 0;
        soKhong = 0;
        soDuong = 0;

        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] < 0)
                soAm++;
            else if (day[i] == 0)
                soKhong++;
            else
                soDuong++;
        }
    }

    public static void Main(string[] args)
    {
        double[] a = null;
        int am = 0;
        int khong = 0;
        int duong = 0;

        nhapDaySo(ref a);
        demDau(a, ref am, ref khong, ref duong);

        Console.WriteLine(
            "Day so co {0} so am, {1} so khong va {2} so duong.", am, khong, duong);
    }
}