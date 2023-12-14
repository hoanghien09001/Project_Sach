using SachAPI.Payloads.DataRequests.DataRequestNhanVien;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;

namespace SachAPI.Services.Interfaces
{
    public interface INhanVienService
    {
        ResponseObject<DataResponseNhanVien> DangKy(Request_DangKy request);
        string DangNhap(Request_DangNhap request);
        ResponseObject<DataResponseNhanVien> SuaThongTinNhanVien(Request_SuaThongTInNhanVien request);
    }
}
