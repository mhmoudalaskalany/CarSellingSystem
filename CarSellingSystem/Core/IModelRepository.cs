

using System.Collections.Generic;
using System.Threading.Tasks;
using CarSellingSystem.Core.Models;

namespace CarSellingSystem.Core
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllAsync();
    }
}
