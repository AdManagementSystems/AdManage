using AdManage.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Domain.Entities
{
    public class BronzePackages:PackagesEntityBase
    {
        public List<Reservation> Reservations { get; set; }
    }
}
