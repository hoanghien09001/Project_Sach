using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestNhanVien;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/nhanVien")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpPost("DangKy")]
        public IActionResult DangKy(Request_DangKy request)
        {
            return Ok(_nhanVienService.DangKy(request));
        }
        [HttpPost("DangNhap")]
        public IActionResult DangNhap(Request_DangNhap request)
        {
            return Ok(_nhanVienService.DangNhap(request));
        }
        [HttpPut("SuaThongTinNhanVien")]
        public IActionResult SuaThongTinNhanVien(Request_SuaThongTInNhanVien request)
        {
            return Ok(_nhanVienService.SuaThongTinNhanVien(request));
        }
    }
}
