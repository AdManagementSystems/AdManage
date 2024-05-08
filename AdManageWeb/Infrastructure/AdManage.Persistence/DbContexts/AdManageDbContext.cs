using AdManage.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdManage.Persistence.DbContexts
{
    public class AdManageDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AdManageDbContext()
        : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=OnionAdManageDb;Integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<BronzePackages> BronzePackages { get; set; }
        public DbSet<GoldPackages> GoldPackages { get; set; }
        public DbSet<SilverPackages> SilverPackages { get; set; }
    }
  
}
