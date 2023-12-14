using SachAPI.Payloads.DataRequests.DataRequestHoaDonNhap;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface IHoaDonNhapService
    {
        ResponseObject<DataResponseHoaDonNhap> ThemHoaDonNhap(Request_ThemHoaDonNhap request);
    }
}
