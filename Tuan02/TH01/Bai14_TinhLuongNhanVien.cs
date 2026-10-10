/*
 * CHƯƠNG TRÌNH TÍNH LƯƠNG NHÂN VIÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập họ tên, mức lương, số ngày vắng.
 * Một ngày vắng bị trừ 100.000 VNĐ. Tính và xuất lương.
 *
 * Ý tưởng:
 * luong ← mucLuong - soNgayVang * 100000
 * Nhập thông tin nhân viên.
 * Tính lương và xuất kết quả.
 *
 * Mã giả:
 * TINH-LUONG(mucLuong, soNgayVang)
 * 1   luong ← mucLuong - soNgayVang * 100000
 * 2   return luong
 */

using System;

class NhanVien
{
    private string hoTen;
    private double mucLuong;
    private int soNgayVang;

    public NhanVien()
    {
        hoTen = "";
        mucLuong = 0;
        soNgayVang = 0;
    }

    public void nhap()
    {
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine() ?? "";

        Console.Write("Nhap muc luong: ");
        while (!double.TryParse(Console.ReadLine(), out mucLuong) || mucLuong < 0)
            Console.Write("Muc luong khong hop le, nhap lai: ");

        Console.Write("Nhap so ngay vang: ");
        while (!int.TryParse(Console.ReadLine(), out soNgayVang) || soNgayVang < 0)
            Console.Write("So ngay vang khong hop le, nhap lai: ");
    }

    public double tinhLuong()
    {
        return mucLuong - soNgayVang * 100000;
    }

    public void xuat()
    {
        Console.WriteLine("Ho ten: {0}", hoTen);
        Console.WriteLine("Luong sau khi tru: {0} VNĐ", tinhLuong());
    }
}

class Bai14_TinhLuongNhanVien
{
    static void Main(string[] args)
    {
        NhanVien nhanVien = new NhanVien();
        nhanVien.nhap();
        nhanVien.xuat();
    }
}
