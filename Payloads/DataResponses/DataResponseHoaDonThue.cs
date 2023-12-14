using SachAPI.Entities;

namespace SachAPI.Payloads.DataResponses
{
    public class DataResponseHoaDonThue
    {
        public string TenKhachHang {  get; set; }
        public string TenNhanVien {  get; set; }
        public DateTime NgayThue { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }

        public IQueryable<DataResponseChiTietThue> ChiTietThues { get; set; }
    }
}
