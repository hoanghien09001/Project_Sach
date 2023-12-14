using SachAPI.Payloads.DataRequests.DataRequestTheLoaiSach;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface ITheLoaiSachService
    {
        ResponseObject<DataResponseTheLoaiSach> ThemTheLoaiSach(Request_ThemTheLoaiSach request);
    }
}
