// f(x, y) = 2x^2y^2 – 2xy^2 – 7x^2y – 4y^2 + 15xy + 2x^2 – 3x + 10y + 6
/* Y tuong:
 * = xy(2xy - 2y - 7x + 15) - y(4y - 10) + x(2x - 3) + 6
 * = xy[y(2x - 2) - 7x + 15] - y(4y - 10) + x(2x - 3) + 6 // 10(*), 8(+,-)
 * xy = x * y
 * x2 = 2 * x
*/
using System;
class BieuThucNhanh
{
    public static void Main()
    {
        // Khai bao bien
        double x, y, xy, x2, f;

        // Nhap du lieu
        Console.Write("Nhap x: ");
        x = double.Parse(Console.ReadLine());
        Console.Write("Nhap y: ");
        y = double.Parse(Console.ReadLine());
        
        // Xu ly
        xy = x * y;
        x2 = 2 * x;
        f = xy * (xy * 2 - 2 * y - 7 * x + 15) - y * (4 * y - 10) + x * (x2 - 3) + 6;
        
        // Xuat ket qua
        Console.WriteLine("f({0}, {1}) = {2:F2}", x, y, f);
    }
}