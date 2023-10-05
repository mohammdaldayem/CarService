using Carseer.CarService.Domain.CarMakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Carseer.CarService.EntityFrameworkCore.EntityFrameworkCore
{
    public class CarServiceDBContext: DbContext
    {
        public CarServiceDBContext(DbContextOptions<CarServiceDBContext> options)
        : base(options)
        {
        }
        public DbSet<CarMake> CarMake { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMake>(b => { 
            b.Property(x=> x.Id).IsRequired().ValueGeneratedNever();
            b.Property(x=> x.Name).IsRequired();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
           optionsBuilder.UseSqlServer(GetConnectionStringFromConfiguration());
        }
        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString("CarService");
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
