/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 21/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP DÃY SỐ NGUYÊN
 *
 * Phát biểu đề bài:
 * Xây dựng lớp dãy số n số nguyên: constructor, Indexer, nhập/xuất,
 * tìm các số chẵn.
 *
 * Ý tưởng:
 * A=(a[0],...,a[n-1]); Indexer this[i] truy cập a[i].
 * Nếu a[i] % 2 = 0 thì a[i] là số chẵn.
 *
 * Mã giả:
 * 1   duyệt i từ 0 đến n-1
 * 2   nếu a[i] % 2 = 0 thì xuất a[i]
 */
using System;
class DaySoNguyen
{
    private int[] day;
    public DaySoNguyen(){day=new int[0];}
    public DaySoNguyen(int n){day=new int[n];}
    public DaySoNguyen(int[] a){day=(int[])a.Clone();}
    public int Length{get{return day.Length;}}
    public int this[int i]{get{return day[i];}set{day[i]=value;}}
    public void Input(){for(int i=0;i<day.Length;i++){Console.Write("a[{0}] = ",i);day[i]=int.Parse(Console.ReadLine()??"0");}}
    public void Output(){for(int i=0;i<day.Length;i++)Console.Write(day[i]+" ");Console.WriteLine();}
    public void TimSoChan(){Console.Write("Cac so chan: ");for(int i=0;i<day.Length;i++)if(day[i]%2==0)Console.Write(day[i]+" ");Console.WriteLine();}
}
class Bai2_3_DaySoNguyen
{
    static void Main(string[] args)
    {
        Console.Write("Nhap n: ");int n=int.Parse(Console.ReadLine()??"0");
        DaySoNguyen a=new DaySoNguyen(n);a.Input();a.Output();a.TimSoChan();
    }
}
