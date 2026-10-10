/* Y tuong:
 * f(x) = 1 + 2x + 3x^2 - 4x^3
 * = 1 + 2*x + x^2*(3 - 4*x) // 6
 * x^2 = x * x; // 1
 * 7 phep toan
*/
using System;

class BieuThucNhanh1
{
    public static void Main()
    {
        // Khai bao bien
        double x, xx, fx;

        // Nhap du lieu
        Console.Write("Moi ban nhap so thuc x: ");
        x = double.Parse(Console.ReadLine());

        // Xu ly
        xx = x * x;
        fx = 1 + 2 * x + xx * (3 - 4 * x);

        // Xuat ket qua 
        Console.WriteLine("f({0}) = {1}", x, fx);
    }
}