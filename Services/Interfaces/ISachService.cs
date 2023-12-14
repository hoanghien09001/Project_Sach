using SachAPI.Payloads.DataRequests.DataRequestSach;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface ISachService
    {
        ResponseObject<DataResponseSach> SuaSach(Request_SuaSach request);
        ResponseObject<DataResponseSach> XoaSach(int sachID);
    }
}
