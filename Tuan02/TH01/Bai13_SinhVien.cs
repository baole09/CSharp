/*
 * CHƯƠNG TRÌNH NHẬP XUẤT THÔNG TIN SINH VIÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Xây dựng lớp sinh viên lưu mã sinh viên, họ tên, địa chỉ,
 * sinh viên năm thứ mấy. Nhập và xuất một sinh viên.
 *
 * Ý tưởng:
 * Lớp SinhVien gồm maSinhVien, hoTen, diaChi, namThu.
 * nhap() đọc dữ liệu.
 * xuat() xuất dữ liệu.
 *
 * Mã giả:
 * SINH-VIEN()
 * 1   tạo sinh viên
 * 2   nhập các thông tin
 * 3   xuất các thông tin
 */

using System;

class SinhVien
{
    private string maSinhVien;
    private string hoTen;
    private string diaChi;
    private int namThu;

    public SinhVien()
    {
        maSinhVien = "";
        hoTen = "";
        diaChi = "";
        namThu = 0;
    }

    public void nhap()
    {
        Console.Write("Nhap ma sinh vien: ");
        maSinhVien = Console.ReadLine() ?? "";
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine() ?? "";
        Console.Write("Nhap dia chi: ");
        diaChi = Console.ReadLine() ?? "";

        Console.Write("Nhap sinh vien nam thu may: ");
        while (!int.TryParse(Console.ReadLine(), out namThu) || namThu < 1)
            Console.Write("Nam thu khong hop le, nhap lai: ");
    }

    public void xuat()
    {
        Console.WriteLine("Ma sinh vien: {0}", maSinhVien);
        Console.WriteLine("Ho ten: {0}", hoTen);
        Console.WriteLine("Dia chi: {0}", diaChi);
        Console.WriteLine("Nam thu: {0}", namThu);
    }
}

class Bai13_SinhVien
{
    static void Main(string[] args)
    {
        SinhVien sinhVien = new SinhVien();
        sinhVien.nhap();
        Console.WriteLine();
        sinhVien.xuat();
    }
}
