/* Y tuong:
 * n^278 = n^256 + n^16 + n^4 + n^2
 * n^2 = n * n % 100
 * n^4 = n^2 * n^2 % 100
 * n^16 = n^8 * n^8 % 100
 * n^256 = n^128 * n^128 % 100
*/
using System;
class HaiChuSoCuoi
{
    public static void Main()
    {
        // Khai bao bien
        int n, n2, n4, n8, n16, n32, n64, n128, n256, kq;

        // Nhap du lieu
        Console.Write("Moi ban nhap so nguyen n: ");
        n = int.Parse(Console.ReadLine());

        // Xu ly
        n2 = n * n % 100;
        n4 = n2 * n2 % 100;
        n8 = n4 * n4 % 100;
        n16 = n8 * n8 % 100;
        n32 = n16 * n16 % 100;
        n64 = n32 * n32 % 100;
        n128 = n64 * n64 % 100;
        n256 = n128 * n128 % 100;

        kq = n256 * n16 % 100;
        kq = kq * n4 % 100;
        kq = kq * n2 % 100;

        // Xuat ket qua
        Console.WriteLine("{0}^278 co 2 chu so cuoi cung la {1}", n, kq);
    }
}