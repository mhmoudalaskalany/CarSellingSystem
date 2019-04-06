using System.Threading.Tasks;

namespace CarSellingSystem.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}