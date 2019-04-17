using System.Collections.Generic;
using System.Threading.Tasks;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core.Models;

namespace CarSellingSystem.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(Filter filter);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);

    }
}