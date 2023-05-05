using API_Models;

namespace Labb_4_API.Services
{
    public interface ILink<T>
    {
        Task<ICollection<string>> GetInterestByPersonId(int id);
        Task<IEnumerable<Link>> GetLinksByPersonId(int id);
        Task<Link> AddInterestToPersonByPersonId(int linkId, int personId, string interestName);
        Task<Link> AddLinkForPersonById(int personId, int interestId, string linkURL);
        Task<ICollection<T>> GetAllLinks();

    }
}
