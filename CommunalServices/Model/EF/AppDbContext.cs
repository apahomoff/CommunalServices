using CommunalServices.Model.EF.EntitiesConfiguration;
using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceHouse> ServiceHouses { get; set; }
        public DbSet<RegistrationValue> RegistrationValues { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Provider> ServiceProviders { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<NormGigacalorie> NormGigacalories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new MeasureConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StreetConfiguration());
        }
    }
}
