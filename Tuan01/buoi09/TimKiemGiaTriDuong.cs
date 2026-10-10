using System;

class TimKiemGiaTriDuong
{
    public static void nhapDaySo(ref double[] day)
    {
        int i, n;
        Console.Write("Moi ban nhap so luong phan tu: ");
        n = int.Parse(Console.ReadLine());

        day = new double[n];

        for(i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ");
            day[i] = double.Parse(Console.ReadLine());
        }
    }

    public static void inMangTraiSangPhai(double[] day)
    {
        Console.Write("Day so co {0} phan tu", day.Length);
        for(int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write(" {0}", day[i]);
        }
        Console.WriteLine();
    }

    public static int timGiaTriDuongDauTien(double[] day)
    {
        int i, viTri;

        viTri = -1; // Gia su chua tim thay 
        for(i = 0; i <= day.Length - 1 && viTri == -1; i++)
        {
            if(day[i] > 0)
            {
                viTri = i;
            }
        }
        return viTri;
    }

    public static void timGiaTriDuongCuoiCung(double[] day, ref int viTri)
    {
        int i;

        viTri = -1; // Gia su chua tim thay 
        for(i = day.Length - 1; i >= 0 && viTri == -1; i--)
        {
            if(day[i] > 0)
            {
                viTri = i;
            }
        }
    }

    public static void Main(string []args)
    {
        double[] a = {-2.3, 5.4, -2.9, 9.7, -3.8};
        int viTriDau, viTriCuoi = 0;

        inMangTraiSangPhai(a);

        viTriDau = timGiaTriDuongDauTien(a);
        timGiaTriDuongCuoiCung(a, ref viTriCuoi);

        if(viTriDau == -1)
        {
            Console.WriteLine("Day khong co gia tri duong.");
        }
        else
        {
            Console.WriteLine("Gia tri duong dau tien o vi tri {0} co gia tri {1}.", viTriDau, a[viTriDau]);
            Console.WriteLine("Gia tri duong dau tien o vi tri {0} co gia tri {1}.", viTriCuoi, a[viTriCuoi]);
        }
    }

}