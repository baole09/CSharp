/*
 * CHƯƠNG TRÌNH XỬ LÝ CHUỖI
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Nhập một chuỗi gồm nhiều từ. Chuyển sang ký tự thường,
 * ký tự hoa và đếm số từ trong chuỗi.
 *
 * Ý tưởng:
 * chuoiThuong ← ToLower(chuoi)
 * chuoiHoa ← ToUpper(chuoi)
 * Tách chuỗi theo khoảng trắng.
 * soTu ← số phần tử sau khi tách.
 *
 * Mã giả:
 * XU-LY-CHUOI(chuoi)
 * 1   chuoiThuong ← ToLower(chuoi)
 * 2   chuoiHoa ← ToUpper(chuoi)
 * 3   danhSachTu ← tách chuoi
 * 4   soTu ← length(danhSachTu)
 * 5   xuất kết quả
 */

using System;

class Bai12_XuLyChuoi
{
    public static int demSoTu(string chuoi)
    {
        string chuoiGon = chuoi.Trim();

        if (chuoiGon.Length == 0)
            return 0;

        string[] danhSachTu = chuoiGon.Split(
            new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);

        return danhSachTu.Length;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine() ?? "";

        Console.WriteLine("Chuoi thuong: {0}", chuoi.ToLower());
        Console.WriteLine("Chuoi hoa: {0}", chuoi.ToUpper());
        Console.WriteLine("So tu trong chuoi: {0}", demSoTu(chuoi));
    }
}
