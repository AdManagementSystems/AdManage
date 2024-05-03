using AdManage.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AdManageWeb.Controllers
{
    public class GoldPackagesController : Controller
    {
        private readonly CreateGoldCommandHandler _createGoldCommandHandler;
        private readonly GetGoldByIdQueryHandler _getGoldByIdQueryHandler;
        private readonly GetGoldQueryHandler _getGoldQueryHandler;
        private readonly UpdateGoldCommandHandler _updateGoldCommandHandler;
        private readonly RemoveGoldCommandHandler _removeGoldCommandHandler;

        public GoldPackagesController(CreateGoldCommandHandler createGoldCommandHandler, GetGoldByIdQueryHandler getGoldByIdQueryHandler, GetGoldQueryHandler getGoldQueryHandler, UpdateGoldCommandHandler updateGoldCommandHandler, RemoveGoldCommandHandler removeBronzeCommandHandler)
        {
            _createGoldCommandHandler = createGoldCommandHandler;
            _getGoldByIdQueryHandler = getGoldByIdQueryHandler;
            _getGoldQueryHandler = getGoldQueryHandler;
            _updateGoldCommandHandler = updateGoldCommandHandler;
            _removeGoldCommandHandler = removeBronzeCommandHandler;
        }

        public async Task<IActionResult> PackagesGold()
        {
            var goldPackages = await _getGoldQueryHandler.Handle();
            var goldPackagesList = goldPackages.Select(result => new AdManage.Domain.Entities.GoldPackages
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

            return View(goldPackagesList);
        }
    }
}

