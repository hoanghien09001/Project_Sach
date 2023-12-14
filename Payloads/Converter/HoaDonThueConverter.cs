using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class HoaDonThueConverter
    {
        private readonly AppDBContext _context;
        private readonly ChiTietThueConverter _converter;

        public HoaDonThueConverter()
        {
            _context = new AppDBContext();
            _converter = new ChiTietThueConverter();
        }
        public DataResponseHoaDonThue EntityToDTO(HoaDonThueSach hoaDonThue)
        {
            return new DataResponseHoaDonThue
            {
                TenKhachHang = _context.khachHangs.FirstOrDefault(x => x.KhachHangID == hoaDonThue.KhachHangID).TenKhachHang,
                TenNhanVien = _context.nhanViens.FirstOrDefault(x => x.NhanVienID == hoaDonThue.NhanVienID).TenNhanVien,
                NgayThue = DateTime.Now,
                SoLuong = hoaDonThue.SoLuong,
                TongTien = hoaDonThue.TongTien,
                ChiTietThues = _context.chiTietThues.Where(x => x.HoaDonThueSachID == hoaDonThue.HoaDonThueSachID).Select(x => _converter.EntityToDTO(x)).AsQueryable(),
            };
        }
    }
}
