using AdManage.Application.Features.CQRS.Queries;
using AdManage.Application.Features.CQRS.Results;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class GetGoldByIdQueryHandler
    {
        private readonly IRepository<GoldPackages> _repository;
        public GetGoldByIdQueryHandler(IRepository<GoldPackages> repository)
        {
            _repository = repository;
        }
        public async Task<GetGoldByIdQueryResult> Handle(GetGoldByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetGoldByIdQueryResult
            {
                Id = values.Id,
                CoverImage = values.CoverImage,
                Description = values.Description,
                Details1 = values.Details1,
                Details2 = values.Details2,
                Image = values.Image,
                Image2 = values.Image2,
                Price = values.Price
            };
        }
    }
}
