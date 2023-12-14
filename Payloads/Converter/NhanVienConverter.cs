using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class NhanVienConverter
    {
        private readonly AppDBContext _context;

        public NhanVienConverter()
        {
            _context = new AppDBContext();
        }
        public DataResponseNhanVien EntityToDTO(NhanVien nhanVien)
        {
            return new DataResponseNhanVien
            {
                TenNhanVien = nhanVien.TenNhanVien,
                DiaChi = nhanVien.DiaChi,
                Email = nhanVien.Email,
                GioiTinh = nhanVien.GioiTinh,
                NgaySinh = nhanVien.NgaySinh,
                SDT = nhanVien.SDT,
                TenQuyenHan = _context.quyenHans.FirstOrDefault(x => x.QuyenHanId == nhanVien.QuyenHanID).TenQuyenHan
            };
        }
    }
}
