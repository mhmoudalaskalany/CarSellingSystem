using System.Collections.Generic;
using System.Threading.Tasks;
using CarSellingSystem.Core.Models;

namespace CarSellingSystem.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);

    }
}