

using System.Threading.Tasks;

namespace CarSellingSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarDbContext _context;

        public UnitOfWork(CarDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
