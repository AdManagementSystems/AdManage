using AdManage.Domain.Common;
using AdManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.DbContexts
{
    public class AdManageDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=OnionAdManageDb;Integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<BronzePackages> BronzePackages { get; set; }
    }
}
