using EfCoreBlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBlazorDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<Poll> Polls { get; set; }

    }

}
