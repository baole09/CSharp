/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 21/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP MẢNG HAI CHIỀU
 *
 * Phát biểu đề bài:
 * Xây dựng lớp mảng 2 chiều nxm: constructor, Indexer, nhập/xuất,
 * tìm các số nguyên tố.
 *
 * Ý tưởng:
 * A=(a[i,j]). Duyệt toàn bộ ma trận; a[i,j] nguyên tố thì xuất.
 *
 * Mã giả:
 * 1   for i ← 0 to n-1
 * 2       for j ← 0 to m-1
 * 3           nếu a[i,j] nguyên tố thì xuất
 */
using System;
class MangHaiChieu
{
    private int[,] a;
    public MangHaiChieu(){a=new int[0,0];}
    public MangHaiChieu(int n,int m){a=new int[n,m];}
    public MangHaiChieu(int[,] b)
    {
        a=new int[b.GetLength(0),b.GetLength(1)];
        for(int i=0;i<a.GetLength(0);i++)for(int j=0;j<a.GetLength(1);j++)a[i,j]=b[i,j];
    }
    public int SoDong{get{return a.GetLength(0);}}
    public int SoCot{get{return a.GetLength(1);}}
    public int this[int i,int j]{get{return a[i,j];}set{a[i,j]=value;}}
    public void Input(){for(int i=0;i<SoDong;i++)for(int j=0;j<SoCot;j++){Console.Write("a[{0},{1}] = ",i,j);a[i,j]=int.Parse(Console.ReadLine()??"0");}}
    public void Output(){for(int i=0;i<SoDong;i++){for(int j=0;j<SoCot;j++)Console.Write("{0,5}",a[i,j]);Console.WriteLine();}}
    bool LaNguyenTo(int n){if(n<2)return false;for(int i=2;i*i<=n;i++)if(n%i==0)return false;return true;}
    public void TimSoNguyenTo(){Console.Write("Cac so nguyen to: ");for(int i=0;i<SoDong;i++)for(int j=0;j<SoCot;j++)if(LaNguyenTo(a[i,j]))Console.Write(a[i,j]+" ");Console.WriteLine();}
}
class Bai2_4_MangHaiChieu
{
    static void Main(string[] args)
    {
        Console.Write("Nhap n: ");int n=int.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap m: ");int m=int.Parse(Console.ReadLine()??"0");
        MangHaiChieu a=new MangHaiChieu(n,m);a.Input();a.Output();a.TimSoNguyenTo();
    }
}
