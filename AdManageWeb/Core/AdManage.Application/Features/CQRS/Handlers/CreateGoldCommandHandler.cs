using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class CreateGoldCommandHandler
    {
        private IRepository<GoldPackages> _repository;

        public CreateGoldCommandHandler(IRepository<GoldPackages> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateGoldCommand command)
        {
            await _repository.CreateAsync(new GoldPackages
            {
                Description = command.Description,
                CoverImage = command.CoverImage,
                Details1 = command.Details1,
                Details2 = command.Details2,
                Image = command.Image,
                Image2 = command.Image2,
                Price = command.Price
            });
        }
    }
}
