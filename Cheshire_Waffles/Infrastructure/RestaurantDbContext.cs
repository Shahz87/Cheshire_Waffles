using Cheshire_Waffles.Models;
using Microsoft.EntityFrameworkCore;

namespace Cheshire_Waffles.Infrastructure
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
