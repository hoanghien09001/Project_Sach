using SachAPI.Entities;

namespace SachAPI.Payloads.DataRequests.DataRequestKeSach
{
    public class Request_ThemKeSach
    {
        public string TenKeSach { get; set; }

        public List<Request_ThemChiTietSach> themChiTietSachs { get; set; }
    }
}
