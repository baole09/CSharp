/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 23/09/2026
 */

/*
 * CHƯƠNG TRÌNH TÍNH LƯƠNG NHÂN VIÊN KINH DOANH VÀ SẢN XUẤT
 *
 * Phát biểu đề bài:
 * Kinh doanh: lương cơ bản + 500.000 mỗi hợp đồng.
 * Sản xuất: số sản phẩm * 1000; trên 3000 sản phẩm thưởng 5%.
 *
 * Ý tưởng:
 * Dùng lớp cơ sở NhanVien và hai lớp dẫn xuất override TinhLuong().
 *
 * Mã giả:
 * 1   Kinh doanh: luong = luongCoBan + soHopDong*500000
 * 2   Sản xuất: luong = soSanPham*1000
 * 3   nếu soSanPham > 3000 thì luong ← luong*1.05
 */
using System;
abstract class NhanVien
{
    public string MaNV{get;set;} public string HoTen{get;set;}
    protected NhanVien(string ma,string ten){MaNV=ma;HoTen=ten;}
    public abstract double TinhLuong();
    public override string ToString(){return MaNV+" - "+HoTen+" - "+TinhLuong()+" VNĐ";}
}
class NhanVienKinhDoanh:NhanVien
{
    public double LuongCoBan{get;set;} public int SoHopDong{get;set;}
    public NhanVienKinhDoanh(string ma,string ten,double luong,int hopDong):base(ma,ten){LuongCoBan=luong;SoHopDong=hopDong;}
    public override double TinhLuong(){return LuongCoBan+SoHopDong*500000;}
}
class NhanVienSanXuat:NhanVien
{
    public int SoSanPham{get;set;}
    public NhanVienSanXuat(string ma,string ten,int soSP):base(ma,ten){SoSanPham=soSP;}
    public override double TinhLuong(){double luong=SoSanPham*1000;if(SoSanPham>3000)luong*=1.05;return luong;}
}
class Bai3_5_TinhLuongKeThua
{
    static void Main(string[] args)
    {
        NhanVien[] ds={new NhanVienKinhDoanh("KD01","Nguyen Van A",10000000,4),new NhanVienSanXuat("SX01","Tran Van B",3500)};
        foreach(NhanVien nv in ds)Console.WriteLine(nv);
    }
}
