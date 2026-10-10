using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiThucHanhLINQ;

// ===================== BÀI 4.1 & 6.1: LỚP DỮ LIỆU =====================
public class MonHoc
{
    public string MaMon { get; set; } = "";
    public string TenMon { get; set; } = "";
    public string He { get; set; } = "";
    public byte SoTiet { get; set; }
}

public class He
{
    public string MaHe { get; set; } = "";
    public string TenHe { get; set; } = "";
}

public static class DuLieu
{
    public static List<MonHoc> DS_Mon()
    {
        return new List<MonHoc>
        {
            new MonHoc { MaMon = "HP2_1",  TenMon = "Nền tảng C#",                              He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP2_2",  TenMon = "Công nghệ ADO.NET",                        He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3_1",  TenMon = "Lập trình Windows Forms",                  He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3_2",  TenMon = "Xây dựng ứng dụng Windows Forms",          He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4_1",  TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4_2",  TenMon = "Xây dựng ứng dụng Web với ASP.NET",        He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5_1",  TenMon = "Lập trình CSDL SQL Server căn bản",        He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5_2",  TenMon = "Lập trình CSDL SQL Server nâng cao",       He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "JLCB",   TenMon = "Joomla cơ bản",                            He = "CD",  SoTiet = 72 },
            new MonHoc { MaMon = "LINQ",   TenMon = "Language-Integrated Query",                He = "CD",  SoTiet = 64 },
            new MonHoc { MaMon = "DAWEB",  TenMon = "Đồ án thực tế Web với ASP.NET",            He = "CD",  SoTiet = 40 },
            new MonHoc { MaMon = "DAWIN",  TenMon = "Đồ án thực tế Windows Forms",              He = "CD",  SoTiet = 40 },
            new MonHoc { MaMon = "CC++",   TenMon = "Lập trình hướng đối tượng với C/C++",      He = "CD",  SoTiet = 128 },
            new MonHoc { MaMon = "JQUE",   TenMon = "JQuery",                                   He = "CD",  SoTiet = 22 },
            new MonHoc { MaMon = "XML",    TenMon = "Công nghệ XML",                            He = "CD",  SoTiet = 32 },
            new MonHoc { MaMon = "CRYS",   TenMon = "Crystal Report trong Visual Studio",       He = "CD",  SoTiet = 32 },
            new MonHoc { MaMon = "BWEB",   TenMon = "HTML, CSS và JavaScript",                  He = "CD",  SoTiet = 32 },
            new MonHoc { MaMon = "XYZ",    TenMon = "Chưa đặt tên môn",                         He = "",    SoTiet = 0 },
        };
    }

    public static List<He> DS_He()
    {
        return new List<He>
        {
            new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
            new He { MaHe = "CD",  TenHe = "Chuyên đề" },
            new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" },
        };
    }
}

public record KetQuaJoin(string? MaHe, string? TenHe, string? MaMon, string? TenMon, byte? SoTiet);

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Bai2_1();
        Bai2_2();
        Bai3_1();
        Bai3_2();
        Bai5_1();
        Bai5_2();
        Bai6_2();
    }

    // ---------- Hàm hỗ trợ in ----------
    static void TieuDe(string s)
    {
        Console.WriteLine();
        Console.WriteLine("=== " + s + " ===");
    }

    static void Nhan(string s) => Console.WriteLine("-- " + s);

    static string HienThiHe(string he) => string.IsNullOrEmpty(he) ? "(chưa khai báo hệ)" : he;

    static void InMon(MonHoc m) =>
        Console.WriteLine($"{m.MaMon,-7} {m.TenMon,-40} {HienThiHe(m.He),-20} {m.SoTiet,4}");

    // ===================== BÀI 2.1 =====================
    static void Bai2_1()
    {
        TieuDe("BÀI 2.1 - Truy vấn mảng số nguyên");
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

        // a. Chia hết cho 4 và 3
        Nhan("a. Chia hết cho 4 và 3 (Query Syntax)");
        var a1 = from x in mangSo where x % 4 == 0 && x % 3 == 0 select x;
        foreach (var x in a1) Console.Write(x + " ");
        Console.WriteLine();

        Nhan("a. Chia hết cho 4 và 3 (Method Syntax)");
        var a2 = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
        Console.WriteLine(string.Join(", ", a2));

        // b. Nhỏ hơn hoặc bằng 3
        Nhan("b. Nhỏ hơn hoặc bằng 3 (Query Syntax)");
        var b1 = from x in mangSo where x <= 3 select x;
        Console.WriteLine(string.Join(", ", b1));

        Nhan("b. Nhỏ hơn hoặc bằng 3 (Method Syntax)");
        var b2 = mangSo.Where(x => x <= 3);
        Console.WriteLine(string.Join(", ", b2));

        // c. Số chẵn chia đôi, số lẻ giữ nguyên
        Nhan("c. Số chẵn chia đôi, số lẻ giữ nguyên (Query Syntax)");
        var c1 = from x in mangSo select x % 2 == 0 ? x / 2 : x;
        Console.WriteLine(string.Join(", ", c1));

        Nhan("c. Số chẵn chia đôi, số lẻ giữ nguyên (Method Syntax)");
        var c2 = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
        Console.WriteLine(string.Join(", ", c2));
    }

    // ===================== BÀI 2.2 =====================
    static void Bai2_2()
    {
        TieuDe("BÀI 2.2 - Truy vấn mảng chuỗi");
        string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
            "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

        // a. 4 ký tự, sắp xếp tăng dần theo ký tự đầu
        Nhan("a. Phần tử có 4 ký tự, sắp xếp theo ký tự đầu (Query Syntax)");
        var a1 = from s in mangChuoi
                 where s.Length == 4
                 orderby s[0]
                 select s;
        Console.WriteLine(string.Join(", ", a1));

        Nhan("a. (Method Syntax)");
        var a2 = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
        Console.WriteLine(string.Join(", ", a2));

        // b. <chữ thường> - <CHỮ HOA>
        Nhan("b. Dạng <chữ thường> - <CHỮ HOA> (Query Syntax)");
        var b1 = from s in mangChuoi select $"{s.ToLower()} - {s.ToUpper()}";
        foreach (var s in b1) Console.WriteLine(s);

        Nhan("b. (Method Syntax)");
        var b2 = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
        Console.WriteLine(string.Join(" | ", b2));

        // c. Chứa ký tự 'u'
        Nhan("c. Phần tử chứa ký tự \"u\" (Query Syntax)");
        var c1 = from s in mangChuoi where s.Contains('u') select s;
        Console.WriteLine(string.Join(", ", c1));

        Nhan("c. (Method Syntax)");
        var c2 = mangChuoi.Where(s => s.Contains('u'));
        Console.WriteLine(string.Join(", ", c2));

        // d. Bắt đầu bằng chữ in hoa
        Nhan("d. Phần tử bắt đầu bằng chữ in hoa (Query Syntax)");
        var d1 = from s in mangChuoi where char.IsUpper(s[0]) select s;
        Console.WriteLine(string.Join(" ", d1));

        Nhan("d. (Method Syntax)");
        var d2 = mangChuoi.Where(s => char.IsUpper(s[0]));
        Console.WriteLine(string.Join(" ", d2));
    }

    // ===================== BÀI 3.1 =====================
    static void Bai3_1()
    {
        TieuDe("BÀI 3.1 - Thống kê mảng số");
        int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

        // a. Tổng số phần tử, chẵn, lẻ
        Nhan("a. Thống kê số lượng phần tử");
        Console.WriteLine($"Tổng số phần tử : {mangSo.Count()}");
        Console.WriteLine($"Số phần tử chẵn : {mangSo.Count(x => x % 2 == 0)}");
        Console.WriteLine($"Số phần tử lẻ   : {mangSo.Count(x => x % 2 != 0)}");

        // b. Tổng, max, min
        Nhan("b. Tổng, lớn nhất, nhỏ nhất");
        Console.WriteLine($"Tổng các giá trị : {mangSo.Sum()}");
        Console.WriteLine($"Giá trị lớn nhất : {mangSo.Max()}");
        Console.WriteLine($"Giá trị nhỏ nhất : {mangSo.Min()}");

        // c. Số giá trị khác nhau
        Nhan("c. Số giá trị khác nhau");
        Console.WriteLine($"Có {mangSo.Distinct().Count()} giá trị khác nhau: {string.Join(", ", mangSo.Distinct())}");

        // d. Phân nhóm theo số dư khi chia cho 5
        Nhan("d. Phân nhóm theo số dư khi chia cho 5");
        var nhom = from x in mangSo
                   group x by x % 5 into g
                   orderby g.Key
                   select g;
        foreach (var g in nhom)
            Console.WriteLine($"Số dư {g.Key}: {string.Join(", ", g)}");
    }

    // ===================== BÀI 3.2 =====================
    static void Bai3_2()
    {
        TieuDe("BÀI 3.2 - Thống kê mảng chuỗi");
        string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
            "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
            "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

        // a. Ngắn nhất, dài nhất
        Nhan("a. Phần tử ngắn nhất và dài nhất");
        int minLen = monAn.Min(s => s.Length);
        int maxLen = monAn.Max(s => s.Length);
        Console.WriteLine($"Ngắn nhất ({minLen} ký tự): {string.Join(", ", monAn.Where(s => s.Length == minLen))}");
        Console.WriteLine($"Dài nhất  ({maxLen} ký tự): {string.Join(", ", monAn.Where(s => s.Length == maxLen))}");

        // b. Phân nhóm theo từ đầu tiên
        Nhan("b. Phân nhóm theo từ đầu tiên");
        var nhom = from s in monAn
                   group s by s.Split(' ')[0] into g
                   select g;
        foreach (var g in nhom)
        {
            Console.WriteLine($"Nhóm \"{g.Key}\" ({g.Count()} món):");
            foreach (var s in g) Console.WriteLine("    " + s);
        }

        // c. Đếm số phần tử có từ đầu là "Bánh"
        Nhan("c. Số phần tử có từ đầu tiên là \"Bánh\"");
        int dem = monAn.Count(s => s.Split(' ')[0] == "Bánh");
        Console.WriteLine(dem);
    }

    // ===================== BÀI 5.1 =====================
    static void Bai5_1()
    {
        TieuDe("BÀI 5.1 - Truy vấn cơ bản trên List<MonHoc>");
        var ds = DuLieu.DS_Mon();

        // a.
        Nhan("a. Tên môn bắt đầu bằng \"Lập trình\"");
        var a = from m in ds
                where m.TenMon.StartsWith("Lập trình")
                select m.TenMon;
        foreach (var t in a) Console.WriteLine(t);

        // b.
        Nhan("b. Hệ CD, số tiết giảm dần rồi mã môn tăng dần");
        var b = ds.Where(m => m.He == "CD")
                  .OrderByDescending(m => m.SoTiet)
                  .ThenBy(m => m.MaMon, StringComparer.Ordinal);
        foreach (var m in b) InMon(m);

        // c.
        Nhan("c. Môn có tên chứa \"web\" (Tên môn, Hệ)");
        var c = from m in ds
                where m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase)
                select new { m.TenMon, m.He };
        foreach (var x in c) Console.WriteLine($"{x.TenMon,-45} {x.He}");

        // d.
        Nhan("d. Hệ KTV, sắp xếp tăng dần theo Mã môn");
        var d = from m in ds
                where m.He == "KTV"
                orderby m.MaMon
                select m;
        foreach (var m in d) InMon(m);
    }

    // ===================== BÀI 5.2 =====================
    static void Bai5_2()
    {
        TieuDe("BÀI 5.2 - Thống kê trên List<MonHoc>");
        var ds = DuLieu.DS_Mon();

        // a.
        Nhan("a. Tổng số môn");
        Console.WriteLine(ds.Count);

        // b.
        Nhan("b. Số môn có tên bắt đầu bằng \"Lập trình\"");
        Console.WriteLine(ds.Count(m => m.TenMon.StartsWith("Lập trình")));

        // c.
        Nhan("c. Tổng số tiết của hệ KTV");
        Console.WriteLine(ds.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet));

        // d.
        Nhan("d. Tổng số môn của mỗi hệ");
        var d = from m in ds
                group m by m.He into g
                select new { He = g.Key, TongSoMon = g.Count() };
        Console.WriteLine($"{"Hệ",-22} Tổng số môn");
        foreach (var x in d) Console.WriteLine($"{HienThiHe(x.He),-22} {x.TongSoMon}");

        // e.
        Nhan("e. Nhóm theo Số tiết, giảm dần theo Số tiết");
        var e = ds.GroupBy(m => m.SoTiet)
                  .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
                  .OrderByDescending(x => x.SoTiet);
        Console.WriteLine($"{"Số tiết",-10} Tổng số môn");
        foreach (var x in e) Console.WriteLine($"{x.SoTiet,-10} {x.TongSoMon}");

        // f.
        Nhan("f. Môn học có số tiết cao nhất");
        byte maxTiet = ds.Max(m => m.SoTiet);
        foreach (var m in ds.Where(m => m.SoTiet == maxTiet)) InMon(m);

        // g.
        Nhan("g. Thống kê theo Hệ");
        var g2 = from m in ds
                 group m by m.He into g
                 select new
                 {
                     He = g.Key,
                     TongMon = g.Count(),
                     TongTiet = g.Sum(m => (int)m.SoTiet),
                     Max = g.Max(m => m.SoTiet),
                     Min = g.Min(m => m.SoTiet)
                 };
        Console.WriteLine($"{"Hệ",-22} {"Tổng môn",9} {"Tổng tiết",10} {"Cao nhất",9} {"Thấp nhất",10}");
        foreach (var x in g2)
            Console.WriteLine($"{HienThiHe(x.He),-22} {x.TongMon,9} {x.TongTiet,10} {x.Max,9} {x.Min,10}");

        // h.
        Nhan("h. Các môn học phân nhóm theo Hệ");
        foreach (var g in ds.GroupBy(m => m.He))
        {
            Console.WriteLine($"[Hệ: {HienThiHe(g.Key)}] - {g.Count()} môn");
            foreach (var m in g) Console.WriteLine($"    {m.MaMon,-7} {m.TenMon,-40} {m.SoTiet,4}");
        }

        // i.
        Nhan("i. Các môn học phân nhóm theo Số tiết, tăng dần theo Số tiết");
        foreach (var g in ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
        {
            Console.WriteLine($"[Số tiết: {g.Key}] - {g.Count()} môn");
            foreach (var m in g) Console.WriteLine($"    {m.MaMon,-7} {m.TenMon,-40} {HienThiHe(m.He)}");
        }

        // j.
        Nhan("j. Hệ KTV, phân nhóm theo học phần (HP2, HP3, HP4, HP5)");
        var j = from m in ds
                where m.He == "KTV"
                group m by m.MaMon.Split('_')[0] into g
                orderby g.Key
                select g;
        foreach (var g in j)
        {
            Console.WriteLine($"[Học phần {g.Key}]");
            foreach (var m in g.OrderBy(m => m.MaMon, StringComparer.Ordinal))
                Console.WriteLine($"    {m.MaMon,-7} {m.TenMon,-40} {m.SoTiet,4}");
        }

        // k.
        Nhan("k. Nhóm theo Hệ, chỉ lấy môn có Số tiết > 40, sắp xếp theo Mã môn");
        var k = ds.Where(m => m.SoTiet > 40).GroupBy(m => m.He);
        foreach (var g in k)
        {
            Console.WriteLine($"[Hệ: {HienThiHe(g.Key)}] - {g.Count()} môn");
            foreach (var m in g.OrderBy(m => m.MaMon, StringComparer.Ordinal))
                Console.WriteLine($"    {m.MaMon,-7} {m.TenMon,-40} {m.SoTiet,4}");
        }
    }

    // ===================== BÀI 6.2 =====================
    static void InJoin(IEnumerable<KetQuaJoin> ds)
    {
        Console.WriteLine($"{"Tên hệ",-20} {"Mã môn",-8} {"Tên môn",-40} {"Số tiết",7}");
        foreach (var x in ds)
            Console.WriteLine($"{x.TenHe ?? "(chưa khai báo hệ)",-20} {x.MaMon ?? "(chưa có môn)",-8} {x.TenMon ?? "",-40} {x.SoTiet,7}");
    }

    static void Bai6_2()
    {
        TieuDe("BÀI 6.2 - Join hai nguồn dữ liệu");
        var mons = DuLieu.DS_Mon();
        var hes = DuLieu.DS_He();

        // a. Inner join
        Nhan("a. Join: Tên hệ, Mã môn, Tên môn");
        var a = from h in hes
                join m in mons on h.MaHe equals m.He
                select new KetQuaJoin(h.MaHe, h.TenHe, m.MaMon, m.TenMon, m.SoTiet);
        InJoin(a);

        // b. Left outer join: cả hệ chưa có môn
        Nhan("b. Cả những hệ chưa có môn học (GroupJoin + DefaultIfEmpty)");
        var leftJoin = from h in hes
                       join m in mons on h.MaHe equals m.He into nhomMon
                       from m in nhomMon.DefaultIfEmpty()
                       select new KetQuaJoin(h.MaHe, h.TenHe, m?.MaMon, m?.TenMon, m?.SoTiet);
        InJoin(leftJoin);

        // c. Full outer join: thêm môn chưa khai báo hệ
        Nhan("c. Cả hệ chưa có môn học và môn học chưa khai báo hệ");
        var monKhongHe = from m in mons
                         where !hes.Any(h => h.MaHe == m.He)
                         select new KetQuaJoin(null, null, m.MaMon, m.TenMon, m.SoTiet);
        var fullJoin = leftJoin.Concat(monKhongHe);
        InJoin(fullJoin);

        // d. Chỉ liệt kê phần không khớp
        Nhan("d. Chỉ những hệ chưa có môn học và những môn học chưa khai báo hệ");
        var chiKhongKhop = fullJoin.Where(x => x.MaMon == null || x.TenHe == null);
        InJoin(chiKhongKhop);

        // e. 5 môn đầu có số tiết giảm dần
        Nhan("e. 5 môn học đầu tiên có số tiết giảm dần");
        var e = (from h in hes
                 join m in mons on h.MaHe equals m.He
                 orderby m.SoTiet descending, m.MaMon
                 select new KetQuaJoin(h.MaHe, h.TenHe, m.MaMon, m.TenMon, m.SoTiet)).Take(5);
        InJoin(e);

        // f. Tổng số môn của mỗi hệ
        Nhan("f. Tổng số môn học của mỗi hệ");
        var f = from h in hes
                join m in mons on h.MaHe equals m.He into nhomMon
                select new { h.MaHe, h.TenHe, TongSoMon = nhomMon.Count() };
        Console.WriteLine($"{"Mã hệ",-8} {"Tên hệ",-20} Tổng số môn");
        foreach (var x in f) Console.WriteLine($"{x.MaHe,-8} {x.TenHe,-20} {x.TongSoMon}");

        // g. Số loại Số tiết khác nhau
        Nhan("g. Số loại Số tiết khác nhau");
        var loaiTiet = mons.Select(m => m.SoTiet).Distinct().ToList();
        Console.WriteLine($"{loaiTiet.Count} loại: {string.Join(", ", loaiTiet.OrderBy(t => t))}");

        // h. Môn đầu tiên bắt đầu bằng "Lập trình"
        Nhan("h. Môn học đầu tiên có tên bắt đầu bằng \"Lập trình\"");
        var monDau = mons.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
        if (monDau != null) InMon(monDau);
        else Console.WriteLine("Không tìm thấy.");

        // i. Đánh số thứ tự trong mỗi nhóm
        Nhan("i. Các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm");
        foreach (var g in mons.GroupBy(m => m.He))
        {
            Console.WriteLine($"[Hệ: {HienThiHe(g.Key)}]");
            var danhSo = g.Select((m, i) => new { STT = i + 1, m.MaMon, m.TenMon, m.SoTiet });
            foreach (var x in danhSo)
                Console.WriteLine($"    {x.STT,2}. {x.MaMon,-7} {x.TenMon,-40} {x.SoTiet,4}");
        }
    }
}
