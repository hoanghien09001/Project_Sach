using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class ChiTietThueConverter
    {
        private readonly AppDBContext _context;

        public ChiTietThueConverter()
        {
            _context = new AppDBContext();
        }

        public DataResponseChiTietThue EntityToDTO(ChiTietThue chiTietThue)
        {
            return new DataResponseChiTietThue
            {
                TenSach = _context.sachs.FirstOrDefault(x => x.SachID == _context.chiTietSachs.FirstOrDefault(y => y.ChiTietSachID == chiTietThue.ChiTietSachID).SachID).TenSach,
                ThoiGianThue = chiTietThue.ThoiGianThue,
            };
        }
    }
}
