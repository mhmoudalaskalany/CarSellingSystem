using CarSellingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Persistence
{
    public class CarDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
            
        }
    }
}
