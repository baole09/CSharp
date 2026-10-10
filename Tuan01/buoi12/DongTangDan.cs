// Buổi 12 - Bài tập cơ bản - Bài 4: Liệt kê dòng tăng dần
// File: DongTangDan.cs
// Kỹ thuật: duyệt THEO DÒNG. Với mỗi dòng, kiểm tra tính tăng dần bằng cách
//   duyệt các cặp cột kề nhau (ic, ic+1), thoát sớm khi gặp phản ví dụ.
using System;
using System.Globalization;

namespace NMLT.Buoi12
{
    class DongTangDan
    {
        const int MAX_DIM = 100;

        public static void nhapMang(ref int[,] a)
        {
            int nd, nc;
            do
            {
                Console.Write("Moi ban nhap so dong: ");
            } while (!int.TryParse(Console.ReadLine(), out nd) || nd <= 0 || nd > MAX_DIM);
            do
            {
                Console.Write("Moi ban nhap so cot: ");
            } while (!int.TryParse(Console.ReadLine(), out nc) || nc <= 0 || nc > MAX_DIM);

            a = new int[nd, nc];
            for (int id = 0; id <= nd - 1; id++)
                for (int ic = 0; ic <= nc - 1; ic++)
                {
                    do
                    {
                        Console.Write("+ Nhap phan tu [{0}, {1}] = ", id, ic);
                    } while (!int.TryParse(Console.ReadLine(), out a[id, ic]));
                }
        }

        public static void xuatMang(int[,] a)
        {
            Console.WriteLine("Mang co {0} dong x {1} cot:", a.GetLength(0), a.GetLength(1));
            for (int id = 0; id <= a.GetLength(0) - 1; id++)
            {
                for (int ic = 0; ic <= a.GetLength(1) - 1; ic++)
                    Console.Write("{0,7}", a[id, ic]);
                Console.WriteLine();
            }
        }

        // Kiểm tra dòng "id" của ma trận a có tăng dần không (dòng 1 cột luôn coi là tăng dần)
        private static bool dongLaTangDan(int[,] a, int id)
        {
            for (int ic = 0; ic <= a.GetLength(1) - 2; ic++)
                if (a[id, ic] >= a[id, ic + 1])
                    return false;
            return true;
        }

        // Trả về mảng chỉ số các dòng tăng dần
        public static int[] timDongTangDan(int[,] a)
        {
            int nd = a.GetLength(0);
            int[] kq = new int[nd];
            int dem = 0;

            for (int id = 0; id <= nd - 1; id++)
                if (dongLaTangDan(a, id))
                    kq[dem++] = id;

            Array.Resize(ref kq, dem);
            return kq;
        }

        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            int[,] a = null;
            nhapMang(ref a);
            xuatMang(a);

            int[] dsDong = timDongTangDan(a);

            if (dsDong.Length == 0)
            {
                Console.WriteLine("Khong co dong nao tao thanh day tang.");
            }
            else
            {
                Console.Write("Cac dong tao thanh day tang:");
                for (int i = 0; i <= dsDong.Length - 1; i++)
                    Console.Write(" {0}", dsDong[i]);
                Console.WriteLine();
            }
        }
    }
}
