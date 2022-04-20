using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParcelLocker.Models.Entities;

namespace ParcelLocker.Models
{
    public class ParcelLockerContext : IdentityDbContext<Courier>
    {
        public ParcelLockerContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplaintReason>()
                .HasKey(c => new { c.ComplaintId, c.ReasonId });
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ComplaintReason> ComplaintReasons { get; set; }

    }
}
