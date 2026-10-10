using System;

class TinhMu
{
    public static void Main()
    {
        Console.Write("Nhap so thuc a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhap so mu n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Ket qua {0}^{1} = {2}", a, n, Math.Pow(a, n));
    }
}
