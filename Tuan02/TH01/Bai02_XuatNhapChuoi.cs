/*
 * CHƯƠNG TRÌNH XUẤT VÀ NHẬP CHUỖI
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Nhập họ tên và xuất họ tên đã nhập theo định dạng yêu cầu.
 *
 * Ý tưởng:
 * Nhập chuỗi hoTen.
 * Xuất lời chào có chứa hoTen.
 *
 * Mã giả:
 * XUAT-NHAP-CHUOI()
 * 1   nhập hoTen
 * 2   xuất "Chao ban " + hoTen + "!"
 */

using System;

class Bai02_XuatNhapChuoi
{
    static void Main(string[] args)
    {
        Console.Write("Nhap ho ten cua ban: ");
        string hoTen = Console.ReadLine() ?? "";
        Console.WriteLine("Chao ban {0}!", hoTen);
    }
}
