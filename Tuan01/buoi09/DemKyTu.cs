using System;

class DemKyTu
{
    public static void nhapDayKyTu(ref char[] day)
    {
        int i, n;
        Console.Write("Moi ban nhap so luong ky tu: ");
        n = int.Parse(Console.ReadLine());
        day = new char[n];

        for(i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = char.Parse(Console.ReadLine());
        }
    }

    public static void inMangTraiSangPhai(char[] day)
    {
        Console.Write("Day co {0} ky tu", day.Length);
        for(int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write(" [{0}]", day[i]);
        }
    }

    public static void demKyTu(char[] day, ref int nguyenAm, ref int phuAm, ref int kySo)
    {
        // Duyet khong quan tam den vi tri
        nguyenAm = phuAm = kySo = 0;
        foreach(char c in day)
        {
            char upper = Char.ToUpper(c);
            if(upper <= '9' && upper >= '0')
                kySo++;
            else if(upper == 'A' || upper == 'E' || upper == 'O' || upper == 'I' || upper == 'U')
                nguyenAm++;
            else if(upper >= 'A' && upper <= 'Z')
                phuAm++;
        }
        Console.WriteLine();
    }

    public static void Main(string []args)
    {
        int nguyenAm = 0, phuAm = 0, kySo = 0;
        char[] a = null;

        nhapDayKyTu(ref a);
        inMangTraiSangPhai(a);
        demKyTu(a, ref nguyenAm, ref phuAm, ref kySo);
        Console.WriteLine("Day ky tu tren co {0} nguyen am, {1} ky tu so va {2} ky tu phu am.", nguyenAm, kySo, phuAm);
    }
}