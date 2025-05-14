using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(e => e.Price)
                        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                        .Property(e => e.Discount)
                        .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
