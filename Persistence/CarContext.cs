using CarSellingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
namespace CarSellingSystem.Persistence
{
    public class CarContext :DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {
        }
    }
}