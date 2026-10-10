/*
 * CHƯƠNG TRÌNH SẮP XẾP MẢNG HỌ TÊN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 19/09/2026
 *
 * Phát biểu đề bài:
 * Nhập mảng họ tên của n người và sắp xếp theo thứ tự tăng dần.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Dùng Interchange Sort.
 * Nếu a[j] < a[i] theo thứ tự chuỗi thì hoán vị.
 *
 * Mã giả:
 * SAP-XEP(A, n)
 * 1   for i ← 0 to n - 2
 * 2       for j ← i + 1 to n - 1
 * 3           if a[j] < a[i] then hoán vị
 */

using System;

class Bai16_SapXepHoTen
{
    const int MAX_N = 500;

    public static void nhapDanhSach(ref string[] danhSach)
    {
        int n;
        do
        {
            Console.Write("Nhap so luong nguoi: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n < 0 || n > MAX_N);

        danhSach = new string[n];

        for (int i = 0; i <= danhSach.Length - 1; i++)
        {
            Console.Write("Ho ten {0}: ", i);
            danhSach[i] = Console.ReadLine() ?? "";
        }
    }

    public static void sapXep(ref string[] danhSach)
    {
        for (int i = 0; i <= danhSach.Length - 2; i++)
        {
            for (int j = i + 1; j <= danhSach.Length - 1; j++)
            {
                if (string.Compare(danhSach[j], danhSach[i],
                    StringComparison.CurrentCulture) < 0)
                {
                    string tam = danhSach[i];
                    danhSach[i] = danhSach[j];
                    danhSach[j] = tam;
                }
            }
        }
    }

    public static void xuatDanhSach(string[] danhSach)
    {
        for (int i = 0; i <= danhSach.Length - 1; i++)
            Console.WriteLine("{0}. {1}", i, danhSach[i]);
    }

    static void Main(string[] args)
    {
        string[] danhSach = null;
        nhapDanhSach(ref danhSach);

        Console.WriteLine("Danh sach truoc khi sap xep:");
        xuatDanhSach(danhSach);

        sapXep(ref danhSach);

        Console.WriteLine("Danh sach sau khi sap xep:");
        xuatDanhSach(danhSach);
    }
}
