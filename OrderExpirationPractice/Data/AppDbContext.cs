using Microsoft.EntityFrameworkCore;
using OrderExpirationPractice.Models;

namespace OrderExpirationPractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
