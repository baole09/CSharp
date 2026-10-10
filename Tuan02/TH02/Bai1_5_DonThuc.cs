/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 20/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP ĐƠN THỨC
 *
 * Phát biểu đề bài:
 * P(x)=a*x^n, a là số thực, n không âm. Tính P(x) và đạo hàm.
 *
 * Ý tưởng:
 * P(x)=a*x^n
 * P'(x)=a*n*x^(n-1), n>0; nếu n=0 thì P'(x)=0.
 *
 * Mã giả:
 * 1   GiaTri(x) ← a*x^n
 * 2   nếu n=0: trả về 0
 * 3   ngược lại: trả về DonThuc(a*n,n-1)
 */
using System;
class DonThuc
{
    private double a; private int n;
    public DonThuc(){a=0;n=0;}
    public DonThuc(double a,int n)
    {
        if(n<0)throw new ArgumentException("Bac phai khong am.");
        this.a=a;this.n=n;
    }
    public double GiaTri(double x){return a*Math.Pow(x,n);}
    public DonThuc DaoHam(){return n==0?new DonThuc(0,0):new DonThuc(a*n,n-1);}
    public override string ToString(){return n==0?a.ToString():a+"x^"+n;}
}
class Bai1_5_DonThuc
{
    static void Main(string[] args)
    {
        Console.Write("Nhap he so a: ");double a=double.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap bac n: ");int n=int.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap x: ");double x=double.Parse(Console.ReadLine()??"0");
        DonThuc p=new DonThuc(a,n);
        Console.WriteLine("P(x)={0}",p);Console.WriteLine("P({0})={1}",x,p.GiaTri(x));
        Console.WriteLine("P'(x)={0}",p.DaoHam());
    }
}
