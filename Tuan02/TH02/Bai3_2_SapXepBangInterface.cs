/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 22/09/2026
 */

/*
 * CHƯƠNG TRÌNH SẮP XẾP MẢNG TỔNG QUÁT BẰNG INTERFACE
 *
 * Phát biểu đề bài:
 * Viết phương thức sắp xếp mảng tổng quát bằng interface,
 * mô phỏng Array.Sort.
 *
 * Ý tưởng:
 * T có IComparable<T>. So sánh a[j] và a[i] bằng CompareTo.
 *
 * Mã giả:
 * 1   for i ← 0 to n-2
 * 2       for j ← i+1 to n-1
 * 3           nếu a[j].CompareTo(a[i]) < 0 thì hoán vị
 */
using System;
static class SapXepInterface
{
    public static void Sort<T>(T[] a) where T:IComparable<T>
    {
        for(int i=0;i<=a.Length-2;i++)
            for(int j=i+1;j<=a.Length-1;j++)
                if(a[j].CompareTo(a[i])<0){T tam=a[i];a[i]=a[j];a[j]=tam;}
    }
}
class Bai3_2_SapXepBangInterface
{
    static void Main(string[] args)
    {
        int[] a={5,2,8,1,3};SapXepInterface.Sort(a);
        foreach(int x in a)Console.Write(x+" ");Console.WriteLine();
    }
}
