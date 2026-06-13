using Microsoft.EntityFrameworkCore;
using MVC_PROJECT.Models;

namespace MVC_PROJECT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Database=MVC_PROJECT;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobiles" },
                new Category { Id = 2, Name ="Tablets" },
                new Category { Id = 3, Name = "Laptops" }
                ); // seeding data (shown only once, when you run the project first time), need to add migration and update database after adding this code
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 13", Price = 999.99m, Description = "Latest iPhone model", CategoryId = 1 },
                new Product { Id = 2, Name = "Samsung Galaxy S21", Price = 899.99m, Description = "Flagship Samsung phone", CategoryId = 1 },
                new Product { Id = 3, Name = "iPad Pro", Price = 799.99m, Description = "High-end tablet from Apple", CategoryId = 2 },
                new Product { Id = 4, Name = "Microsoft Surface Pro", Price = 999.99m, Description = "Versatile 2-in-1 device", CategoryId = 2 },
                new Product { Id = 5, Name = "MacBook Pro", Price = 1299.99m, Description = "Powerful laptop from Apple", CategoryId = 3 },
                new Product { Id = 6, Name = "Dell XPS 13", Price = 1099.99m, Description = "Compact and powerful laptop", CategoryId = 3 }
                ); // seeding data (shown only once, when you run the project first time), need to add migration and update database after adding this code
        }
    }
}
