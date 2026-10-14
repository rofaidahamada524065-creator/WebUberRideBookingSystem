using Microsoft.EntityFrameworkCore;
using WebUberRideBookingSystem.Model;

namespace WebUberRideBookingSystem.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> rides { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<Rating> rating { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(a => a.Vehicle).WithOne(a => a.Drive).HasForeignKey<Vehicle>(a => a.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.Payment).WithOne(a => a.Ride).HasForeignKey<Payment>(a => a.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.Rating).WithOne(a => a.Rrde).HasForeignKey<Rating>(a => a.RideId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(a => a.RideRider).WithOne(q => q.Rider).HasForeignKey(w => w.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(a => a.DriverRide).WithOne(q => q.Driver).HasForeignKey(w => w.DriverId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>(entety =>
            {
                entety.HasKey(a => a.Id);
                entety.Property(a => a.FullName).IsRequired().HasMaxLength(100);
                entety.Property(a => a.Password).IsRequired();
                entety.Property(a => a.phonenumber).IsRequired();
                entety.Property(a => a.Email).IsRequired();
                entety.HasIndex(a => a.Email).IsUnique();

            });

            modelBuilder.Entity<Vehicle>(entety =>
            {
                entety.HasKey(a => a.Id);
                entety.Property(a => a.PlateNumber).IsRequired().HasMaxLength(150);
                entety.Property(a => a.color).IsRequired();
                entety.Property(a => a.DriverId).IsRequired();
            });

            modelBuilder.Entity<Ride>(entety =>
            {
                entety.HasKey(a => a.Id);
                entety.Property(a => a.PickupLocation).IsRequired().HasMaxLength(150);
                entety.Property(a => a.DropOffLocation).IsRequired().HasMaxLength(150);
                entety.Property(a => a.Status).IsRequired();
            });

            modelBuilder.Entity<Payment>(entety =>
            {
                entety.HasKey(a => a.Id);
                entety.Property(a => a.Status).IsRequired();
                entety.Property(a => a.PaymentDate).IsRequired();
                entety.Property(a => a.PaymentMethod).IsRequired();

            });

            modelBuilder.Entity<Rating>(entety =>
            {
                entety.HasKey(a => a.Id);
                entety.Property(a => a.Comment).IsRequired().HasMaxLength(150);

            });


                modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "Rofaida Hamada",
                Email = "Ro@gmail.com",
                Password = "Ro@1233",
                phonenumber = "01005620",
                Role = "Vehicle",
                DriverId = 1,
                RiderId = 1
            });

            modelBuilder.Entity<Ride>().HasData(new Ride
            {
                Id = 1,
                PickupLocation = "jegdewfgkeuj",
                DropOffLocation = "jddldkjqwldwq",
                Fare = 1263,
                Status = "Pegane",
                RiderId = 1,
                DriverId = 1,
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                PlateNumber = "245sqs",
                color = "red",
                DriverId = 1
            });



        }
    }
}
