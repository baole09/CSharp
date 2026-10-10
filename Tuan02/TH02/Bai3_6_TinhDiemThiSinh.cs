/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 23/09/2026
 */

/*
 * CHƯƠNG TRÌNH TÍNH ĐIỂM THÍ SINH
 *
 * Phát biểu đề bài:
 * Hai đối tượng Chuyên và Siêu cúp cùng thi 3 bài lập trình.
 * Chuyên thi thêm tiếng Anh: 7-8 cộng 1; 9-10 cộng 2.
 * Siêu cúp thi thêm CSDL. Xuất tổng điểm từng thí sinh.
 *
 * Ý tưởng:
 * Chuyên: tong=bai1+bai2+bai3+diemThuong.
 * Siêu cúp: tong=bai1+bai2+bai3+csdl.
 * Dùng kế thừa và đa hình.
 *
 * Mã giả:
 * 1   nhập thông tin chung
 * 2   nếu Chuyên: tính điểm thưởng tiếng Anh
 * 3   nếu Siêu cúp: cộng điểm CSDL
 * 4   xuất tổng điểm
 */
using System;
abstract class ThiSinh
{
    public string SBD{get;set;} public string HoTen{get;set;}
    public double Bai1{get;set;} public double Bai2{get;set;} public double Bai3{get;set;}
    protected ThiSinh(string sbd,string ten,double b1,double b2,double b3){SBD=sbd;HoTen=ten;Bai1=b1;Bai2=b2;Bai3=b3;}
    public abstract double TongDiem();
    public override string ToString(){return SBD+" - "+HoTen+" - Tong diem: "+TongDiem();}
}
class ThiSinhChuyen:ThiSinh
{
    public double TiengAnh{get;set;}
    public ThiSinhChuyen(string s,string t,double b1,double b2,double b3,double ta):base(s,t,b1,b2,b3){TiengAnh=ta;}
    public override double TongDiem()
    {
        double tong=Bai1+Bai2+Bai3;
        if(TiengAnh>=7&&TiengAnh<=8)tong+=1;
        else if(TiengAnh>=9&&TiengAnh<=10)tong+=2;
        return tong;
    }
}
class ThiSinhSieuCup:ThiSinh
{
    public double CSDL{get;set;}
    public ThiSinhSieuCup(string s,string t,double b1,double b2,double b3,double csdl):base(s,t,b1,b2,b3){CSDL=csdl;}
    public override double TongDiem(){return Bai1+Bai2+Bai3+CSDL;}
}
class Bai3_6_TinhDiemThiSinh
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so thi sinh: ");int n=int.Parse(Console.ReadLine()??"0");
        ThiSinh[] ds=new ThiSinh[n];
        for(int i=0;i<n;i++)
        {
            Console.WriteLine("Thi sinh {0}:",i+1);
            Console.Write("SBD: ");string sbd=Console.ReadLine()??"";
            Console.Write("Ho ten: ");string ten=Console.ReadLine()??"";
            Console.Write("Bai 1: ");double b1=double.Parse(Console.ReadLine()??"0");
            Console.Write("Bai 2: ");double b2=double.Parse(Console.ReadLine()??"0");
            Console.Write("Bai 3: ");double b3=double.Parse(Console.ReadLine()??"0");
            Console.Write("Loai (1-Chuyen, 2-Sieu cup): ");int loai=int.Parse(Console.ReadLine()??"1");
            if(loai==1)
            {
                Console.Write("Diem tieng Anh: ");double ta=double.Parse(Console.ReadLine()??"0");
                ds[i]=new ThiSinhChuyen(sbd,ten,b1,b2,b3,ta);
            }
            else
            {
                Console.Write("Diem CSDL: ");double csdl=double.Parse(Console.ReadLine()??"0");
                ds[i]=new ThiSinhSieuCup(sbd,ten,b1,b2,b3,csdl);
            }
        }
        Console.WriteLine("Ket qua:");
        foreach(ThiSinh ts in ds)Console.WriteLine(ts);
    }
}
