/* Y tuong:
 * songay = [laNhuan(nam) ? 366 : 365]
*/
using System;
class SoNgayNam
{
    public static void Main()
    {
        // Khai bao bien
        int nam, songay;
        bool laNhuan;

        // Nhap du lieu
        Console.Write("Moi ban nhap nam can tinh: ");
        nam = int.Parse(Console.ReadLine());

        // Xu ly
        laNhuan = (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        songay = Convert.ToInt32(laNhuan) * 366 + Convert.ToInt32(!laNhuan) * 365;
        // songay = laNhuan ? 366 : 365;

        // Xuat ket qua
        Console.WriteLine("Nam {0} co {1} ngay.", nam, songay);
    }
}