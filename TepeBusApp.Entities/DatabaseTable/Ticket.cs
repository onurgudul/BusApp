using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TepeBusApp.Entities.DatabaseTable
{
    public class Ticket
    {
        public int Id { get; set; }
        //public virtual Travel Travel { get; set; }
        //public int TravelId { get; set; }
        //public virtual User User { get; set; }
        public int UserId { get; set; }
        //public virtual Seat Seat { get; set; }
        public int SeatId { get; set; }
        public bool isDeleted { get; set; }
        public int Price { get; set; }
        public int TravelId { get; set; }
       

    }
}
