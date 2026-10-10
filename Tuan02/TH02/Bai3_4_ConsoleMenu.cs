/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 22/09/2026
 */

/*
 * CHƯƠNG TRÌNH CONSOLEMENU VÀ PHƯƠNG TRÌNH BẬC HAI
 *
 * Phát biểu đề bài:
 * Xây dựng ConsoleMenu có sự kiện Choose. Áp dụng cho giải PT bậc 2.
 *
 * Ý tưởng:
 * ConsoleMenu phát sự kiện Choose khi người dùng chọn chức năng.
 * PTBac2Console xử lý chức năng giải phương trình.
 *
 * Mã giả:
 * 1   xuất menu
 * 2   nhập chon
 * 3   phát Choose(chon)
 * 4   lặp đến khi chon = 0
 */
using System;
class ConsoleMenu
{
    public event Action<int> Choose;
    public void Run()
    {
        int chon;
        do
        {
            Console.WriteLine("MENU");Console.WriteLine("1. Giai phuong trinh bac 2");Console.WriteLine("0. Thoat");
            Console.Write("Thuc hien: ");
            if(!int.TryParse(Console.ReadLine(),out chon))chon=-1;
            if(chon!=0)Choose?.Invoke(chon);
        }while(chon!=0);
    }
}
class PTBac2Console:ConsoleMenu
{
    public void GiaiPTBac2()
    {
        Console.Write("Nhap a: ");double a=double.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap b: ");double b=double.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap c: ");double c=double.Parse(Console.ReadLine()??"0");
        if(a==0)
        {
            if(b==0)Console.WriteLine(c==0?"Vo so nghiem.":"Vo nghiem.");
            else Console.WriteLine("x = {0}",-c/b);
            return;
        }
        double delta=b*b-4*a*c;
        if(delta<0)Console.WriteLine("Vo nghiem.");
        else if(delta==0)Console.WriteLine("x1 = x2 = {0}",-b/(2*a));
        else
        {
            double x1=(-b+Math.Sqrt(delta))/(2*a),x2=(-b-Math.Sqrt(delta))/(2*a);
            Console.WriteLine("x1 = {0}",x1);Console.WriteLine("x2 = {0}",x2);
        }
    }
}
class Bai3_4_ConsoleMenu
{
    static void Main(string[] args)
    {
        PTBac2Console app=new PTBac2Console();
        app.Choose+=(x)=>{if(x==1)app.GiaiPTBac2();else Console.WriteLine("Chuc nang khong ton tai.");};
        app.Run();
    }
}
