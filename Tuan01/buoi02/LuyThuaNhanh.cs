/* Y tuong:
 * a1 -> a2 -> a4 -> a8 -> a12 -> a16 -> a28
*/
using System;
class LuyThuaNhanh
{
    public static void Main()
    {
        // Khai bao bien
        double a1, a2, a4, a8, a12, a16, a28;

        // Nhap du lieu
        Console.Write("Moi ban nhap so thuc a: ");
        a1 = double.Parse(Console.ReadLine());

        // Xu ly
        a2 = a1 * a1;
        a4 = a2 * a2;
        a8 = a4 * a4;
        a12 = a4 * a8;
        a16 = a8 * a8;
        a28 = a12 * a16;

        // Xuat ket qua
        Console.WriteLine("Ket qua: {0}^4 = {1}, {0}^12 = {2}, {0}^28 = {3}", a1, a4, a12, a28);
    }
}
