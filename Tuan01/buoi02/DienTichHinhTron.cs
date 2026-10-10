/* Y tuong:
 * C = 2 * pi * r
 * --> r = C / (2 * pi)
 * --> S = pi * r^2
*/
using System;
class DienTichHinhTron
{
    public static void Main()
    {
        // Khai bao bien
        double C, r, S;

        // Nhap du lieu
        Console.Write("Moi ban nhap chu vi hinh tron: ");
        C = double.Parse(Console.ReadLine());

        // Xu Ly
        r = C / (2 * Math.PI);
        S = Math.PI * r * r;

        // Xuat ket qua
        Console.WriteLine("Hinh tron co chu vi {0} co dien tich {1:F2}.", C, S);
    }
}