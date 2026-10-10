/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 20/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP ĐA THỨC
 *
 * Phát biểu đề bài:
 * P(x)=a[0]+a[1]x+...+a[n]x^n. Có constructor, Indexer,
 * nhập/xuất và tính giá trị tại x.
 *
 * Ý tưởng:
 * P(x)=Σ(a[i]*x^i), i=0..n.
 *
 * Mã giả:
 * 1   kq ← 0
 * 2   for i ← 0 to n
 * 3       kq ← kq + a[i]*x^i
 * 4   return kq
 */
using System;
class DaThuc
{
    private double[] heSo;
    public DaThuc(){heSo=new double[1];}
    public DaThuc(int n){heSo=new double[n+1];}
    public DaThuc(double[] a){heSo=(double[])a.Clone();}
    public int Bac{get{return heSo.Length-1;}}
    public double this[int i]{get{return heSo[i];}set{heSo[i]=value;}}
    public void Input(){for(int i=0;i<heSo.Length;i++){Console.Write("a[{0}] = ",i);heSo[i]=double.Parse(Console.ReadLine()??"0");}}
    public void Output(){for(int i=Bac;i>=0;i--){if(i<Bac)Console.Write(" + ");Console.Write("{0}x^{1}",heSo[i],i);}Console.WriteLine();}
    public double GiaTri(double x){double kq=0;for(int i=0;i<heSo.Length;i++)kq+=heSo[i]*Math.Pow(x,i);return kq;}
}
class Bai2_3_DaThuc
{
    static void Main(string[] args)
    {
        Console.Write("Nhap bac n: ");int n=int.Parse(Console.ReadLine()??"0");
        DaThuc p=new DaThuc(n);p.Input();Console.Write("P(x) = ");p.Output();
        Console.Write("Nhap x: ");double x=double.Parse(Console.ReadLine()??"0");
        Console.WriteLine("P({0}) = {1}",x,p.GiaTri(x));
    }
}
