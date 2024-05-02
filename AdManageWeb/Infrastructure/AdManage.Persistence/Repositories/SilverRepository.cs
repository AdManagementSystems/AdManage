using AdManage.Application.Interfaces;
using AdManage.Domain.Entities;
using AdManage.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Repositories
{
    public class SilverRepository:ISilverRepository
    {
        private readonly AdManageDbContext _context;
        public SilverRepository(AdManageDbContext context)
        {
            _context = context;
        }
        public int GetSilverCount()
        {
            var value = _context.SilverPackages.Count();
            return value;
        }

        public async Task<List<SilverPackages>> GetSilverListWithPackages()
        {
            var values = await _context.SilverPackages.Include(x => x.Description).ToListAsync();
            return values;
        }

        public List<SilverPackages> GetLast5SilverWithPackages()
        {
            var values = _context.SilverPackages.Include(x => x.Description).OrderByDescending(x => x.Id).Take(5).ToList();
            return values;
        }
    }
}
