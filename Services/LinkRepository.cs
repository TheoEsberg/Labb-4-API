using API_Models;
using Labb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.InteropServices;

namespace Labb_4_API.Services
{
    public class LinkRepository : ILink<Link>
    {
        private AppDbContext _appDbContext;

        public LinkRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Link> AddInterestToPersonByPersonId(int linkId, int personId, string interestName)
        {
            var getInterestByName = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.InterestName == interestName);
            if (getInterestByName == null)
            {
                return null;
            }

            var newLink = new Link { InterestId = getInterestByName.InterestId, PersonId = personId, LinkURL = "placeholder" };
            _appDbContext.Add(newLink);
            await _appDbContext.SaveChangesAsync();

            return newLink;
        }

        public async Task<Link> AddLinkForPersonById(int personId, int interestId, string linkURL)
        {
            var newLink = new Link { PersonId = personId, InterestId = interestId, LinkURL = linkURL };
            _appDbContext.Add(newLink);
            await _appDbContext.SaveChangesAsync();

            return newLink;
        }

        public async Task<ICollection<Link>> GetAllLinks()
        {
            return await _appDbContext.Links.ToListAsync();
        }

        public async Task<ICollection<string>> GetInterestByPersonId(int id)
        {
            return await _appDbContext.Links.Include(i => i.Interest).Where(p => p.PersonId == id).Select(n => n.Interest.InterestName).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksByPersonId(int id)
        {
            return await _appDbContext.Links.Where(p => p.PersonId == id).ToListAsync();
        }
    }
}
