using System.Collections.Generic;
using System.Linq;
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

        public async Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Vehicles.FindAsync(id).ConfigureAwait(false);
            return await _context.Vehicles.Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(m => m.Model)
                .ThenInclude(m => m.Make)
                .FirstOrDefaultAsync(v => v.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(Filter filter)
        {
            var query = _context.Vehicles
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .AsQueryable();
            if (filter.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == filter.MakeId);
            return await query.ToListAsync().ConfigureAwait(false);
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
