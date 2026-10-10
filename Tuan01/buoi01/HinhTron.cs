using System;

class HinhTron
{
    public static void Main()
    {
        Console.Write("Nhap ban kinh hinh tron R= ");
        double R = double.Parse(Console.ReadLine());
        Console.WriteLine("Dien tich S = {0:F1}", Math.PI * R * R);
        Console.WriteLine("Chu vi P = {0:F1}", 2 * Math.PI * R);
    }
}