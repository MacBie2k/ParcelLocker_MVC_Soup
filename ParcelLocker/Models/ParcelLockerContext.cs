﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParcelLocker.Models.Entities;

namespace ParcelLocker.Models
{
    public class ParcelLockerContext : IdentityDbContext<Courier>
    {
        public ParcelLockerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<ComplaintReason> ComplaintReasons { get; set; }



    }
}
