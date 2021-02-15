using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Entities.ViewModels
{
    public class TicketViewModel
    {
        public IEnumerable<Travel> Travels { get; set; }
        public IEnumerable<User> Users { get; set; }
        public List<Seat> Seats { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
