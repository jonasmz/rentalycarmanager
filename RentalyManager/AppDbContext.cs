using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalyManager.Entities;

namespace RentalyManager
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Fee>().HasData(
                new Fee { Id = 1, Gama = ValueObjects.RangeEnum.LOW, Pday = 30m, Pkms = 0.1m, Free = 1.75m },
                new Fee { Id = 2, Gama = ValueObjects.RangeEnum.MIDDLE, Pday = 50m, Pkms = 0.18m, Free = 3.1m },
                new Fee { Id = 3, Gama = ValueObjects.RangeEnum.HIGH, Pday = 80m, Pkms = 0.25m, Free = 5m }
            ) ;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Fee> Fees { get; set; }
    }
}
