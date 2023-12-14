using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class ChiTietNhapConverter
    {
        public DataResponseChiTietNhap EntityToDTO(ChiTietNhap chiTietNhap)
        {
            return new DataResponseChiTietNhap
            {
                NgayXuatBan = chiTietNhap.NgayXuatBan,
                SoLuong = chiTietNhap.SoLuong,
                TacGia = chiTietNhap.TacGia,
                TenSach = chiTietNhap.TenSach
            };
        }
    }
}
