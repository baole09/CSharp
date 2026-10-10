using System;

class DoiSangGiay
{
    public static void Main()
    {
        Console.Write("Nhap so gio: ");
        int h = int.Parse(Console.ReadLine());
        Console.Write("Nhap so phut: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Nhap so giay: ");
        int s = int.Parse(Console.ReadLine());
        Console.WriteLine("Tong so giay cua {0}:{1}:{2} la {3} giay", h, m, s, h*3600 + m*60 + s);
    }
}