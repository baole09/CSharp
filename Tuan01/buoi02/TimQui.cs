/* Y tuong:
 * [1, 3] = Qui(1); [4, 6] = Qui(2); [7, 9] = Qui(3); [10, 12] = Qui(4)
 * qui = [(thang - 1)/ 3] + 1
*/
using System;
class TimQui
{
    public static void Main()
    {
        // Khai bao bien
        int x, qui;

        // Nhap du lieu
        Console.Write("Moi ban nhap thang: ");
        x = int.Parse(Console.ReadLine());

        // Xu ly
        qui = ((x - 1) / 3) + 1;

        // Xuat ket qua
        Console.WriteLine("Thang {0} thuoc qui {1}", x, qui);
    }
}