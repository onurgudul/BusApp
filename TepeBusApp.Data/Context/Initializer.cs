using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Utilities.Security;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Data.Context
{
    public class Initializer : CreateDatabaseIfNotExists<AppDbContext>
    {

        protected override void Seed(AppDbContext context)
        {
            byte[] passwordHash, passwordSalt;
            Hashing.CreatePasswordHash("123", out passwordHash, out passwordSalt);
            User admin = new User()
            {
                Name = "Onur",
                Surname = "Güdül",
                Email = "admin@gmail.com",
                isAdmin = true,
                isDelete = false,
                CreatedDate = DateTime.Today,
                PhoneNumber = "0123456789",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            context.Users.Add(admin);
            User user = new User()
            {
                Name = "Hasan",
                Surname = "Türk",
                Email = "user@gmail.com",
                isAdmin = false,
                isDelete = false,
                CreatedDate = DateTime.Today,
                PhoneNumber = "0123456789",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            context.Users.Add(user);

            Travel travel = new Travel()
            {
                ShipNumber = 3455,
                Date = DateTime.Today.AddDays(3),
                From = "İstanbul",
                To = "Samsun",
                Time = DateTime.Now.AddHours(3),
                StartPrice = 100
            };
            context.Travels.Add(travel);
            context.SaveChanges();



        }
    }
}
