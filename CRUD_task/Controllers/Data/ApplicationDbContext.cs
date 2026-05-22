using CRUD_task.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_task.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {   
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Database=CRUD_task;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
