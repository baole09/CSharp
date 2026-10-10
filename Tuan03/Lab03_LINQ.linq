<Query Kind="Program" />

// ============================================================================
// THỰC HÀNH 03 - LINQ CƠ BẢN - bản chạy thử trên LINQPad (https://www.linqpad.net)
// Họ tên : [HỌ VÀ TÊN]            Mã SV : [MÃ SỐ SINH VIÊN]
//
// CÁCH DÙNG: mở file này bằng LINQPad (Language = "C# Program"), bấm F5.
//
// GHI CHÚ VỀ LINQPAD
//  - Không cần tạo project: chỉ cần viết void Main() và các lớp bên dưới.
//  - .Dump("nhãn") in kết quả dạng bảng/cây rất trực quan: mảng, danh sách, nhóm (IGrouping)
//    đều hiển thị rõ cấu trúc => tiện kiểm tra nhanh từng truy vấn trước khi chuyển sang VSCode.
//  - Trong VSCode phải dùng Console.WriteLine + foreach để in; bản VSCode nằm ở thư mục 2_VSCode.
//  - Cần LINQPad 6 trở lên (.NET 6+) để dùng record.
// ============================================================================

void Main()
{
	Bai2_1();
	Bai2_2();
	Bai3_1();
	Bai3_2();
	Bai5_1();
	Bai5_2();
	Bai6_2();
}

// ---------------------------------------------------------------------------
// BÀI 2.1 - Truy vấn mảng số nguyên
// ---------------------------------------------------------------------------
void Bai2_1()
{
	"BÀI 2.1".Dump();
	int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

	// a. Chia hết cho 4 và 3 (0 chia hết cho mọi số nên cũng được chọn)
	(from x in mangSo where x % 4 == 0 && x % 3 == 0 select x).Dump("2.1a Query Syntax");
	mangSo.Where(x => x % 4 == 0 && x % 3 == 0).Dump("2.1a Method Syntax");

	// b. Nhỏ hơn hoặc bằng 3
	(from x in mangSo where x <= 3 select x).Dump("2.1b Query Syntax");
	mangSo.Where(x => x <= 3).Dump("2.1b Method Syntax");

	// c. Chẵn chia đôi, lẻ giữ nguyên => phải ra: 25, 21, 8, 3, 9, 4, 6, 7, 12, 0
	(from x in mangSo select x % 2 == 0 ? x / 2 : x).Dump("2.1c Query Syntax");
	mangSo.Select(x => x % 2 == 0 ? x / 2 : x).Dump("2.1c Method Syntax");
}

// ---------------------------------------------------------------------------
// BÀI 2.2 - Truy vấn mảng chuỗi
// ---------------------------------------------------------------------------
void Bai2_2()
{
	"BÀI 2.2".Dump();
	string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
		"Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

	// a. 4 ký tự, sắp xếp tăng dần theo ký tự đầu
	(from s in mangChuoi where s.Length == 4 orderby s[0] select s).Dump("2.2a Query Syntax");
	mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]).Dump("2.2a Method Syntax");

	// b. <chữ thường> - <CHỮ HOA>
	(from s in mangChuoi select $"{s.ToLower()} - {s.ToUpper()}").Dump("2.2b Query Syntax");
	mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}").Dump("2.2b Method Syntax");

	// c. Chứa ký tự 'u' (không dấu) => "Thúy" chứa 'ú' nên không được chọn
	(from s in mangChuoi where s.Contains('u') select s).Dump("2.2c Query Syntax");
	mangChuoi.Where(s => s.Contains('u')).Dump("2.2c Method Syntax");

	// d. Bắt đầu bằng chữ in hoa => Thúy Kiều Thúy Vân
	string.Join(" ", from s in mangChuoi where char.IsUpper(s[0]) select s).Dump("2.2d Query Syntax");
	string.Join(" ", mangChuoi.Where(s => char.IsUpper(s[0]))).Dump("2.2d Method Syntax");
}

// ---------------------------------------------------------------------------
// BÀI 3.1 - Thống kê mảng số
// ---------------------------------------------------------------------------
void Bai3_1()
{
	"BÀI 3.1".Dump();
	int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

	// a. Count() / Count(điều kiện)
	new { Tong = mangSo.Count(), Chan = mangSo.Count(x => x % 2 == 0), Le = mangSo.Count(x => x % 2 != 0) }
		.Dump("3.1a Số lượng phần tử");

	// b. Sum, Max, Min
	new { Tong = mangSo.Sum(), Max = mangSo.Max(), Min = mangSo.Min() }.Dump("3.1b Tổng, Max, Min");

	// c. Distinct() loại trùng
	new { SoGiaTriKhacNhau = mangSo.Distinct().Count(), CacGiaTri = mangSo.Distinct() }.Dump("3.1c Distinct");

	// d. Nhóm theo số dư khi chia 5. LINQPad hiển thị mỗi nhóm kèm Key => thấy rõ cấu trúc
	(from x in mangSo group x by x % 5 into g orderby g.Key select g).Dump("3.1d GroupBy số dư chia 5");
}

