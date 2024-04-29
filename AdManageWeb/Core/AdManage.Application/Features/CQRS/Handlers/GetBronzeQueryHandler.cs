using AdManage.Application.Features.CQRS.Results;
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
    public class GetBronzeQueryHandler
    {
        private readonly IRepository<BronzePackages> _repository;

        public GetBronzeQueryHandler(IRepository<BronzePackages> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBronzeQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBronzeQueryResult
            {
                Id = x.Id,
                Price = x.Price,
                Image2 = x.Image2,
                Image=x.Image,
                CoverImage = x.CoverImage,
                Description = x.Description,
                Details1 = x.Details1,
                Details2 = x.Details2
            }).ToList();
        }
    }
}
