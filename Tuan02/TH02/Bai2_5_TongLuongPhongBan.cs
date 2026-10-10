/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 21/09/2026
 */

/*
 * CHƯƠNG TRÌNH TỔNG LƯƠNG PHÒNG BAN
 *
 * Phát biểu đề bài:
 * Phòng ban có n nhân viên (họ tên, mức lương, số ngày vắng).
 * Một ngày vắng trừ 100.000 VNĐ. Tính tổng lương.
 *
 * Ý tưởng:
 * luong = mucLuong - soNgayVang*100000
 * tong = Σ luong[i]
 *
 * Mã giả:
 * 1   tong ← 0
 * 2   nhập từng nhân viên
 * 3   tong ← tong + luong
 * 4   xuất tong
 */
using System;
class NhanVien
{
    public string HoTen{get;set;} public double MucLuong{get;set;} public int SoNgayVang{get;set;}
    public double TinhLuong(){return MucLuong-SoNgayVang*100000;}
    public void Input()
    {
        Console.Write("Ho ten: ");HoTen=Console.ReadLine()??"";
        Console.Write("Muc luong: ");MucLuong=double.Parse(Console.ReadLine()??"0");
        Console.Write("So ngay vang: ");SoNgayVang=int.Parse(Console.ReadLine()??"0");
    }
}
class Bai2_5_TongLuongPhongBan
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nhan vien: ");int n=int.Parse(Console.ReadLine()??"0");
        NhanVien[] ds=new NhanVien[n];double tong=0;
        for(int i=0;i<n;i++){Console.WriteLine("Nhan vien {0}:",i+1);ds[i]=new NhanVien();ds[i].Input();tong+=ds[i].TinhLuong();}
        Console.WriteLine("Tong luong phong ban: {0} VNĐ",tong);
    }
}
