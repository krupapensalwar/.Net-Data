using BusSystem.Core;
using BusSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSystem.Repository
{
  public  class BusRepository : IBusRepository
    {
        public IQueryable<BusInfo> GetBusInfo()
        {
            BusReservationSystemDBEntities busContext = new BusReservationSystemDBEntities();
            return busContext.BusInfoes;
        }
    }
}
