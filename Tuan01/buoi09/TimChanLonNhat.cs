using System;

class TimChanLonNhat
{
    public static void nhapDaySo(ref int[] day)
    {
        // Khai bao bien
        int i, n;

        // Nhap so luong phan tu
        Console.Write("Moi ban nhap so luong phan tu: ");
        n = int.Parse(Console.ReadLine());
        // Tao mang cac phan tu
        day = new int[n];
        // Nhap gia tri cho tung phan tu
        for(i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = int.Parse(Console.ReadLine());
        }
    }

    public static void inMangTraiSangPhai(int[] day)
    {
        // In so phan tu
        Console.Write("Day so co {0} phan tu.", day.Length);
        // Duyet day tu dau ve cuoi
        for(int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write(" {0}", day[i]);
        }
        Console.WriteLine(); // Xuong dong
    }

    public static int viTriChanLonNhat(int[] day)
    {
        int viTriMax;
        viTriMax = -1; // chưa tìm thấy
        // Duyệt dãy từ đầu về cuối
        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] % 2 == 0)// tìm thấy phần tử thỏa
            {
                if (viTriMax == -1)// đầu tiên
                viTriMax = i;
                else// đã tìm thấy
                {
                    if (day[viTriMax] < day[i])// không tối ưu
                    {
                        viTriMax = i;
                    }
                }
            }
        }
        return viTriMax;
    }
    public static void Main(string[] args)
    {
        // Khai báo
        int[] a = null;
        int vtMax;
        // Dãy số A
        nhapDaySo(ref a);
        inMangTraiSangPhai(a);
        vtMax = viTriChanLonNhat(a);
        if(vtMax == -1)
            Console.WriteLine("Day so khong chua so chan.");
        else
            Console.WriteLine("Day so co so chan lon nhat la {0} nam o vi tri {1}.", a[vtMax], vtMax);
    }
}