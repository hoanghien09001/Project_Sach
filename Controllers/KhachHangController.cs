using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestKhachHang;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/khachHang")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }
        [HttpPost("ThemKhachHang")]
        public IActionResult ThemKhachHang(Request_ThemKhachHang request)
        {
            return Ok(_khachHangService.ThemKhachHang(request));
        }
    }
}
