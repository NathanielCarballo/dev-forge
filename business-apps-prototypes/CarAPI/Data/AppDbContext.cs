using Microsoft.EntityFrameworkCore;
using CarApi.Models;

namespace CarApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set;} = default!;
        public DbSet<Car> Cars { get; set;} = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(x => x.User)
                .WithMany(x => x.Cars);

            builder.Entity<Car>().ToTable("Car");
            builder.Entity<User>().ToTable("User");
            
            new DbInitializer(builder).Seed();
        }
    }
}