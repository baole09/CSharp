/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 19/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP POINT
 *
 * Phát biểu đề bài:
 * Thiết kế Point với field x,y; property X,Y; constructor mặc nhiên;
 * Input, Output, ToString; toán tử +, -, unary -. Tính khoảng cách
 * và trung điểm bằng phương thức thành viên và phương thức tĩnh.
 *
 * Ý tưởng:
 * A=(x1,y1), B=(x2,y2)
 * AB=sqrt((x2-x1)^2+(y2-y1)^2)
 * I=((x1+x2)/2,(y1+y2)/2)
 *
 * Mã giả:
 * 1   tính dx, dy
 * 2   khoảng cách ← sqrt(dx^2 + dy^2)
 * 3   trung điểm ← ((x1+x2)/2,(y1+y2)/2)
 */
using System;
class Point
{
    private double x, y;
    public double X { get { return x; } set { x = value; } }
    public double Y { get { return y; } set { y = value; } }
    public Point() { x = 0; y = 0; }
    public Point(double x, double y) { this.x = x; this.y = y; }
    public void Input()
    {
        Console.Write("Nhap x: "); x = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap y: "); y = double.Parse(Console.ReadLine() ?? "0");
    }
    public void Output() { Console.WriteLine("({0}, {1})", x, y); }
    public override string ToString() { return "(" + x + ", " + y + ")"; }
    public static Point operator +(Point a, Point b) { return new Point(a.X+b.X,a.Y+b.Y); }
    public static Point operator -(Point a, Point b) { return new Point(a.X-b.X,a.Y-b.Y); }
    public static Point operator -(Point a) { return new Point(-a.X,-a.Y); }
    public double KhoangCach(Point b)
    {
        double dx=b.X-X, dy=b.Y-Y;
        return Math.Sqrt(dx*dx+dy*dy);
    }
    public static double KhoangCach(Point a, Point b) { return a.KhoangCach(b); }
    public Point TrungDiem(Point b) { return new Point((X+b.X)/2,(Y+b.Y)/2); }
    public static Point TrungDiem(Point a, Point b) { return a.TrungDiem(b); }
}
class Bai1_2_Point
{
    static void Main(string[] args)
    {
        Point a=new Point(), b=new Point();
        Console.WriteLine("Nhap diem A:"); a.Input();
        Console.WriteLine("Nhap diem B:"); b.Input();
        Console.WriteLine("A = {0}",a);
        Console.WriteLine("B = {0}",b);
        Console.WriteLine("Khoang cach (member): {0}",a.KhoangCach(b));
        Console.WriteLine("Khoang cach (static): {0}",Point.KhoangCach(a,b));
        Console.WriteLine("Trung diem (member): {0}",a.TrungDiem(b));
        Console.WriteLine("Trung diem (static): {0}",Point.TrungDiem(a,b));
        Console.WriteLine("A + B = {0}",a+b);
        Console.WriteLine("A - B = {0}",a-b);
        Console.WriteLine("-A = {0}",-a);
    }
}
