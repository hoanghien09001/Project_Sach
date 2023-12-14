using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestHoaDonThue;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/hoaDonThue")]
    [ApiController]
    public class HoaDonThueController : ControllerBase
    {
        private readonly IHoaDonThueService _hoaDonThueService;

        public HoaDonThueController(IHoaDonThueService hoaDonThueService)
        {
            _hoaDonThueService = hoaDonThueService;
        }
        [HttpPost("themHoaDonThue")]
        public IActionResult ThemHoaDonThue(Request_ThemHoaDonThue request)
        {
            return Ok(_hoaDonThueService.ThemHoaDonThue(request));
        }
        [HttpGet("HienThiSachThue")]
        public IActionResult HienThiHoaDonThue(int KhachHangID)
        {
            return Ok(_hoaDonThueService.HienThiSachThue(KhachHangID));
        }
        [HttpGet("HienThiSachHoaDon")]
        public IActionResult HienThiHoaDon(int hoaDonID)
        {
            return Ok(_hoaDonThueService.HienThiSachHoaDon(hoaDonID));
        }
    }
}
