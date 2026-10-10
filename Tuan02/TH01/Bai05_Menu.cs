/*
 * CHƯƠNG TRÌNH MENU TÍNH TOÁN
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 17/09/2026
 *
 * Phát biểu đề bài:
 * Xử lý menu: nhập x,y; tính x^y; tính căn bậc 2 của x,y; thoát.
 *
 * Ý tưởng:
 * Dùng vòng lặp menu cho đến khi chọn 4.
 * Lựa chọn 1 nhập x,y.
 * Lựa chọn 2 dùng Math.Pow(x,y).
 * Lựa chọn 3 dùng Math.Sqrt(x), Math.Sqrt(y) nếu không âm.
 *
 * Mã giả:
 * MENU()
 * 1   repeat
 * 2       xuất menu
 * 3       nhập chon
 * 4       xử lý chon = 1, 2, 3
 * 5   until chon = 4
 */

using System;

class Bai05_Menu
{
    static void Main(string[] args)
    {
        double x = 0, y = 0;
        int chon;

        do
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon chuc nang: ");

            if (!int.TryParse(Console.ReadLine(), out chon))
            {
                Console.WriteLine("Lua chon khong hop le.");
                continue;
            }

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap x: ");
                    while (!double.TryParse(Console.ReadLine(), out x))
                        Console.Write("x khong hop le, nhap lai: ");
                    Console.Write("Nhap y: ");
                    while (!double.TryParse(Console.ReadLine(), out y))
                        Console.Write("y khong hop le, nhap lai: ");
                    break;
                case 2:
                    Console.WriteLine("x^y = {0}", Math.Pow(x, y));
                    break;
                case 3:
                    if (x < 0 || y < 0)
                        Console.WriteLine("Khong the tinh can bac hai cua so am.");
                    else
                    {
                        Console.WriteLine("Can bac 2 cua x = {0}", Math.Sqrt(x));
                        Console.WriteLine("Can bac 2 cua y = {0}", Math.Sqrt(y));
                    }
                    break;
                case 4:
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
        while (chon != 4);
    }
}
