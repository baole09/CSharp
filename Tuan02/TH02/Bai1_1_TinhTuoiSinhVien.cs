/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 19/09/2026
 */

/*
 * CHƯƠNG TRÌNH TÍNH TUỔI SINH VIÊN
 *
 * Phát biểu đề bài:
 * Nhập họ tên, năm sinh của một sinh viên. Tính và xuất tuổi.
 *
 * Ý tưởng:
 * tuoi = namHienTai - namSinh
 *
 * Mã giả:
 * 1   nhập hoTen, namSinh
 * 2   namHienTai ← DateTime.Now.Year
 * 3   tuoi ← namHienTai - namSinh
 * 4   xuất hoTen, tuoi
 */
using System;
class SinhVien
{
    private string hoTen;
    private int namSinh;
    public SinhVien() { hoTen = ""; namSinh = 0; }
    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine() ?? "";
        Console.Write("Nhap nam sinh: ");
        namSinh = int.Parse(Console.ReadLine() ?? "0");
    }
    public int TinhTuoi() { return DateTime.Now.Year - namSinh; }
    public void Xuat()
    {
        Console.WriteLine("Ho ten: {0}", hoTen);
        Console.WriteLine("Tuoi: {0}", TinhTuoi());
    }
}
class Bai1_1_TinhTuoiSinhVien
{
    static void Main(string[] args)
    {
        SinhVien sv = new SinhVien();
        sv.Nhap();
        sv.Xuat();
    }
}
