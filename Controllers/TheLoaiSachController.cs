using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestTheLoaiSach;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/TheLoaiSach")]
    [ApiController]
    public class TheLoaiSachController : ControllerBase
    {
        private readonly ITheLoaiSachService _theLoaiSachService;

        public TheLoaiSachController(ITheLoaiSachService theLoaiSachService)
        {
            _theLoaiSachService = theLoaiSachService;
        }
        [HttpPost("ThemTheLoaiSach")]
        public IActionResult ThemTheLoaiSach(Request_ThemTheLoaiSach request)
        {
            return Ok(_theLoaiSachService.ThemTheLoaiSach(request));
        }
    }
}
