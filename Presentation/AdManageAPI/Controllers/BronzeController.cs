using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BronzeController : ControllerBase
    {
        private readonly CreateBronzeCommandHandler _createBronzeCommandHandler;
        private readonly GetBronzeByIdQueryHandler _getBronzeByIdQueryHandler;
        private readonly GetBronzeQueryHandler _getBronzeQueryHandler;
        private readonly UpdateBronzeCommandHandler _updateBronzeCommandHandler;
        private readonly RemoveBronzeCommandHandler _removeBronzeCommandHandler;

        public BronzeController(CreateBronzeCommandHandler createBronzeCommandHandler, GetBronzeByIdQueryHandler getBronzeByIdQueryHandler,
            GetBronzeQueryHandler getBronzeQueryHandler, UpdateBronzeCommandHandler updateBronzeCommandHandler, RemoveBronzeCommandHandler removeBronzeCommandHandler)
        {
            _createBronzeCommandHandler = createBronzeCommandHandler;
            _getBronzeByIdQueryHandler = getBronzeByIdQueryHandler;
            _getBronzeQueryHandler = getBronzeQueryHandler;
            _updateBronzeCommandHandler = updateBronzeCommandHandler;
            _removeBronzeCommandHandler = removeBronzeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BronzeList()
        {
            var values = await _getBronzeQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBronze(int id)
        {
            var value = await _getBronzeByIdQueryHandler.Handle(new GetBronzeByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBronze(CreateBronzeCommand command)
        {
            await _createBronzeCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBronze(int id)
        {
            await _removeBronzeCommandHandler.Handle(new RemoveBronzeCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBronze(UpdateBronzeCommand command)
        {
            await _updateBronzeCommandHandler.Handle(command);
            return Ok();
        }
    }
}
