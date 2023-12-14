using SachAPI.Payloads.DataRequests.DataRequestHoaDonThue;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface IHoaDonThueService
    {
        ResponseObject<DataResponseHoaDonThue> ThemHoaDonThue(Request_ThemHoaDonThue request);
        List<DataResponseChiTietThue> HienThiSachThue(int khachHangID);
        List<DataResponseChiTietThue> HienThiSachHoaDon(int hoaDonID);
    }
}
