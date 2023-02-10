using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AM.ApplicationCore.Domain;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Migrations;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace AM.Infrastructure

{
    public class AMContext:DbContext 
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers  { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }
        public DbSet<Ticket> tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=AirportManagement; 
                       Integrated Security=true;MultipleActiveResultSets=true"); 
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            /*     modelBuilder.Entity<Passenger>()
                     .HasDiscriminator<int>("PassengerType")
                     .HasValue<Passenger>(0)
                 .HasValue<Traveller>(1)
                 .HasValue<Staff>(2);*/

            modelBuilder.Entity<Staff>().ToTable("Staffs");

            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            modelBuilder.Entity<Passenger>().ToTable("Passengers");

            modelBuilder.Entity<ReservationTicket>().HasKey(P => new
            {
                P.DateReservation, P.PassengerFK, P.TicketFK
            }); 
       
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

    }
}