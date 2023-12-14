using SachAPI.Payloads.DataRequests.DataRequestKhachHang;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface IKhachHangService
    {
        ResponseObject<DataResponseKhachHang> ThemKhachHang(Request_ThemKhachHang request);
    }
}
