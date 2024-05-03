using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class SilverPackagesController : Controller
    {
        private readonly CreateSilverCommandHandler _createSilverCommandHandler;
        private readonly GetSilverByIdQueryHandler _getSilverByIdQueryHandler;
        private readonly GetSilverQueryHandler _getSilverQueryHandler;
        private readonly UpdateSilverCommandHandler _updateSilverCommandHandler;
        private readonly RemoveSilverCommandHandler _removeSilverCommandHandler;

        public SilverPackagesController(CreateSilverCommandHandler createSilverCommandHandler, GetSilverByIdQueryHandler getSilverByIdQueryHandler, GetSilverQueryHandler getSilverQueryHandler, UpdateSilverCommandHandler updateSilverCommandHandler, RemoveSilverCommandHandler removeSilverCommandHandler)
        {
            _createSilverCommandHandler = createSilverCommandHandler;
            _getSilverByIdQueryHandler = getSilverByIdQueryHandler;
            _getSilverQueryHandler = getSilverQueryHandler;
            _updateSilverCommandHandler = updateSilverCommandHandler;
            _removeSilverCommandHandler = removeSilverCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var SilverPackages = await _getSilverQueryHandler.Handle();
            var SilverPackagesList = SilverPackages.Select(result => new AdManage.Domain.Entities.SilverPackages
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

            return View(SilverPackagesList);
        }
    }
}

