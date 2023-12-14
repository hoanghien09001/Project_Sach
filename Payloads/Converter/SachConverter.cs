using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class SachConverter
    {
        private readonly AppDBContext _context;

        public SachConverter()
        {
            _context = new AppDBContext();
        }

        public DataResponseSach EntityToDTO(Sach sach)
        {
            return new DataResponseSach
            {
                TenSach = sach.TenSach,
                GiaChoThue = sach.GiaChoThue,
                NgayXuatBan = sach.NgayXuatBan,
                SoLuong = sach.SoLuong,
                TacGia = sach.TacGia,
                TenTheLoai = _context.theLoaiSachs.SingleOrDefault(x => x.TheLoaiSachID == sach.TheLoaiSachID).TenLoaiSach
            };
        }
    }
}
