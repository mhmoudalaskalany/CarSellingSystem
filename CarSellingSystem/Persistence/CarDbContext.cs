﻿using CarSellingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Persistence
{
    public class CarDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.Contact).Property(c => c.ContactName).HasColumnName("ContactName");
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.Contact).Property(c => c.ContactEmail).HasColumnName("ContactEmail");
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.Contact).Property(c => c.ContactPhone).HasColumnName("ContactPhone");

            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new
            {
                vf.VehicleId,
                vf.FeatureId
            });
        }
    }
}
