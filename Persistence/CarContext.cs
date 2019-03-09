using CarSellingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;
namespace CarSellingSystem.Persistence
{
    public class CarContext :DbContext
    {
        //we dont need a dbset for models because ef will discover model class from the relationship with make class
        //we will add dbset if we need to query them in future
        public DbSet<Make> Makes { get; set; }
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {
        }
    }
}