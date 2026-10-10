using System;

class SoSanh
{
    public static void Main()
    {
        // Khai bao bien
        double a, b;
        bool laNhoHon, laNhoHonBang, laLonHon, laLonHonBang, laBang, laKhacNhau;
        
        // Nhap du lieu
        Console.Write("Moi ban nhap so a: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Moi ban nhap so b: ");
        b = double.Parse(Console.ReadLine());

        // Xu ly
        laNhoHon = (a < b);
        laNhoHonBang = (a <= b);
        laLonHon = (a > b);
        laLonHonBang = (a >= b);
        laBang = (a == b);
        laKhacNhau = (a != b);

        // Xuat du lieu
        Console.WriteLine("Ket qua so sanh hai so thuc {0:#,#.00} va {1:#,#.00}:", a, b);
        Console.WriteLine("{0:#,#.00} < {1:#,#.00} = {2}", a, b, laNhoHon);
        Console.WriteLine("{0:#,#.00} <= {1:#,#.00} = {2}", a, b, laNhoHonBang);
        Console.WriteLine("{0:#,#.00} > {1:#,#.00} = {2}", a, b, laLonHon);
        Console.WriteLine("{0:#,#.00} >= {1:#,#.00} = {2}", a, b, laLonHonBang);
        Console.WriteLine("{0:#,#.00} == {1:#,#.00} = {2}", a, b, laBang);
        Console.WriteLine("{0:#,#.00} != {1:#,#.00} = {2}", a, b, laKhacNhau);  
    }
}