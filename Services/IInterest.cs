using API_Models;

namespace Labb_4_API.Services
{
    public interface IInterest<T>
    {
        Task<Interest> AddInterest(string interestName, string interestDescription);
        Task<ICollection<T>> GetAllInterests();
    }
}
