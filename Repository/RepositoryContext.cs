using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherDataConfiguration());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}