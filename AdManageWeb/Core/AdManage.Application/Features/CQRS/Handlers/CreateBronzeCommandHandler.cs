
using AdManage.Application.Features.CQRS.Commands;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class CreateBronzeCommandHandler
    {
        private IRepository<BronzePackages> _repository;

        public CreateBronzeCommandHandler(IRepository<BronzePackages> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBronzeCommand command)
        {
            await _repository.CreateAsync(new BronzePackages
            {
                Description = command.Description,
                CoverImage = command.CoverImage,
                Details1 = command.Details1,
                Details2 = command.Details2,
                Image=command.Image,
                Image2 = command.Image2,
                Price = command.Price
            });
        }
    }
}
