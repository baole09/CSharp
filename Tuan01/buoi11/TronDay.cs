/*
 * CHƯƠNG TRÌNH TRỘN HAI DÃY TĂNG DẦN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập hai dãy số nguyên A và B đã được sắp xếp tăng dần.
 * Trộn hai dãy thành một dãy C tăng dần.
 * Không sử dụng thuật toán sắp xếp.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * B = (b[0], b[1], ..., b[m-1])
 * C = (c[0], c[1], ..., c[n+m-1])
 * Dùng ba chỉ số:
 *     i ← 0: vị trí đang xét trong A
 *     j ← 0: vị trí đang xét trong B
 *     k ← 0: vị trí đang ghi trong C
 * Khi i < n và j < m:
 *     Nếu a[i] <= b[j]:
 *         c[k] ← a[i]
 *         i ← i + 1
 *     Ngược lại:
 *         c[k] ← b[j]
 *         j ← j + 1
 *     k ← k + 1
 * Khi một dãy đã hết phần tử:
 *     Đưa toàn bộ phần còn lại của dãy kia vào C.
 * Vì A và B đã tăng dần nên C thu được cũng tăng dần.
 * Kiểm tra điều kiện: A tăng dần và B tăng dần.
 * Nếu một trong hai dãy không tăng dần thì không thực hiện trộn.
 * Độ phức tạp:
 *     Thời gian: O(n + m)
 *     Bộ nhớ phụ: O(n + m)
 *
 * Mã giả:
 * Tron(A, n, B, m)
 * 1   tạo C có n + m phần tử
 * 2   i ← 0
 * 3   j ← 0
 * 4   k ← 0
 * 5   while i < n và j < m
 * 6       do
 * 7           if a[i] <= b[j]
 * 8               then c[k] ← a[i]
 * 9                    i ← i + 1
 * 10          else
 * 11              c[k] ← b[j]
 * 12              j ← j + 1
 * 13          k ← k + 1
 * 14
 * 15  while i < n
 * 16      do c[k] ← a[i]
 * 17         i ← i + 1
 * 18         k ← k + 1
 * 19
 * 20  while j < m
 * 21      do c[k] ← b[j]
 * 22         j ← j + 1
 * 23         k ← k + 1
 * 24
 * 25  return C
 */

using System;

class TronDay
{
    const int MAX_N = 500;

    public static void nhapDaySo(string ten, ref int[] day)
    {
        int n;

        do
        {
            Console.Write(
                "Moi ban nhap so luong phan tu day {0}: ",
                ten);

            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n <= 0 || n > MAX_N);

        day = new int[n];

        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("{0}[{1}]: ", ten, i);
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

    public static bool laTangDan(int[] day)
    {
        for (int i = 0; i <= day.Length - 2; i++)
        {
            if (day[i] > day[i + 1])
                return false;
        }

        return true;
    }

    public static int[] tron(int[] a, int[] b)
    {
        int[] c = new int[a.Length + b.Length];

        int i = 0;
        int j = 0;
        int k = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i] <= b[j])
            {
                c[k] = a[i];
                i++;
            }
            else
            {
                c[k] = b[j];
                j++;
            }

            k++;
        }

        while (i < a.Length)
        {
            c[k] = a[i];
            i++;
            k++;
        }

        while (j < b.Length)
        {
            c[k] = b[j];
            j++;
            k++;
        }

        return c;
    }

    public static void Main(string[] args)
    {
        int[] a = null;
        int[] b = null;

        nhapDaySo("A", ref a);
        nhapDaySo("B", ref b);

        Console.WriteLine("* Day A:");
        inMangTraiSangPhai(a);

        Console.WriteLine("* Day B:");
        inMangTraiSangPhai(b);

        if (!laTangDan(a) || !laTangDan(b))
        {
            Console.WriteLine("Ca hai day vao phai tang dan thi thuat toan tron moi dung.");
            return;
        }

        int[] c = tron(a, b);

        Console.WriteLine("* Day C:");
        inMangTraiSangPhai(c);
    }
}