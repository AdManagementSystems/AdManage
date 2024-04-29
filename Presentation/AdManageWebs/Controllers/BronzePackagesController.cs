using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWebs.Controllers
{
    public class BronzePackagesController : Controller
    {
        private readonly CreateBronzeCommandHandler _createBronzeCommandHandler;
        private readonly GetBronzeByIdQueryHandler _getBronzeByIdQueryHandler;
        private readonly GetBronzeQueryHandler _getBronzeQueryHandler;
        private readonly UpdateBronzeCommandHandler _updateBronzeCommandHandler;
        private readonly RemoveBronzeCommandHandler _removeBronzeCommandHandler;

        public BronzePackagesController(CreateBronzeCommandHandler createBronzeCommandHandler, GetBronzeByIdQueryHandler getBronzeByIdQueryHandler, GetBronzeQueryHandler getBronzeQueryHandler, UpdateBronzeCommandHandler updateBronzeCommandHandler, RemoveBronzeCommandHandler removeBronzeCommandHandler)
        {
            _createBronzeCommandHandler = createBronzeCommandHandler;
            _getBronzeByIdQueryHandler = getBronzeByIdQueryHandler;
            _getBronzeQueryHandler = getBronzeQueryHandler;
            _updateBronzeCommandHandler = updateBronzeCommandHandler;
            _removeBronzeCommandHandler = removeBronzeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _getBronzeQueryHandler.Handle();
            return Ok(values);
        }
    }
}
