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
    public class UpdateBronzeCommandHandler
    {
        private IRepository<BronzePackages> _repository;

        public UpdateBronzeCommandHandler(IRepository<BronzePackages> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBronzeCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Description = command.Description;
            values.Price = command.Price;
            values.CoverImage = command.CoverImage;
            values.Details1 = command.Details1;
            values.Details2 = command.Details2;
            values.Image = command.Image;
            values.Image2 = command.Image2;
            await _repository.UpdateAsync(values);
        }
    }
}
