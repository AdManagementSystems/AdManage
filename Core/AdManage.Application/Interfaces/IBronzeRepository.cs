using AdManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Interfaces
{
    public interface IBronzeRepository
    {
        Task<List<BronzePackages>> GetBronzeListWithPackages();
        List<BronzePackages> GetLast5BronzeWithPackages();
        int GetBronzeCount();
    }
}
