/*
Cho dãy số nguyên A và B có n và m phần tử (n ≤ 100). Hãy nhập dãy số nguyên A từ bàn phím,
phát sinh ngẫu nhiên dãy số nguyên B có giá trị trong đoạn [300, 500], xuất dãy số nguyên A và
B ra màn hình theo thứ tự từ trái sang phải và từ phải sang trái.
*/
using System;
class NhapXuatDaySoNguyen
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

    public static int[] sinhNgauNhienDaySo(int n, int vmin, int vmax)
    {
        // Khai bao bien
        int i;
        int[] day = null;
        // Tao mang cac phan tu
        day = new int[n];
        // Sinh ngau nhien gia tri cho tung phan tu
        Random rand = new Random(); // Doi tuong sinh so ngau nhien
        for(i = 0; i <= day.Length - 1; i++)
        {
            day[i] = rand.Next(vmin, vmax);
        }
        return day;
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

    public static void inMangPhaiSangTrai(int[] day)
    {
        // In so phan tu
        Console.Write("Day so co {0} phan tu.", day.Length);
        // Duyet day tu cuoi ve dau
        for(int i = day.Length - 1; i >= 0; i--)
        {
            Console.Write(" {0}", day[i]);
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        // Khai bao mang 1 chieu
        int[] a = null, b = null;
        int n;

        // Day so A
        Console.WriteLine("Day so A: ");
        nhapDaySo(ref a);
        inMangTraiSangPhai(a);
        inMangPhaiSangTrai(a);

        // Day so B
        Console.WriteLine("Day so B: ");
        Console.Write("Moi ban nhap so luong phan tu: ");
        n = int.Parse(Console.ReadLine());
        b = sinhNgauNhienDaySo(n, 300, 500);
        inMangTraiSangPhai(b);
        inMangPhaiSangTrai(b);
    }
}