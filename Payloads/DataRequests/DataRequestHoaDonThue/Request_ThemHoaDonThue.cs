using SachAPI.Entities;

namespace SachAPI.Payloads.DataRequests.DataRequestHoaDonThue
{
    public class Request_ThemHoaDonThue
    {
        public DateTime NgayThue { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }

        public int KhachHangID { get; set; }
        public int NhanVienID { get; set; }

        public List<Request_ThemChiTietThue> themChiTietThues { get; set; }
    }
}
