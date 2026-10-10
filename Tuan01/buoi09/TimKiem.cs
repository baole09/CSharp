/*
 * CHƯƠNG TRÌNH TÌM KIẾM GIÁ TRỊ
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 15/09/2026
 *
 * Phát biểu đề bài:
 * Nhập dãy số thực A có n phần tử. Nhập giá trị x cần tìm.
 * Cho biết số lần xuất hiện của x trong dãy, vị trí đầu tiên và vị trí cuối cùng của x.
 * Nếu x không tồn tại trong dãy thì thông báo không tồn tại.
 *
 * Ý tưởng:
 * A = (a[0], a[1], ..., a[n-1])
 * Nhập giá trị cần tìm x.
 * Khởi tạo:
 *     vtDau ← -1
 *     vtCuoi ← -1
 *     soLan ← 0
 * Duyệt A từ trái sang phải.
 * Nếu a[i] = x:
 *     Nếu vtDau = -1:
 *         vtDau ← i
 *     vtCuoi ← i
 *     soLan ← soLan + 1
 * Sau khi duyệt hết dãy:
 *     Nếu soLan = 0: x không tồn tại trong A.
 *     Ngược lại: xuất soLan, vtDau, vtCuoi.
 *
 * Độ phức tạp:
 *     Thời gian: O(n)
 *     Bộ nhớ phụ: O(1)
 *
 * Mã giả:
 * TimKiem(A, n, x)
 * 1   vtDau ← -1
 * 2   vtCuoi ← -1
 * 3   soLan ← 0
 * 4   for i ← 0 to n - 1
 * 5       do if a[i] = x
 * 6              then if vtDau = -1
 * 7                       then vtDau ← i
 * 8                   vtCuoi ← i
 * 9                   soLan ← soLan + 1
 * 10  return vtDau, vtCuoi, soLan
 */

using System;

class TimKiem
{
    const int MAX_N = 500;

    public static void nhapDaySo(ref double[] day)
    {
        int n;
        do
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n < 0 || n > MAX_N);

        day = new double[n];

        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = double.Parse(Console.ReadLine() ?? "0");
        }
    }

    public static void inMangTraiSangPhai(double[] day)
    {
        Console.Write("Day so co {0} phan tu:", day.Length);

        for (int i = 0; i <= day.Length - 1; i++)
            Console.Write(" {0}", day[i]);

        Console.WriteLine();
    }

    public static void timKiem(
        double[] day,
        double x,
        ref int vtDau,
        ref int vtCuoi,
        ref int soLan)
    {
        vtDau = -1;
        vtCuoi = -1;
        soLan = 0;

        for (int i = 0; i <= day.Length - 1; i++)
        {
            if (day[i] == x)
            {
                if (vtDau == -1)
                    vtDau = i;

                vtCuoi = i;
                soLan++;
            }
        }
    }

    public static void Main(string[] args)
    {
        double[] a = null;
        double x;

        int vtDau = -1;
        int vtCuoi = -1;
        int soLan = 0;

        nhapDaySo(ref a);
        inMangTraiSangPhai(a);

        Console.WriteLine("* Tim kiem");
        Console.Write("Moi ban nhap gia tri x can tim: ");
        x = double.Parse(Console.ReadLine() ?? "0");

        timKiem(a, x, ref vtDau, ref vtCuoi, ref soLan);

        if (soLan == 0)
        {
            Console.WriteLine(
                "Gia tri {0} khong ton tai trong day so.", x);
        }
        else
        {
            Console.WriteLine(
                "Gia tri {0} xuat hien {1} lan o vi tri dau tien {2} va cuoi cung {3}.",
                x, soLan, vtDau, vtCuoi);
        }
    }
}