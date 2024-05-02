﻿using AdManage.Application.Features.CQRS.Results;
using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Handlers
{
    public class GetSilverQueryHandler
    {
        private readonly IRepository<SilverPackages> _repository;

        public GetSilverQueryHandler(IRepository<SilverPackages> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetSilverQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSilverQueryResult
            {
                Id = x.Id,
                Price = x.Price,
                Image2 = x.Image2,
                Image = x.Image,
                CoverImage = x.CoverImage,
                Description = x.Description,
                Details1 = x.Details1,
                Details2 = x.Details2
            }).ToList();
        }
    }
}
