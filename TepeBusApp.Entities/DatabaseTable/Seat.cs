using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TepeBusApp.Entities.DatabaseTable
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int TravelId { get; set; }
        public string Seats { get; set; }
        public bool isDeleted { get; set; }

        //public ICollection<Ticket> Ticket { get; set; }
    }
}
