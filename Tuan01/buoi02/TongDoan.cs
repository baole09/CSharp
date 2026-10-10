/* Y tuong
 * a <= b
 * S = sum[a,b]
 * S = sum[1,b] - sum[1, a-1]
 * sum[1, b] = b*(b+1)/2
 * sum[1, a-1] = (a-1)*(a)/2
*/
using System;

class TongDoan
{
    public static void Main()
    {
        // Khai bao bien
        int a, b;
        double sumB, sumA, S;

        // Nhap du lieu
        Console. Write("Moi ban nhap so a, b: ");
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);

        // Xu ly
        sumB = b * (b + 1)/ 2.0;
        sumA = (a - 1) * a /2.0;
        S = sumB - sumA;

        // Xuat ket qua
        Console.WriteLine("Tong cua cac so trong doan [{0}, {1}] la {2}", a, b, S); 
    }
}