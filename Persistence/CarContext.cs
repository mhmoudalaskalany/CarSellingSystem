using Microsoft.EntityFrameworkCore;
namespace CarSellingSystem.Persistence
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {

        }
    }
}