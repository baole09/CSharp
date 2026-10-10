/*
 * CHƯƠNG TRÌNH XỬ LÝ MẢNG SỐ NGUYÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập mảng n phần tử, in mảng, tìm phần tử lớn nhất và nhỏ nhất,
 * trả về mảng các số nguyên tố.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Duyệt A để tìm max, min.
 * Đếm số nguyên tố trước, tạo mảng kết quả đúng kích thước,
 * sau đó duyệt A để đưa số nguyên tố vào kết quả.
 *
 * Mã giả:
 * MAX-MIN(A, n)
 * 1   max ← a[0], min ← a[0]
 * 2   for i ← 1 to n - 1
 * 3       if a[i] > max then max ← a[i]
 * 4       if a[i] < min then min ← a[i]
 * 5   return max, min
 * LAY-NGUYEN-TO(A, n)
 * 6   đếm số phần tử nguyên tố
 * 7   tạo K có kích thước đã đếm
 * 8   duyệt A và đưa số nguyên tố vào K
 * 9   return K
 */

using System;

class Bai15_Mang
{
    const int MAX_N = 500;

    public static void nhapMang(ref int[] day)
    {
        int n;
        do
        {
            Console.Write("Nhap so luong phan tu: ");
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

    public static void xuatMang(int[] day)
    {
        Console.Write("Mang: ");
        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write("{0} ", day[i]);
        Console.WriteLine();
    }

    public static void timMaxMin(int[] day, out int max, out int min)
    {
        max = day[0];
        min = day[0];

        for (int i = 1; i <= day.Length - 1; i++)
        {
            if (day[i] > max) max = day[i];
            if (day[i] < min) min = day[i];
        }
    }

    public static bool laSoNguyenTo(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i * i <= n; i++)
            if (n % i == 0)
                return false;

        return true;
    }

    public static int[] laySoNguyenTo(int[] day)
    {
        int soLuong = 0;

        for (int i = 0; i <= day.Length - 1; i++)
            if (laSoNguyenTo(day[i]))
                soLuong++;

        int[] ketQua = new int[soLuong];
        int dem = 0;

        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (laSoNguyenTo(day[i]))
            {
                ketQua[dem] = day[i];
                dem++;
            }
        }

        return ketQua;
    }

    static void Main(string[] args)
    {
        int[] day = null;
        nhapMang(ref day);
        xuatMang(day);

        if (day.Length == 0)
        {
            Console.WriteLine("Mang rong, khong the tim max va min.");
            return;
        }

        timMaxMin(day, out int max, out int min);
        Console.WriteLine("Phan tu lon nhat: {0}", max);
        Console.WriteLine("Phan tu nho nhat: {0}", min);

        int[] soNguyenTo = laySoNguyenTo(day);
        Console.Write("Mang cac so nguyen to: ");
        xuatMang(soNguyenTo);
    }
}
