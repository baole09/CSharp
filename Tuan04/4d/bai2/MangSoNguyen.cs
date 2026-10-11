using System.Collections.Generic;
using System.Linq;

namespace bai2
{
    public class MangSoNguyen
    {
        // Thuộc tính: dữ liệu mảng
        private List<int> _ds = new();

        public int SoPhanTu => _ds.Count;
        public bool Rong => _ds.Count == 0;

        // ===== Nhập / đọc =====
        public void Nhap(IEnumerable<int> ds)
        {
            _ds = new List<int>(ds);
        }

        public int LayGiaTri(int viTri) => _ds[viTri];

        public override string ToString() => string.Join(" ", _ds);

        // ===== Sắp xếp =====
        public void SapXepTang() => _ds.Sort();

        public void SapXepGiam()
        {
            _ds.Sort();
            _ds.Reverse();
        }

        public bool DaSapTang()
        {
            for (int i = 1; i < _ds.Count; i++)
                if (_ds[i] < _ds[i - 1]) return false;
            return true;
        }

        // ===== Tìm kiếm =====
        // Trả về mọi vị trí (tính từ 0) có giá trị cần tìm
        public List<int> TimViTri(int giaTri)
        {
            var kq = new List<int>();
            for (int i = 0; i < _ds.Count; i++)
                if (_ds[i] == giaTri) kq.Add(i);
            return kq;
        }

        // ===== Thêm / xóa / thay thế (trả về false nếu không thực hiện được) =====
        public bool ThemTaiViTri(int giaTri, int viTri)
        {
            if (viTri < 0 || viTri > _ds.Count) return false;
            _ds.Insert(viTri, giaTri);
            return true;
        }

        public bool XoaGiaTri(int giaTri) => _ds.Remove(giaTri);   // xóa phần tử đầu tiên khớp

        public bool XoaTaiViTri(int viTri)
        {
            if (viTri < 0 || viTri >= _ds.Count) return false;
            _ds.RemoveAt(viTri);
            return true;
        }

        public bool ThayTheGiaTri(int giaTriCu, int giaTriMoi)
        {
            int i = _ds.IndexOf(giaTriCu);
            if (i < 0) return false;
            _ds[i] = giaTriMoi;
            return true;
        }

        public bool ThayTheViTri(int viTri, int giaTriMoi)
        {
            if (viTri < 0 || viTri >= _ds.Count) return false;
            _ds[viTri] = giaTriMoi;
            return true;
        }

        // ===== Tổng =====
        public long TongMang() => _ds.Sum(x => (long)x);
        public long TongChan() => _ds.Where(x => x % 2 == 0).Sum(x => (long)x);
        public long TongLe() => _ds.Where(x => x % 2 != 0).Sum(x => (long)x);

        // ===== Lớn nhất / nhỏ nhất (gọi khi mảng không rỗng) =====
        public int GiaTriLonNhat() => _ds.Max();
        public int GiaTriNhoNhat() => _ds.Min();
    }
}