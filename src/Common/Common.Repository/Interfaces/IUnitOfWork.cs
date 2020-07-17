using System.Threading.Tasks;

namespace Common.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}