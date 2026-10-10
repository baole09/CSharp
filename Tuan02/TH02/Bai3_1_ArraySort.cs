/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 22/09/2026
 */

/*
 * CHƯƠNG TRÌNH SẮP XẾP ĐỐI TƯỢNG BẰNG ARRAY.SORT
 *
 * Phát biểu đề bài:
 * Dùng Array.Sort để sắp xếp các đối tượng của một lớp.
 *
 * Ý tưởng:
 * Lớp SinhVien thực hiện IComparable<SinhVien>.
 * CompareTo xác định thứ tự. Array.Sort dùng CompareTo.
 *
 * Mã giả:
 * 1   tạo mảng đối tượng
 * 2   Array.Sort(mảng)
 * 3   xuất mảng
 */
using System;
class SinhVien:IComparable<SinhVien>
{
    public string HoTen{get;set;} public double Diem{get;set;}
    public SinhVien(string hoTen,double diem){HoTen=hoTen;Diem=diem;}
    public int CompareTo(SinhVien other){return string.Compare(HoTen,other.HoTen,StringComparison.CurrentCulture);}
    public override string ToString(){return HoTen+" - "+Diem;}
}
class Bai3_1_ArraySort
{
    static void Main(string[] args)
    {
        SinhVien[] ds={new SinhVien("Tran B",8),new SinhVien("Nguyen A",9),new SinhVien("Le C",7)};
        Array.Sort(ds);
        foreach(SinhVien sv in ds)Console.WriteLine(sv);
    }
}
