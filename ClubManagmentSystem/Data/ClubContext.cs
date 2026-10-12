using ClubManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Data
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Facility> facilities { get; set; }
        public DbSet<Member> members   { get; set; }
        public DbSet<MemberShip> memberShips { get; set; }
        public DbSet<Payment> payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasOne(m => m.MemberShip).WithOne(m => m.Member).HasForeignKey<MemberShip>(m => m.MemberId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Member>().HasMany(m => m.Bookings).WithOne(m => m.Member).HasForeignKey(m => m.MemberId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Facility>().HasMany(m => m.Bookings).WithOne(m => m.Facility).HasForeignKey(m => m.FacilityId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MemberShip>().HasMany(m => m.Payments).WithOne(m => m.MemberShip).HasForeignKey(m => m.MemberShipId).OnDelete(DeleteBehavior.Cascade);


            // Members
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@example.com",
                    Phone = "01011112222",
                    DateOfBirth = new DateTime(2000, 5, 15)
                },
                new Member
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    Phone = "01022223333",
                    DateOfBirth = new DateTime(1998, 9, 20)
                },
                new Member
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@example.com",
                    Phone = "01033334444",
                    DateOfBirth = new DateTime(2002, 1, 10)
                }
            );

            // Memberships
            modelBuilder.Entity<MemberShip>().HasData(
                new MemberShip
                {
                    Id = 1,
                    Type = "Gold",
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = new DateTime(2027, 1, 1),
                    Price = 5000,
                    Status = "Active",
                    MemberId = 1
                },
                new MemberShip
                {
                    Id = 2,
                    Type = "Silver",
                    StartDate = new DateTime(2026, 3, 1),
                    EndDate = new DateTime(2027, 3, 1),
                    Price = 3000,
                    Status = "Active",
                    MemberId = 2
                },
                new MemberShip
                {
                    Id = 3,
                    Type = "Basic",
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2026, 1, 1),
                    Price = 1500,
                    Status = "Expired",
                    MemberId = 3,
                }
            );

            // Facilities
            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    Id = 1,
                    Name = "Swimming Pool",
                    Capacity = 30,
                    HourlyPrice = 250
                },
                new Facility
                {
                    Id = 2,
                    Name = "Gym Hall",
                    Capacity = 40,
                    HourlyPrice = 150
                },
                new Facility
                {
                    Id = 3,
                    Name = "Tennis Court",
                    Capacity = 10,
                    HourlyPrice = 200
                }
            );

            // Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 10, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GroupSize = 10,
                    Status = "Confirmed",
                    FacilityId = 1,
                    MemberId = 1
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 10, 11),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    GroupSize = 8,
                    Status = "Confirmed",
                    FacilityId = 2,
                    MemberId = 2
                },
                new Booking
                {
                    Id = 3,
                    BookingDate = new DateTime(2026, 10, 12),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    GroupSize = 4,
                    Status = "Cancelled",
                    FacilityId = 3, 
                    MemberId = 3
                }
            );

            // Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 5000,
                    PaymentDate = new DateTime(2026, 1, 1),
                    PaymentMethod = "Card",
                    MemberShipId = 1,
                },
                new Payment
                {
                    Id = 2,
                    Amount = 3000,
                    PaymentDate = new DateTime(2026, 3, 1),
                    PaymentMethod = "Cash",
                    MemberShipId = 2,
                },
                new Payment
                {
                    Id = 3,
                    Amount = 1500,
                    PaymentDate = new DateTime(2025, 1, 1),
                    PaymentMethod = "Wallet",
                    MemberShipId= 3,
                }
            );
        }
    }
}
