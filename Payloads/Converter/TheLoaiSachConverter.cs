using SachAPI.Entities;
using SachAPI.Payloads.DataResponses;

namespace SachAPI.Payloads.Converter
{
    public class TheLoaiSachConverter
    {
        public DataResponseTheLoaiSach EntityToDTO(TheLoaiSach theLoaiSach)
        {
            return new DataResponseTheLoaiSach
            {
                TenLoaiSach = theLoaiSach.TenLoaiSach,
            };
        }
    }
}
