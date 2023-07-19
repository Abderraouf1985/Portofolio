using Microsoft.EntityFrameworkCore;
using WebApplication30.Models;

namespace WebApplication30.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        
    }
}
