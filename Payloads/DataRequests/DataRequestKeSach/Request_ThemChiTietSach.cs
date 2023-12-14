using SachAPI.Entities;

namespace SachAPI.Payloads.DataRequests.DataRequestKeSach
{
    public class Request_ThemChiTietSach
    {
        public int TrangThaiSachID { get; set; }

        public int SachID { get; set; }

        public int KeSachID { get; set; }
    }
}
