/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 21/09/2026
 */

/*
 * CHƯƠNG TRÌNH TỔNG DÃY PHÂN SỐ
 *
 * Phát biểu đề bài:
 * Xây dựng lớp chứa n phân số và tính tổng n phân số.
 *
 * Ý tưởng:
 * S = p[0] + p[1] + ... + p[n-1].
 * Dùng toán tử + của lớp PhanSo.
 *
 * Mã giả:
 * 1   S ← 0/1
 * 2   for i ← 0 to n-1: S ← S + p[i]
 * 3   return S
 */
using System;
class PhanSo
{
    private long tu,mau;
    public PhanSo(long tu=0,long mau=1){if(mau==0)throw new ArgumentException();this.tu=tu;this.mau=mau;RutGon();}
    static long UCLN(long a,long b){a=Math.Abs(a);b=Math.Abs(b);while(b!=0){long r=a%b;a=b;b=r;}return a==0?1:a;}
    void RutGon(){if(mau<0){tu=-tu;mau=-mau;}long g=UCLN(tu,mau);tu/=g;mau/=g;}
    public static PhanSo operator +(PhanSo a,PhanSo b){return new PhanSo(a.tu*b.mau+b.tu*a.mau,a.mau*b.mau);}
    public override string ToString(){return mau==1?tu.ToString():tu+"/"+mau;}
}
class DayPhanSo
{
    private PhanSo[] day;
    public DayPhanSo(int n){day=new PhanSo[n];}
    public PhanSo this[int i]{get{return day[i];}set{day[i]=value;}}
    public void Input()
    {
        for(int i=0;i<day.Length;i++)
        {
            Console.WriteLine("Phan so thu {0}:",i+1);
            Console.Write("Tu: ");long tu=long.Parse(Console.ReadLine()??"0");
            Console.Write("Mau: ");long mau=long.Parse(Console.ReadLine()??"1");
            day[i]=new PhanSo(tu,mau);
        }
    }
    public PhanSo Tong(){PhanSo s=new PhanSo();for(int i=0;i<day.Length;i++)s+=day[i];return s;}
}
class Bai2_4_DayPhanSo
{
    static void Main(string[] args)
    {
        Console.Write("Nhap n: ");int n=int.Parse(Console.ReadLine()??"0");
        DayPhanSo a=new DayPhanSo(n);a.Input();Console.WriteLine("Tong = {0}",a.Tong());
    }
}
