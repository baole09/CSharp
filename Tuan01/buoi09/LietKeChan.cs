using System;

class LietKeChan
{
    const int MAX_N = 500;
    public static void nhapDaySo(ref int[] day)
    {
        int n;
        do
        {
            Console.Write("Moi ban nhap so luong phan tu: ");
            n = int.Parse(Console.ReadLine() ?? "0");
        }
        while (n < 0 || n > MAX_N);
            
        day = new int[n];
        for (int i = 0; i <= day.Length - 1; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            day[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    // Liệt kê các phần tử chẵn theo thứ tự từ phải sang trái
    public static void lietKeChanPhaiSangTrai(int[] day)
    {
        Console.Write("Cac phan tu chan trong mang:");
        int soLuong = 0;
        for (int i = day.Length - 1; i >= 0; i--)
        {
            if (day[i] % 2 == 0)   
            {
                Console.Write(" {0}", day[i]);
                soLuong++;
            }
        }
        if (soLuong == 0)
            Console.Write(" (khong co)");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[] a = null;
        nhapDaySo(ref a);
        lietKeChanPhaiSangTrai(a);
    }
}