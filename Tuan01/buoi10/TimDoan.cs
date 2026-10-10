// Buổi 10 - Bài tập cơ bản - Bài 4: Tìm đoạn
// File: TimDoan.cs
// Tìm đoạn con liên tiếp [i, j] DÀI NHẤT có tổng bằng k.
// Kỹ thuật: mảng tổng tiền tố (prefix sum) -> tổng đoạn [i, j] tính trong O(1),
//           tổng thể O(n^2) thay vì O(n^3) nếu cộng lại từ đầu mỗi lần.
using System;
using System.Globalization;

namespace NMLT.Buoi10
{
    class TimDoan
    {
        const int MAX_N = 500;

        public static void nhapDaySo(ref double[] day)
        {
            int n;
            do
            {
                Console.Write("Moi ban nhap so luong phan tu: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > MAX_N);

            day = new double[n];
            for (int i = 0; i <= n - 1; i++)
            {
                do
                {
                    Console.Write("Phan tu {0}: ", i);
                } while (!double.TryParse(Console.ReadLine(), NumberStyles.Float,
                                          CultureInfo.InvariantCulture, out day[i]));
            }
        }

        public static void inMangTraiSangPhai(double[] day)
        {
            Console.Write("Day so co {0} phan tu:", day.Length);
            for (int i = 0; i <= day.Length - 1; i++)
                Console.Write(" {0}", day[i].ToString("G", CultureInfo.InvariantCulture));
            Console.WriteLine();
        }

        public static void inDayCon(double[] day, int from, int to)
        {
            for (int i = from; i <= to; i++)
                Console.Write(" {0}", day[i].ToString("G", CultureInfo.InvariantCulture));
        }

        // Trả về true nếu tìm thấy; fromMax/toMax là đoạn dài nhất, ưu tiên i nhỏ nhất khi bằng độ dài
        public static bool timDoanTongBangK(double[] day, double k, ref int fromMax, ref int toMax)
        {
            int n = day.Length;

            // prefix[i]    = a[0] + ... + a[i-1]
            // prefixAbs[i] = |a[0]| + ... + |a[i-1]|  (dùng để ước lượng sai số tích lũy)
            double[] prefix = new double[n + 1];
            double[] prefixAbs = new double[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefix[i + 1] = prefix[i] + day[i];
                prefixAbs[i + 1] = prefixAbs[i] + Math.Abs(day[i]);
            }

            fromMax = -1; toMax = -1;
            int doDaiMax = 0;

            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = i; j <= n - 1; j++)
                {
                    double tong = prefix[j + 1] - prefix[i];
                    // Sai số tuyệt đối tỉ lệ với độ lớn của các số hạng, KHÔNG dùng == cố định
                    double tol = 1e-9 * (1.0 + Math.Abs(k) + (prefixAbs[j + 1] - prefixAbs[i]));

                    if (Math.Abs(tong - k) <= tol && (j - i + 1) > doDaiMax)
                    {
                        doDaiMax = j - i + 1;
                        fromMax = i;
                        toMax = j;
                    }
                }
            }

            return fromMax != -1;
        }

        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            double[] a = null;
            double k;
            int i = 0, j = 0;

            nhapDaySo(ref a);
            inMangTraiSangPhai(a);

            do
            {
                Console.Write("Moi ban nhap so k: ");
            } while (!double.TryParse(Console.ReadLine(), NumberStyles.Float,
                                      CultureInfo.InvariantCulture, out k));

            if (!timDoanTongBangK(a, k, ref i, ref j))
            {
                Console.WriteLine("Day so khong co doan nao co tong bang {0}.",
                                  k.ToString("G", CultureInfo.InvariantCulture));
            }
            else
            {
                Console.Write("Doan [{0}, {1}] dai nhat co tong bang {2}:",
                              i, j, k.ToString("G", CultureInfo.InvariantCulture));
                inDayCon(a, i, j);
                Console.WriteLine();
            }
        }
    }
}
