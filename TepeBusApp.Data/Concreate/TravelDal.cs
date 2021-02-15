using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Concreate;
using TepeBusApp.Core.Utilities.Result;
using TepeBusApp.Data.Abstract;
using TepeBusApp.Data.Context;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Data.Concreate
{
    public class TravelDal : Repository<Travel, AppDbContext>, ITravelDal
    {
        public List<Travel> TravelWithSeat()
        {
            using (var context = new AppDbContext())
            {
                return context.Set<Travel>().Include("Seat").ToList();
            }
        }
    }
}
