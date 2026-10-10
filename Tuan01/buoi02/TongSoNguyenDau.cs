/* Y tuong:
 * S = 1 + 2 + 3 + ... + n
 * S = n + (n-1) + (n-2) + ... + 1
 * 2S = (1+n) + (2+n-1) + (3+n-2) + ... + (n+1)
 * 2S = (n+1) + (n+1) + (n+1) + ... + (n+1)
 * 2S = n*(n+1)
 * S = n*(n+1)/2
*/
using System;

class TongSoNguyenDau
{
    public static void Main()
    {
        // Khai bao bien
        int n, S;

        // Nhap du lieu
        Console.Write("Moi ban nhap so nguyen: ");
        n = int.Parse(Console.ReadLine());

        // Xu ly
        S = n * (n + 1) / 2;

        // Xuat ket qua
        Console.WriteLine("S = 1 + 2 + 3 + ... + {0} = {1}", n, S);
    }
}