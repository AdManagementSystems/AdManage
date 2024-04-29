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
    public class RemoveGoldCommandHandler
    {
        private readonly IRepository<GoldPackages> _repository;
        public RemoveGoldCommandHandler(IRepository<GoldPackages> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveGoldCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
