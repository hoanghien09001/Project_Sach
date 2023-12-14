using SachAPI.Entities;

namespace SachAPI.Payloads.DataRequests.DataRequestHoaDonNhap
{
    public class Request_ThemHoaDonNhap
    {
        public DateTime NgayNhap { get; set; }

        public int NhanVienID { get; set; }

        public List<Request_ThemChiTietNhap> themChiTietNhaps { get; set; }
    }
}
