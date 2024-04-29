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
    public class RemoveBronzeCommandHandler
    {
        private readonly IRepository<BronzePackages> _repository;
        public RemoveBronzeCommandHandler(IRepository<BronzePackages> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBronzeCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
