using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestHoaDonNhap;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/hoaDonNhap")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private readonly IHoaDonNhapService _hoaDonNhapService;

        public HoaDonNhapController(IHoaDonNhapService hoaDonNhapService)
        {
            _hoaDonNhapService = hoaDonNhapService;
        }
        [HttpPost("ThemHoaDonNhap")]
        public IActionResult ThemHoaDonNhap(Request_ThemHoaDonNhap request)
        {
            return Ok(_hoaDonNhapService.ThemHoaDonNhap(request));
        }
    }
}
