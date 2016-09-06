using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSystem.Core.Interfaces
{
    public interface IBusRepository
    {
        IQueryable<BusInfo> GetBusInfo();
    }
}
