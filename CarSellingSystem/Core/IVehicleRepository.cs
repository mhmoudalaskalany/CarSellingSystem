using System.Threading.Tasks;
using CarSellingSystem.Core.Models;

namespace CarSellingSystem.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);

    }
}