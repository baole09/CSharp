/*
 * CHƯƠNG TRÌNH THỐNG KÊ CÁC SỐ CHẴN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 15/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số nguyên A có n phần tử.
 * Đếm số lượng phần tử chẵn, tính tổng và trung bình cộngcủa các phần tử chẵn trong dãy.
 * Liệt kê các phần tử chẵn ra màn hình. Nếu dãy không có phần tử chẵn thì thông báo không tồn tại.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Khởi tạo:
 *     soLuong ← 0
 *     tong ← 0
 * Duyệt A từ trái sang phải.
 * Nếu a[i] chẵn:
 *     soLuong ← soLuong + 1
 *     tong ← tong + a[i]
 * Sau khi duyệt hết dãy:
 *     Nếu soLuong = 0:
 *         dãy không có phần tử chẵn.
 *     Ngược lại:
 *         trungBinh ← tong / soLuong
 *         xuất số lượng, tổng và trung bình cộng.
 * Liệt kê các phần tử a[i] chẵn trong A.
 *
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * thongKeChan(A, n)
 * 1   soLuong ← 0
 * 2   tong ← 0
 * 3   for i ← 0 to n - 1
 * 4       do if a[i] % 2 = 0
 * 5              then soLuong ← soLuong + 1
 * 6                   tong ← tong + a[i]
 * 7   return soLuong, tong
 *
 * LietKeChan(A, n)
 * 1   for i ← 0 to n - 1
 * 2       do if a[i] % 2 = 0
 * 3              then return a[i]
 */

using System;

class DaySoChan
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

    public static int thongKeChan(int[] day, ref long tong)
    {
        int soLuong = 0;
        tong = 0;

        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] % 2 == 0)
            {
                soLuong++;
                tong += day[i];
            }
        }

        return soLuong;
    }

    public static void lietKeChan(int[] day)
    {
        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] % 2 == 0)
                Console.Write(" {0}", day[i]);
        }
    }

    public static void Main(string[] args)
    {
        int[] a = null;
        long tong = 0;

        nhapDaySo(ref a);
        inMangTraiSangPhai(a);

        Console.WriteLine("* Day so chan");

        int soLuong = thongKeChan(a, ref tong);

        if (soLuong == 0)
        {
            Console.WriteLine("Day so khong co phan tu chan.");
            return;
        }

        double trungBinh = (double)tong / soLuong;

        Console.Write("Day so co {0} so chan:", soLuong);
        lietKeChan(a);

        Console.WriteLine(
            " voi tong la {0}, trung binh cong la {1:F2}.", tong, trungBinh);
    }
}