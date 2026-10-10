// Buổi 11 - Bài tập cơ bản - Bài 2: Xóa phần tử chẵn
// File: XoaChan.cs
// Kỹ thuật: hai chỉ số (đọc / ghi) -> xóa TẤT CẢ phần tử thỏa điều kiện trong O(n).
//   Cách "tìm thấy thì dồn mảng lại" quen thuộc là O(n^2) và rất dễ sai chỉ số
//   khi hai phần tử cần xóa nằm kề nhau (quên lùi i sau khi dồn).
using System;
using System.Globalization;

namespace NMLT.Buoi11
{
    class XoaChan
    {
        const int MAX_N = 500;

        public static void nhapDaySo(ref int[] day)
        {
            int n;
            do
            {
                Console.Write("Moi ban nhap so luong phan tu: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > MAX_N);

            day = new int[n];
            for (int i = 0; i <= n - 1; i++)
            {
                do
                {
                    Console.Write("Phan tu {0}: ", i);
                } while (!int.TryParse(Console.ReadLine(), out day[i]));
            }
        }

        public static void inMangTraiSangPhai(int[] day)
        {
            Console.Write("Day so co {0} phan tu:", day.Length);
            for (int i = 0; i <= day.Length - 1; i++)
                Console.Write(" {0}", day[i]);
            Console.WriteLine();
        }

        private static bool laChan(int x)
        {
            return x % 2 == 0;
        }

        // Xóa mọi phần tử chẵn, mảng thu gọn được trả về qua ref
        public static void xoaChan(ref int[] day)
        {
            int k = 0;   // chỉ số GHI: số phần tử được giữ lại
            for (int i = 0; i <= day.Length - 1; i++)   // chỉ số ĐỌC
            {
                if (!laChan(day[i]))
                {
                    day[k] = day[i];
                    k++;
                }
            }
            Array.Resize(ref day, k);   // cắt bỏ phần đuôi không còn dùng
        }

        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int[] a = null;
            nhapDaySo(ref a);

            Console.WriteLine("* Mang truoc xoa:");
            inMangTraiSangPhai(a);

            xoaChan(ref a);

            Console.WriteLine("* Mang sau khi xoa:");
            if (a.Length == 0)
                Console.WriteLine("Day so rong (moi phan tu deu chan).");
            else
                inMangTraiSangPhai(a);
        }
    }
}
