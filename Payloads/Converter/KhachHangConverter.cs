using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class KhachHangConverter
    {
        public KhachHangConverter()
        {
        }
        public DataResponseKhachHang EntityToDTO(KhachHang khachHang)
        {
            return new DataResponseKhachHang
            {
                TenKhachHang = khachHang.TenKhachHang,
                DiaChi = khachHang.DiaChi,
                GioiTinh = khachHang.GioiTinh,
                NgaySinh = khachHang.NgaySinh,
                SDT = khachHang.SDT,
            };
        }
    }
}
