using System.Threading.Tasks;
using CarSellingSystem.Core;
using CarSellingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CarDbContext _context;

        public VehicleRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicle(int id , bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Vehicles.FindAsync(id);
           return  await _context.Vehicles.Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(m => m.Model)
                .ThenInclude(m => m.Make)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }
    }
}
