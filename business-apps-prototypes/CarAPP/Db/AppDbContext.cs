using Microsoft.EntityFrameworkCore;
using CarApp.Models;
using CarApp.DTOs;

namespace CarApp.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<ServiceWorkItem> ServiceWorkItems => Set<ServiceWorkItem>();
        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ServiceWorkItem>()
                .HasKey(op => new { op.ServiceId, op.WorkOrderId});
            
            builder.Entity<ServiceWorkItem>()
                .HasOne(op => op.Service)
                .WithMany(services => services.ServiceWorkItems)
                .HasForeignKey(op => op.ServiceId);
            
            builder.Entity<ServiceWorkItem>()
                .HasOne(op => op.WorkOrder)
                .WithMany(workorders => workorders.ServiceWorkItems)
                .HasForeignKey(op => op.WorkOrderId);

            builder.Entity<Person>()
                .Property(p => p.FirstName)
                .IsRequired();
            builder.Entity<Person>()
                .Property(p => p.LastName)
                .IsRequired();
            builder.Entity<Person>()
                .Property(p => p.Email)
                .IsRequired();
            builder.Entity<Person>()
                .HasIndex(p => p.Email)
                .IsUnique();
            builder.Entity<Person>()
                .Property(p => p.CreatedDt)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Car>()
                .Property(c => c.Color)
                .IsRequired();
            builder.Entity<Car>()
                .Property(c => c.Year)
                .IsRequired();
            builder.Entity<Car>()
                .Property(c => c.Make)
                .IsRequired();
            builder.Entity<Car>()
                .Property(c => c.Model)
                .IsRequired();
            builder.Entity<Car>()
                .Property(c => c.CreatedDt)
                .HasDefaultValueSql("GETDATE()");


            builder.Entity<Service>()
                .Property(s => s.Name)
                .IsRequired();
            builder.Entity<Service>()
                .Property(s => s.Price)
                .IsRequired();
            builder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(8,2);

            builder.Entity<WorkOrder>()
                .Property(w => w.CreatedDt)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<WorkOrder>()
                .Property(w => w.Total)
                .HasPrecision(8,2);
            builder.Entity<WorkOrder>()
                .HasOne(w => w.Person)
                .WithMany(w => w.WorkOrders)
                .HasForeignKey(w => w.PersonId);
            builder.Entity<WorkOrder>()
                .HasOne(w => w.Person)
                .WithMany(w => w.WorkOrders)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}