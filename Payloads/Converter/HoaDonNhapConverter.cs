using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class HoaDonNhapConverter
    {
        private readonly AppDBContext _context;
        private readonly ChiTietNhapConverter _converter;

        public HoaDonNhapConverter()
        {
            _context = new AppDBContext();
            _converter = new ChiTietNhapConverter();
        }
        public DataResponseHoaDonNhap EntityToDTO(HoaDonNhapSach hoaDonNhap)
        {
            return new DataResponseHoaDonNhap
            {
                TenNhanVien = _context.nhanViens.FirstOrDefault(x => x.NhanVienID == hoaDonNhap.NhanVienID).TenNhanVien,
                NgayNhap = hoaDonNhap.NgayNhap,
                ChiTietNhaps = _context.chiTietNhaps.Where(x => x.HoaDonNhapSachID == hoaDonNhap.HoaDonNhapSachID).Select(x => _converter.EntityToDTO(x)).AsQueryable(),
            };
        }
    }
}