// ---------------------------------------------------------------------------
// BÀI 3.2 - Thống kê mảng chuỗi
// ---------------------------------------------------------------------------
void Bai3_2()
{
	"BÀI 3.2".Dump();
	string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
		"Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
		"Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

	// a. Min/Max độ dài rồi lọc các chuỗi có độ dài đó (có thể có nhiều chuỗi bằng nhau)
	int minLen = monAn.Min(s => s.Length), maxLen = monAn.Max(s => s.Length);
	monAn.Where(s => s.Length == minLen).Dump($"3.2a Ngắn nhất ({minLen} ký tự)");
	monAn.Where(s => s.Length == maxLen).Dump($"3.2a Dài nhất ({maxLen} ký tự)");

	// b. Nhóm theo từ đầu tiên (Split(' ')[0])
	monAn.GroupBy(s => s.Split(' ')[0]).Dump("3.2b GroupBy từ đầu tiên");

	// c. Đếm món có từ đầu là "Bánh"
	monAn.Count(s => s.Split(' ')[0] == "Bánh").Dump("3.2c Số món bắt đầu bằng 'Bánh'");
}

// ---------------------------------------------------------------------------
// BÀI 5.1 - Truy vấn cơ bản trên List<MonHoc>
// ---------------------------------------------------------------------------
void Bai5_1()
{
	"BÀI 5.1".Dump();
	var ds = DuLieu.DS_Mon();
	ds.Dump("Dữ liệu List<MonHoc>");

	// a.
	(from m in ds where m.TenMon.StartsWith("Lập trình") select m.TenMon).Dump("5.1a");

	// b. Nhiều khóa sắp xếp: OrderByDescending rồi ThenBy
	ds.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon, StringComparer.Ordinal)
		.Dump("5.1b Hệ CD");

	// c. select new { } chỉ lấy 2 cột; tìm "web" không phân biệt hoa/thường
	(from m in ds where m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase) select new { m.TenMon, m.He })
		.Dump("5.1c Tên chứa 'web'");

	// d.
	(from m in ds where m.He == "KTV" orderby m.MaMon select m).Dump("5.1d Hệ KTV");
}

// ---------------------------------------------------------------------------
// BÀI 5.2 - Thống kê trên List<MonHoc>
// ---------------------------------------------------------------------------
void Bai5_2()
{
	"BÀI 5.2".Dump();
	var ds = DuLieu.DS_Mon();

	ds.Count.Dump("5.2a Tổng số môn");
	ds.Count(m => m.TenMon.StartsWith("Lập trình")).Dump("5.2b Số môn 'Lập trình'");
	ds.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet).Dump("5.2c Tổng số tiết hệ KTV");

	(from m in ds group m by m.He into g select new { He = g.Key, TongSoMon = g.Count() }).Dump("5.2d Số môn mỗi hệ");

	ds.GroupBy(m => m.SoTiet).Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
		.OrderByDescending(x => x.SoTiet).Dump("5.2e Số môn theo số tiết");

	byte maxTiet = ds.Max(m => m.SoTiet);
	ds.Where(m => m.SoTiet == maxTiet).Dump("5.2f Môn có số tiết cao nhất");

	(from m in ds
	 group m by m.He into g
	 select new
	 {
		 He = g.Key,
		 TongMon = g.Count(),
		 TongTiet = g.Sum(m => (int)m.SoTiet),
		 Max = g.Max(m => m.SoTiet),
		 Min = g.Min(m => m.SoTiet)
	 }).Dump("5.2g Thống kê theo hệ");

	ds.GroupBy(m => m.He).Dump("5.2h Nhóm theo Hệ");
	ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key).Dump("5.2i Nhóm theo Số tiết (tăng dần)");

	(from m in ds where m.He == "KTV" group m by m.MaMon.Split('_')[0] into g orderby g.Key select g)
		.Dump("5.2j KTV theo học phần");

	ds.Where(m => m.SoTiet > 40).GroupBy(m => m.He)
		.Select(g => new { He = g.Key, DS = g.OrderBy(m => m.MaMon, StringComparer.Ordinal) })
		.Dump("5.2k Số tiết > 40, nhóm theo Hệ");
}

