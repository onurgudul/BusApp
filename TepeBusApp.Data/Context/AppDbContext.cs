using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Entities.DatabaseTable;

namespace TepeBusApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new Initializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ticket>()// 1-n 
            //      .HasRequired<Travel>(e => e.Travel)
            //      .WithMany(c => c.Ticket)
            //     .HasForeignKey<int>(e => e.TravelId);

            //modelBuilder.Entity<Ticket>()// 1-n 
            //     .HasRequired<User>(e => e.User)
            //     .WithMany(c => c.Ticket)
            //    .HasForeignKey<int>(e => e.UserId);
            //modelBuilder.Entity<Ticket>()// 1-n 
            //   .HasRequired<Seat>(e => e.Seat)
            //   .WithMany(c => c.Ticket)
            //  .HasForeignKey<int>(e => e.SeatId);


            //modelBuilder.Entity<Seat>()// 1-n 
            // .HasRequired<Travel>(e => e.Travel)
            // .WithMany(c => c.Seats)
            //.HasForeignKey<int>(e => e.TravelId);



        }


    }
}
