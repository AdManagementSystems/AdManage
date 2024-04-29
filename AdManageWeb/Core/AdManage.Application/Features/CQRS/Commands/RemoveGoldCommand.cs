using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Application.Features.CQRS.Commands
{
    public class RemoveGoldCommand
    {
        public RemoveGoldCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
