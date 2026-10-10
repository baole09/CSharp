/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 22/09/2026
 */

/*
 * CHƯƠNG TRÌNH SẮP XẾP MẢNG TỔNG QUÁT BẰNG DELEGATE
 *
 * Phát biểu đề bài:
 * Viết phương thức sắp xếp mảng tổng quát bằng delegate.
 *
 * Ý tưởng:
 * Delegate soSanh(a,b) quyết định a đứng trước b hay không.
 *
 * Mã giả:
 * 1   for i ← 0 to n-2
 * 2       for j ← i+1 to n-1
 * 3           nếu soSanh(a[j],a[i]) < 0 thì hoán vị
 */
using System;
delegate int SoSanh<T>(T a,T b);
static class SapXepDelegate
{
    public static void Sort<T>(T[] a,SoSanh<T> soSanh)
    {
        for(int i=0;i<=a.Length-2;i++)
            for(int j=i+1;j<=a.Length-1;j++)
                if(soSanh(a[j],a[i])<0){T tam=a[i];a[i]=a[j];a[j]=tam;}
    }
}
class Bai3_3_SapXepBangDelegate
{
    static void Main(string[] args)
    {
        int[] a={5,2,8,1,3};
        SapXepDelegate.Sort(a,(x,y)=>x.CompareTo(y));
        foreach(int x in a)Console.Write(x+" ");Console.WriteLine();
    }
}
