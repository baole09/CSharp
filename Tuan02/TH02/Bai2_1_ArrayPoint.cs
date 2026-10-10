/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 20/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP ARRAYPOINT
 *
 * Phát biểu đề bài:
 * Lưu trữ các Point bằng ArrayList và dùng Indexer truy cập Point thứ i.
 *
 * Ý tưởng:
 * points là ArrayList. this[i] trả về hoặc gán Point tại vị trí i.
 *
 * Mã giả:
 * 1   Add(p): points.Add(p)
 * 2   Indexer(i): return points[i]
 */
using System;
using System.Collections;
class ArrayPoint
{
    private ArrayList points;
    public ArrayPoint(){points=new ArrayList();}
    public void Add(Point p){points.Add(p);}
    public int Count{get{return points.Count;}}
    public Point this[int i]{get{return (Point)points[i];}set{points[i]=value;}}
}
class Point
{
    public double X{get;set;} public double Y{get;set;}
    public Point(double x,double y){X=x;Y=y;}
    public override string ToString(){return "("+X+", "+Y+")";}
}
class Bai2_1_ArrayPoint
{
    static void Main(string[] args)
    {
        ArrayPoint a=new ArrayPoint();
        a.Add(new Point(1,2));a.Add(new Point(3,4));a.Add(new Point(5,6));
        for(int i=0;i<a.Count;i++)Console.WriteLine("Point[{0}]={1}",i,a[i]);
    }
}
