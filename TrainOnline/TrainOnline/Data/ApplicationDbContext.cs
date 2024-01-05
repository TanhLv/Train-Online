using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainOnline.Models;

namespace TrainOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            DataSeed.Seeding(this);
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleDetail> ScheduleDetails { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<_Status> Statuses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<TrainCar> TrainCars { get; set; }
        public virtual DbSet<TrainTrip> TrainTrips { get; set; }
        public virtual DbSet<_Type> Types { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<CustomUser> CustomUsers { get; set; }

    }
}