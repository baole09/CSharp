/*
 * CHƯƠNG TRÌNH TÌM ĐOẠN DƯƠNG DÀI NHẤT
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 16/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số thực A có n phần tử.
 * Tìm đoạn gồm các phần tử dương liên tiếp có độ dài lớn nhất.
 *
 * Ý tưởng:
 *
 * A = (a[0], a[1], ..., a[n-1])
 *
 * Đoạn dương là đoạn:
 * a[i] > 0, a[i+1] > 0, ..., a[j] > 0
 *
 * Dùng biến dauDoan để lưu vị trí bắt đầu của đoạn dương hiện tại.
 *
 * Nếu a[i] > 0:
 *     Nếu chưa có đoạn dương:
 *         dauDoan ← i
 *
 *     Độ dài đoạn hiện tại:
 *         i - dauDoan + 1
 *
 *     Nếu độ dài hiện tại lớn hơn độ dài lớn nhất:
 *         Cập nhật viTriDau và viTriCuoi
 *
 * Nếu ai <= 0:
 *     Kết thúc đoạn dương hiện tại:
 *         dauDoan ← -1
 *
 * Mã giả:
 *
 * DoanDuongDaiNhat(A, n)
 * 1   viTriDau ← -1
 * 2   viTriCuoi ← -1
 * 3   doDaiMax ← 0
 * 4   dauDoan ← -1
 * 5
 * 6   for i ← 0 to n - 1
 * 7       do
 * 8           if a[i] > 0
 * 9               then if dauDoan = -1
 * 10                      then dauDoan ← i
 * 11
 * 12                    if i - dauDoan + 1 > doDaiMax
 * 13                      then doDaiMax ← i - dauDoan + 1
 * 14                           viTriDau ← dauDoan
 * 15                           viTriCuoi ← i
 * 16
 * 17           else
 * 18               dauDoan ← -1
 * 19
 * 20   if viTriDau ≠ -1
 * 21       then return TRUE
 * 22   else
 * 23       return FALSE
 */

using System;

class DoanDuongDaiNhat
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

    public static void inMangTraiSangPhai(double[] day)
    {
        Console.Write("Day so co {0} phan tu:", day.Length);

        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write(" {0}", day[i]);

        Console.WriteLine();
    }

    private static bool laSoDuong(double x)
    {
        return x > 0;
    }

    public static bool timDoanDuongDaiNhat(
        double[] day,
        ref int viTriDau,
        ref int viTriCuoi)
    {
        viTriDau = -1;
        viTriCuoi = -1;

        int doDaiMax = 0;
        int dauDoan = -1;

        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (laSoDuong(day[i]))
            {
                // Nếu chưa có đoạn dương thì mở đoạn mới
                if (dauDoan == -1)
                    dauDoan = i;

                // Cập nhật đoạn dương dài nhất
                if (i - dauDoan + 1 > doDaiMax)
                {
                    doDaiMax = i - dauDoan + 1;
                    viTriDau = dauDoan;
                    viTriCuoi = i;
                }
            }
            else
            {
                // Gặp số không dương thì kết thúc đoạn
                dauDoan = -1;
            }
        }

        return viTriDau != -1;
    }

    public static void inDayCon(
        double[] day,
        int viTriDau,
        int viTriCuoi)
    {
        for (int i = viTriDau; i <= viTriCuoi; i++)
            Console.Write(" {0}", day[i]);

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        double[] daySo = null;
        int viTriDau = 0;
        int viTriCuoi = 0;

        nhapDaySo(ref daySo);
        inMangTraiSangPhai(daySo);

        if (!timDoanDuongDaiNhat(
            daySo,
            ref viTriDau,
            ref viTriCuoi))
        {
            Console.WriteLine("Day so khong co phan tu duong.");
        }
        else
        {
            Console.Write(
                "Doan duong [{0}, {1}] dai nhat:",
                viTriDau,
                viTriCuoi);

            inDayCon(daySo, viTriDau, viTriCuoi);
        }
    }
}