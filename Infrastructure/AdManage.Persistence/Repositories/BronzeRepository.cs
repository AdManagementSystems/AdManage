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
    public class BronzeRepository : IBronzeRepository
    {
        private readonly AdManageDbContext _context;
        public BronzeRepository(AdManageDbContext context)
        {
            _context = context;
        }
        public int GetBronzeCount()
        {
            var value = _context.BronzePackages.Count();
            return value;
        }

        public async Task<List<BronzePackages>> GetBronzeListWithPackages()
        {
            var values=await _context.BronzePackages.Include(x=>x.Description).ToListAsync();
            return values;
        }

        public List<BronzePackages> GetLast5BronzeWithPackages()
        {
            var values = _context.BronzePackages.Include(x => x.Description).OrderByDescending(x => x.Id).Take(5).ToList();
            return values;
        }
    }
}
