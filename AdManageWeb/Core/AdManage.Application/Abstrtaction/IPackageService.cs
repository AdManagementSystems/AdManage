using AdManage.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Abstrtaction
{
    public interface IPackageService
    {
        Task createEventAsync(CreatePackageDTO createPackageDTO);
        Task<IEnumerable<PackageDTO>> GetAllEventAsync(Pagination pagination);
    }
}
