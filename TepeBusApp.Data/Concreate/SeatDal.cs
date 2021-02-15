using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Concreate;
using TepeBusApp.Data.Abstract;
using TepeBusApp.Data.Context;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Data.Concreate
{
    public class SeatDal : Repository<Seat, AppDbContext>, ISeatDal
    {
        public List<Seat> GetSeat(int? id)
        {
            using (var context = new AppDbContext())
            {
                return context.Set<Seat>().Where(x=>x.TravelId==id).ToList();
            }
        }


    }
}
