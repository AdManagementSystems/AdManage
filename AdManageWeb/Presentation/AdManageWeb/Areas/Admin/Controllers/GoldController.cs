using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Persistence.Enterprise_Service_Bus;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System.Threading.Tasks;

namespace AdManageWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GoldController : Controller
    {
        private readonly CreateGoldCommandHandler _createGoldCommandHandler;
        private readonly GetGoldByIdQueryHandler _getGoldByIdQueryHandler;
        private readonly GetGoldQueryHandler _getGoldQueryHandler;
        private readonly UpdateGoldCommandHandler _updateGoldCommandHandler;
        private readonly RemoveGoldCommandHandler _removeGoldCommandHandler;
        private readonly IMessageSession _messageSession;

        public GoldController(CreateGoldCommandHandler createGoldCommandHandler, GetGoldByIdQueryHandler getGoldByIdQueryHandler, GetGoldQueryHandler getGoldQueryHandler, UpdateGoldCommandHandler updateGoldCommandHandler, RemoveGoldCommandHandler removeGoldCommandHandler, IMessageSession messageSession)
        {
            _createGoldCommandHandler = createGoldCommandHandler;
            _getGoldByIdQueryHandler = getGoldByIdQueryHandler;
            _getGoldQueryHandler = getGoldQueryHandler;
            _updateGoldCommandHandler = updateGoldCommandHandler;
            _removeGoldCommandHandler = removeGoldCommandHandler;
            _messageSession = messageSession;
        }

        public async Task<IActionResult> Index()
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
        [HttpGet]
        public IActionResult AddGold()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGold(CreateGoldCommand command)
        {
            await _createGoldCommandHandler.Handle(command);
            var message = new GoldPackageAddedMessage
            {
                Id = command.Id,
                Description = command.Description,
                Price = command.Price,
                Image = command.Image,
                CoverImage = command.CoverImage,
                Details1 = command.Details1,
                Details2 = command.Details2,
                Image2 = command.Image2
            };

            await _messageSession.Publish(message);

            // Toastr mesajını ekle
            TempData["ToastrMessage"] = "Gold paketi başarıyla eklendi.";
            return RedirectToAction("Gold", "Admin");
        }
        public async Task<IActionResult> DeleteGold(int id)
        {
            await _removeGoldCommandHandler.Handle(new RemoveGoldCommand(id));
            return RedirectToAction("Gold", "Admin");
        }

        [HttpGet]
		public async Task<IActionResult> UpdateGold(int id)
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
			}).ToList().FirstOrDefault((result => result.Id == id));
			return View(goldPackagesList);
		}
		[HttpPost]
        public async Task<IActionResult> UpdateGold(UpdateGoldCommand command)
        {
            
            await _updateGoldCommandHandler.Handle(command);
            return RedirectToAction("Gold", "Admin");
        }
    }
}
