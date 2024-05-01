
using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
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

        public async Task <IActionResult> Index()
        {
            var bronzePackages = await _getBronzeQueryHandler.Handle();
            var bronzePackagesList = bronzePackages.Select(result => new AdManage.Domain.Entities.BronzePackages
            {
                Id = result.Id,
                Description = result.Description,
                Price = result.Price,
                Image = result.Image,
                CoverImage = result.CoverImage,
                Details1 = result.Details1,
                Details2 = result.Details2,
                Image2 = result.Image2
            }).ToList();

            return View(bronzePackagesList);
        }
    }
}
