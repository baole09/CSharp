using System;

class DienTichTamGiac
{
    public static void Main()
    {
        Console.Write("Nhap do dai canh a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhap do dai canh b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Nhap do dai canh c: ");
        double c = double.Parse(Console.ReadLine());
        double p = (a + b + c) / 2.0;
        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine("Dien tich tam giac S = {0:F2}", S);
    }
}