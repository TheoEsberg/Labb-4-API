using API_Models;
using Labb_4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_API.Services
{
    public class InterestRepository : IInterest<Interest>
    {
        private AppDbContext _appDbContext;

        public InterestRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Interest> AddInterest(string interestName, string interestDescription)
        {
            var exists = await _appDbContext.Interests.FirstOrDefaultAsync(n => n.InterestName == interestName);
            if (exists != null)
            {
                return null;
            }

            var newInterest = new Interest { InterestName = interestName, InterestDescription = interestDescription, Links = new List<Link>() };
            _appDbContext.Interests.Add(newInterest);
            await _appDbContext.SaveChangesAsync();
            return newInterest;
        }

        public async Task<ICollection<Interest>> GetAllInterests()
        {
            return await _appDbContext.Interests.ToListAsync();
        }
    }
}
