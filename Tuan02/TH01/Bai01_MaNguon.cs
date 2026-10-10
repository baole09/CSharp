/*
 * CHƯƠNG TRÌNH NHẬP VÀ XUẤT HỌ TÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập họ tên và xuất họ tên đã nhập ra màn hình console.
 *
 * Ý tưởng:
 * Nhập chuỗi hoTen.
 * Xuất lại chuỗi hoTen vừa nhập.
 *
 * Mã giả:
 * NHAP-XUAT-HO-TEN()
 * 1   nhập hoTen
 * 2   xuất hoTen
 */

using System;

class Bai01_MaNguon
{
    static void Main(string[] args)
    {
        Console.Write("Nhap ho ten: ");
        string hoTen = Console.ReadLine() ?? "";
        Console.WriteLine("Ho ten vua nhap: {0}", hoTen);
    }
}
