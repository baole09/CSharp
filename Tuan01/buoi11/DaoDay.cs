/*
 * CHƯƠNG TRÌNH ĐẢO DÃY
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2036
 *
 * Phát biểu đề bài:
 * Nhập dãy số nguyên A có n phần tử.
 * Đảo ngược thứ tự các phần tử trong dãy.
 *
 * Ý tưởng:
 *
 * A = (a[0], a[1], ..., a[n-1])
 * Dùng hai chỉ số:
 *     i ← 0
 *     j ← n - 1
 * Hoán vị: a[i] ↔ a[j]
 * Sau mỗi lần hoán vị:
 *     i ← i + 1
 *     j ← j - 1
 * Tiếp tục khi: i < j
 * Khi i >= j: Dừng
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(1)
 * Lưu ý:
 * Chỉ duyệt đến giữa mảng.
 * Nếu duyệt toàn bộ mảng thì mỗi cặp bị hoán vị hai lần và dãy sẽ trở về trạng thái ban đầu.
 *
 * Mã giả:
 *
 * DAO-DAY(A, n)
 * 1   i ← 0
 * 2   j ← n - 1
 * 3
 * 4   while i < j
 * 5       do
 * 6           tmp ← ai
 * 7           ai ← aj
 * 8           aj ← tmp
 * 9
 * 10          i ← i + 1
 * 11          j ← j - 1
 */

using System;

class DaoDay
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

    public static void daoDay(int[] day)
    {
        int i = 0;
        int j = day.Length - 1;

        while (i < j)
        {
            int tmp = day[i];
            day[i] = day[j];
            day[j] = tmp;

            i++;
            j--;
        }
    }

    public static void Main(string[] args)
    {
        int[] daySo = null;

        nhapDaySo(ref daySo);

        Console.WriteLine("* Mang truoc dao:");
        inMangTraiSangPhai(daySo);

        daoDay(daySo);

        Console.WriteLine("* Mang sau khi dao:");
        inMangTraiSangPhai(daySo);
    }
}