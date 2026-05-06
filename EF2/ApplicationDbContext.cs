using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Database=EF2;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(

                new User { Id = 1, Name = "Alice Henderson", Price = 45.50m },
                new User { Id = 2, Name = "Bob Marlowe", Price = 12.00m },
                new User { Id = 3, Name = "Charlie Day", Price = 99.99m },
                new User { Id = 4, Name = "Diana Prince", Price = 550.00m },
                new User { Id = 5, Name = "Edward Nigma", Price = 75.25m },
                new User { Id = 6, Name = "Fiona Gallagher", Price = 21.00m },
                new User { Id = 7, Name = "George Bluth", Price = 950.00m },
                new User { Id = 8, Name = "Hannah Abbott", Price = 8.99m },
                new User { Id = 9, Name = "Ian Curtis", Price = 60.00m },
                new User { Id = 10, Name = "Julia Child", Price = 125.75m }


            );

        }        
    }
}
