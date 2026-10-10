/*
 * CHƯƠNG TRÌNH TÌM GIÁ TRỊ CHẴN ĐẦU TIÊN VÀ CUỐI CÙNG
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 15/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số nguyên A có n phần tử.
 * Tìm vị trí của giá trị chẵn đầu tiên và giá trị chẵn cuối cùng trong dãy.
 * Nếu dãy không có giá trị chẵn thì thông báo không tồn tại.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Tìm giá trị chẵn đầu tiên:
 *     Duyệt từ trái sang phải.
 *     Nếu a[i] % 2 = 0:
 *         trả về i và dừng.
 *     Nếu duyệt hết dãy:
 *         trả về -1.
 * Tìm giá trị chẵn cuối cùng:
 *     Duyệt từ phải sang trái.
 *     Nếu a[i] % 2 = 0:
 *         trả về i và dừng.
 *     Nếu duyệt hết dãy:
 *         trả về -1.
 * Nếu vị trí đầu tiên = -1: dãy không chứa giá trị chẵn.
 * Ngược lại: xuất vị trí và giá trị chẵn đầu tiên, cuối cùng.
 *
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * ViTriChanDauTien(A, n)
 * 1   for i ← 0 to n - 1
 * 2       do if a[i] % 2 = 0
 * 3              then return i
 * 4   return -1
 *
 * ViTriChanCuoiCung(A, n)
 * 1   for i ← n - 1 downto 0
 * 2       do if a[i] % 2 = 0
 * 3              then return i
 * 4   return -1
 */

using System;

class TimKiemGiaTriChan
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
        while (n <= 0 || n > MAX_N);

        day = new int[n];

        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    public static int viTriChanDauTien(int[] day)
    {
        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] % 2 == 0)
                return i;
        }

        return -1;
    }

    public static int viTriChanCuoiCung(int[] day)
    {
        for (int i = day.Length - 1; i >= 0; i--)
        {
            if (day[i] % 2 == 0)
                return i;
        }

        return -1;
    }

    public static void Main(string[] args)
    {
        int[] daySo = null;

        nhapDaySo(ref daySo);

        int viTriDau =
            viTriChanDauTien(daySo);

        int viTriCuoi =
            viTriChanCuoiCung(daySo);

        if (viTriDau == -1)
        {
            Console.WriteLine(
                "Day so khong chua gia tri chan.");
        }
        else
        {
            Console.WriteLine(
                "Gia tri chan dau tien o vi tri {0} co gia tri {1}.",
                viTriDau,
                daySo[viTriDau]);

            Console.WriteLine(
                "Gia tri chan cuoi cung o vi tri {0} co gia tri {1}.",
                viTriCuoi,
                daySo[viTriCuoi]);
        }
    }
}