// ---------------------------------------------------------------------------
// BÀI 6.2 - Join hai nguồn dữ liệu
// ---------------------------------------------------------------------------
void Bai6_2()
{
	"BÀI 6.2".Dump();
	var mons = DuLieu.DS_Mon();
	var hes = DuLieu.DS_He();

	// a. Inner join: hệ QT và môn XYZ bị loại vì không khớp
	(from h in hes join m in mons on h.MaHe equals m.He
	 select new KetQuaJoin(h.MaHe, h.TenHe, m.MaMon, m.TenMon, m.SoTiet)).Dump("6.2a Inner join");

	// b. Left outer join = GroupJoin (join..into) + DefaultIfEmpty()
	var leftJoin = from h in hes
				   join m in mons on h.MaHe equals m.He into nhomMon
				   from m in nhomMon.DefaultIfEmpty()
				   select new KetQuaJoin(h.MaHe, h.TenHe, m?.MaMon, m?.TenMon, m?.SoTiet);
	leftJoin.Dump("6.2b Left outer join (có hệ QT chưa có môn)");

	// c. Full outer join = left join + các môn chưa có hệ
	var monKhongHe = from m in mons where !hes.Any(h => h.MaHe == m.He)
					 select new KetQuaJoin(null, null, m.MaMon, m.TenMon, m.SoTiet);
	var fullJoin = leftJoin.Concat(monKhongHe);
	fullJoin.Dump("6.2c Full outer join");

	// d. Chỉ phần không khớp
	fullJoin.Where(x => x.MaMon == null || x.TenHe == null).Dump("6.2d Chỉ dòng không khớp");

	// e. 5 môn đầu, số tiết giảm dần
	(from h in hes join m in mons on h.MaHe equals m.He
	 orderby m.SoTiet descending, m.MaMon
	 select new KetQuaJoin(h.MaHe, h.TenHe, m.MaMon, m.TenMon, m.SoTiet)).Take(5).Dump("6.2e Top 5");

	// f. Số môn mỗi hệ (GroupJoin giữ lại hệ có 0 môn)
	(from h in hes join m in mons on h.MaHe equals m.He into nhomMon
	 select new { h.MaHe, h.TenHe, TongSoMon = nhomMon.Count() }).Dump("6.2f Số môn mỗi hệ");

	// g. Số loại số tiết khác nhau
	mons.Select(m => m.SoTiet).Distinct().Count().Dump("6.2g Số loại Số tiết");

	// h. Môn đầu tiên bắt đầu bằng "Lập trình"
	mons.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình")).Dump("6.2h FirstOrDefault");

	// i. Đánh số thứ tự trong nhóm: Select((m, i) => ...)
	mons.GroupBy(m => m.He)
		.Select(g => new { He = g.Key, DS = g.Select((m, i) => new { STT = i + 1, m.MaMon, m.TenMon, m.SoTiet }) })
		.Dump("6.2i Đánh số thứ tự trong nhóm");
}

// ===================== LỚP DỮ LIỆU (BÀI 4.1 & 6.1) =====================
public class MonHoc
{
	public string MaMon { get; set; } = "";
	public string TenMon { get; set; } = "";
	public string He { get; set; } = "";   // rỗng = chưa khai báo hệ
	public byte SoTiet { get; set; }
}

public class He
{
	public string MaHe { get; set; } = "";
	public string TenHe { get; set; } = "";
}

public record KetQuaJoin(string MaHe, string TenHe, string MaMon, string TenMon, byte? SoTiet);

public static class DuLieu
{
	public static List<MonHoc> DS_Mon() => new List<MonHoc>
	{
		new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#",                               He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET",                         He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms",                   He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms",           He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET",         He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản",         He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao",        He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "JLCB",  TenMon = "Joomla cơ bản",                             He = "CD",  SoTiet = 72 },
		new MonHoc { MaMon = "LINQ",  TenMon = "Language-Integrated Query",                 He = "CD",  SoTiet = 64 },
		new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET",             He = "CD",  SoTiet = 40 },
		new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms",               He = "CD",  SoTiet = 40 },
		new MonHoc { MaMon = "CC++",  TenMon = "Lập trình hướng đối tượng với C/C++",       He = "CD",  SoTiet = 128 },
		new MonHoc { MaMon = "JQUE",  TenMon = "JQuery",                                    He = "CD",  SoTiet = 22 },
		new MonHoc { MaMon = "XML",   TenMon = "Công nghệ XML",                             He = "CD",  SoTiet = 32 },
		new MonHoc { MaMon = "CRYS",  TenMon = "Crystal Report trong Visual Studio",        He = "CD",  SoTiet = 32 },
		new MonHoc { MaMon = "BWEB",  TenMon = "HTML, CSS và JavaScript",                   He = "CD",  SoTiet = 32 },
		new MonHoc { MaMon = "XYZ",   TenMon = "Chưa đặt tên môn",                          He = "",    SoTiet = 0 },
	};

	public static List<He> DS_He() => new List<He>
	{
		new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
		new He { MaHe = "CD",  TenHe = "Chuyên đề" },
		new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" },
	};
}
