using System.Threading.Tasks;

namespace CarSellingSystem.Core
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}