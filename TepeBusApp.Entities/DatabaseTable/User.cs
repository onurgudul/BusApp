using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TepeBusApp.Entities.DatabaseTable
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name="Soyad")]
        public string Surname { get; set; }
        [Display(Name="Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Display(Name="E-Mail")]
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool isDelete { get; set; }
        public bool isAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        //public ICollection<Ticket> Ticket { get; set; }



    }
}
