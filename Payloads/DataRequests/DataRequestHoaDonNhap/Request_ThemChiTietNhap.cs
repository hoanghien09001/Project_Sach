using SachAPI.Entities;

namespace SachAPI.Payloads.DataRequests.DataRequestHoaDonNhap
{
    public class Request_ThemChiTietNhap
    {
        public string TenSach { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string TacGia { get; set; }
        public int SoLuong { get; set; }

        public int? SachID { get; set; }
        public int TheLoaiSachID { get; set; }
    }
}
