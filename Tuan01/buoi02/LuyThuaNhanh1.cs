/* Y tuong:
 * a1 -> a2 -> a3 -> a5 -> a10 -> a15 -> a17
*/
using System;
class LuyThuaNhanh1
{
    public static void Main()
    {
        // Khai bao bien
        double a1, a2, a3, a5, a10, a15, a17;

        // Nhap du lieu
        Console.Write("Moi ban nhap so thuc a: ");
        a1 = double.Parse(Console.ReadLine());

        // Xu ly (6 phep nhan)
        a2 = a1 * a1;
        a3 = a1 * a2;
        a5 = a2 * a3;
        a10 = a5 * a5;
        a15 = a5 * a10;
        a17 = a15 * a2;
        
        // Xuat ket qua
        Console.WriteLine("Ket qua: {0}^2= {1}, {0}^5= {2}, {0}^17= {3}", a1, a2, a5, a17);
    }
}