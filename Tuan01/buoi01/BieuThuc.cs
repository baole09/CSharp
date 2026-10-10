using System;

class BieuThuc
{
    public static void Main()
    {
        Console.Write("Moi ban nhap so a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Moi ban nhap so b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Cac ket qua tinh toan:");
        Console.WriteLine("{0,-5} + {1,5} = {2,5}", a, b, a + b);
        Console.WriteLine("{0,-5} - {1,5} = {2,5}", a, b, a - b);
        Console.WriteLine("{0,-5} * {1,5} = {2,5}", a, b, a * b);
        Console.WriteLine("{0,-5} / {1,5} = {2,5}", a, b, a / b);
        Console.WriteLine("{0,-5} % {1,5} = {2,5}", a, b, a % b);
        Console.WriteLine("{0,-5} / {1,5} = {2,5:F2}", a, b, a/(double)b);
    }
}