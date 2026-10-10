using System;

class LietKeAm
{
    public static void nhapDaySo(ref double[] day)
    {
        // Khai bao bien
        int i, n;

        // Nhap du lieu
        Console.Write("Moi ban nhap so luong phan tu: ");
        n = int.Parse(Console.ReadLine());

        // Tao mang
        day = new double[n];
        for(i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Nhap phan tu {0}: ", i);
            day[i] = double.Parse(Console.ReadLine());
        }   
    }   

    public static void inMangTraiSangPhai(double[] day)
    {
        Console.Write("Day so co {0} phan tu:", day.Length);
        for(int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write(" {0}", day[i]);
        }
        Console.WriteLine();
    }

    public static void lietKePhanTuAm(double[] day)
    {
        Console.Write("Cac phan tu am co trong mang:");
        for(int i = 0; i <= day.Length - 1; i++)
        {
            if(day[i] < 0)
            {
                Console.Write(" {0}", day[i]);
            }
        }
        Console.WriteLine();
    }

    public static void Main(string []args)
    {
        // Khai bao mang 1 chieu
        double[] a = null;

        nhapDaySo(ref a);
        inMangTraiSangPhai(a);
        lietKePhanTuAm(a);
    }
}