using AdManage.Application.Abstrtaction;
using AdManage.Application.DTOs;
using AdManage.Application.RequestParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DenemeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeAPIController : Controller
    {
        private readonly IBronzeService _bronzeService;

        public DenemeAPIController(IBronzeService bronzeService)
        {
            _bronzeService = bronzeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEvents([FromQuery] Pagination pagination)
        {
            var events = await _bronzeService.GetAllEventAsync(pagination);
            return Ok(events);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEvent(CreateBronzeDTO createEventDto)
        {
            await _bronzeService.createEventAsync(createEventDto);
            return Ok();
        }
    }
}
