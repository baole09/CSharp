using System;
class TinhTong
{
    public static void Main()
    {
        // Khai báo biến
        int n, kq;// biến nhập / xuất
        int dv, chuc, tram, ngan;// biến trung gian
        // Nhập dữ liệu
        Console.Write("Moi ban nhap so nguyen n (co bon chu so): ");
        n = int.Parse(Console.ReadLine());
        // Xử lý
        dv = (n / 1 ) % 10;
        chuc = (n / 10 ) % 10;
        tram = (n / 100 ) % 10;
        ngan = (n / 1000) % 10;
        kq = dv + chuc + tram + ngan;
        // Xuất dữ liệu
        Console.Write("{0} = {1} + {2} + {3} + {4} = {5}.", n, ngan, tram, chuc,
        dv, kq);
        // Dừng chương trình chờ nhập phím
        //Console.Read();
    }
}