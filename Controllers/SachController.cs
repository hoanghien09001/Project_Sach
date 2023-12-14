using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SachAPI.Payloads.DataRequests.DataRequestSach;
using SachAPI.Services.Interfaces;

namespace SachAPI.Controllers
{
    [Route("api/Sach")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly ISachService _sachService;

        public SachController(ISachService sachService)
        {
            _sachService = sachService;
        }
        [HttpPost("SuaSach")]
        public IActionResult SuaSach(Request_SuaSach request)
        {
            return Ok(_sachService.SuaSach(request));   
        }
        [HttpDelete("XoaSach")]
        public IActionResult XoaSach(int sachID)
        {
            return Ok(_sachService.XoaSach(sachID));
        }
    }
}
