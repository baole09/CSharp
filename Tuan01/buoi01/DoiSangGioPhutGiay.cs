using System;
class DoiSangGioPhutGiay
{
    public static void Main()
    {
        Console.Write("Nhap vao tong so giay: ");
        int sum = int.Parse(Console.ReadLine());
        int h = sum/3600;
        int m = (sum%3600)/60;
        int s = sum % 60;
        Console.WriteLine("{0} giay co dang {1}:{2}:{3}", sum, h, m, s);
    }
}