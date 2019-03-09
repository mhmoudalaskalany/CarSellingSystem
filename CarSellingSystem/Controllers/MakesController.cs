using System.Collections.Generic;
using System.Threading.Tasks;
using CarSellingSystem.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Controllers
{
    
    public class MakesController : Controller
    {
        private readonly CarDbContext _context;

        public MakesController(CarDbContext context)
        {
            _context = context;
        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await _context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}
