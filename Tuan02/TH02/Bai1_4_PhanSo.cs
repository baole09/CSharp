/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 20/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP PHÂN SỐ
 *
 * Phát biểu đề bài:
 * Constructor mặc nhiên, sao chép và constructor tham số; ToString;
 * overload +,- unary; +,-,*,/ hai ngôi; >,<,>=,<=,==,!=.
 *
 * Ý tưởng:
 * a/b + c/d=(ad+bc)/bd
 * a/b - c/d=(ad-bc)/bd
 * a/b * c/d=ac/bd
 * a/b / c/d=ad/bc
 * Rút gọn bằng UCLN.
 */
using System;
class PhanSo
{
    private long tu,mau;
    public PhanSo(){tu=0;mau=1;}
    public PhanSo(long tu,long mau)
    {
        if(mau==0) throw new ArgumentException("Mau so phai khac 0.");
        this.tu=tu; this.mau=mau; RutGon();
    }
    public PhanSo(PhanSo p){tu=p.tu;mau=p.mau;}
    static long UCLN(long a,long b)
    {
        a=Math.Abs(a);b=Math.Abs(b);
        while(b!=0){long r=a%b;a=b;b=r;}
        return a==0?1:a;
    }
    void RutGon()
    {
        if(mau<0){tu=-tu;mau=-mau;}
        long g=UCLN(tu,mau);tu/=g;mau/=g;
    }
    public override string ToString(){return mau==1?tu.ToString():tu+"/"+mau;}
    public static PhanSo operator +(PhanSo a){return new PhanSo(a.tu,a.mau);}
    public static PhanSo operator -(PhanSo a){return new PhanSo(-a.tu,a.mau);}
    public static PhanSo operator +(PhanSo a,PhanSo b){return new PhanSo(a.tu*b.mau+b.tu*a.mau,a.mau*b.mau);}
    public static PhanSo operator -(PhanSo a,PhanSo b){return new PhanSo(a.tu*b.mau-b.tu*a.mau,a.mau*b.mau);}
    public static PhanSo operator *(PhanSo a,PhanSo b){return new PhanSo(a.tu*b.tu,a.mau*b.mau);}
    public static PhanSo operator /(PhanSo a,PhanSo b)
    {
        if(b.tu==0) throw new DivideByZeroException();
        return new PhanSo(a.tu*b.mau,a.mau*b.tu);
    }
    public static bool operator >(PhanSo a,PhanSo b){return a.tu*b.mau>b.tu*a.mau;}
    public static bool operator <(PhanSo a,PhanSo b){return a.tu*b.mau<b.tu*a.mau;}
    public static bool operator >=(PhanSo a,PhanSo b){return !(a<b);}
    public static bool operator <=(PhanSo a,PhanSo b){return !(a>b);}
    public static bool operator ==(PhanSo a,PhanSo b)
    {
        if(ReferenceEquals(a,b))return true;
        if(a is null||b is null)return false;
        return a.tu*b.mau==b.tu*a.mau;
    }
    public static bool operator !=(PhanSo a,PhanSo b){return !(a==b);}
    public override bool Equals(object obj){return obj is PhanSo p && this==p;}
    public override int GetHashCode(){return (tu,mau).GetHashCode();}
}
class Bai1_4_PhanSo
{
    static void Main(string[] args)
    {
        PhanSo a=new PhanSo(2,3),b=new PhanSo(3,4);
        Console.WriteLine("a={0}",a);Console.WriteLine("b={0}",b);
        Console.WriteLine("a+b={0}",a+b);Console.WriteLine("a-b={0}",a-b);
        Console.WriteLine("a*b={0}",a*b);Console.WriteLine("a/b={0}",a/b);
        Console.WriteLine("-a={0}",-a);Console.WriteLine("a>b: {0}",a>b);
        Console.WriteLine("a<b: {0}",a<b);Console.WriteLine("a==b: {0}",a==b);
    }
}
