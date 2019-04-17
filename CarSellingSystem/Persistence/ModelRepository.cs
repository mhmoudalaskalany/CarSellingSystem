using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSellingSystem.Core;
using CarSellingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Persistence
{
    public class ModelRepository : IModelRepository
    {
        private readonly CarDbContext _context;

        public ModelRepository(CarDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _context.Models.ToListAsync().ConfigureAwait(false);
        }
    }

}
