/*
 * CHƯƠNG TRÌNH KIỂM TRA CHUỖI ĐỐI XỨNG
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 18/09/2026
 *
 * Phát biểu đề bài:
 * Viết phương thức thành viên kiểm tra chuỗi có đối xứng hay không.
 *
 * Ý tưởng:
 * Dùng hai vị trí i = 0 và j = chuoi.Length - 1.
 * Nếu chuoi[i] != chuoi[j] thì không đối xứng.
 * Tăng i, giảm j cho đến khi i >= j.
 *
 * Mã giả:
 * DOI-XUNG(chuoi)
 * 1   i ← 0, j ← length(chuoi) - 1
 * 2   while i < j
 * 3       if chuoi[i] != chuoi[j] then return false
 * 4       i ← i + 1, j ← j - 1
 * 5   return true
 */

using System;

class Bai10_ChuoiDoiXung
{
    public static bool laDoiXung(string chuoi)
    {
        int i = 0;
        int j = chuoi.Length - 1;

        while (i < j)
        {
            if (chuoi[i] != chuoi[j])
                return false;
            i++;
            j--;
        }

        return true;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine() ?? "";

        Console.WriteLine(
            laDoiXung(chuoi)
                ? "Chuoi doi xung."
                : "Chuoi khong doi xung.");
    }
}
