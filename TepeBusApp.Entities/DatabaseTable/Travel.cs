using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TepeBusApp.Entities.DatabaseTable
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Sefer Numarası")]
        public int ShipNumber { get; set; }
        [Display(Name = "Nereden")]
        public string From { get; set; }
        [Display(Name = "Nereye")]
        public string To { get; set; }
        //public ICollection<Ticket> Ticket { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Tarih")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Saat")]
        public DateTime Time { get; set; }
        [Display(Name ="Fiyat")]
        public int StartPrice { get; set; }
    }
}
