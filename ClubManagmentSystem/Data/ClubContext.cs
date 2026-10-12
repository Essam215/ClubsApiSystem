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
        }
    }
}
