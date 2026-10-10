/*
 * CHƯƠNG TRÌNH ĐẢO MỘT CHUỖI
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Viết phương thức thành viên trả về chuỗi là đảo của một chuỗi.
 *
 * Ý tưởng:
 * Chuyển chuỗi thành mảng ký tự.
 * Dùng hai vị trí i, j và hoán vị hai ký tự.
 * Trả về chuỗi mới.
 *
 * Mã giả:
 * DAO-CHUOI(chuoi)
 * 1   kyTu ← mảng ký tự của chuoi
 * 2   i ← 0, j ← length(kyTu) - 1
 * 3   while i < j
 * 4       hoán vị kyTu[i], kyTu[j]
 * 5       i ← i + 1, j ← j - 1
 * 6   return chuỗi(kyTu)
 */

using System;

class Bai11_DaoChuoi
{
    public static string daoChuoi(string chuoi)
    {
        char[] kyTu = chuoi.ToCharArray();
        int i = 0;
        int j = kyTu.Length - 1;

        while (i < j)
        {
            char tam = kyTu[i];
            kyTu[i] = kyTu[j];
            kyTu[j] = tam;
            i++;
            j--;
        }

        return new string(kyTu);
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine() ?? "";
        Console.WriteLine("Chuoi dao: {0}", daoChuoi(chuoi));
    }
}
