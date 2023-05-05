using API_Models;
using Labb_4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_API.Services
{
    public class PersonRepository : IPerson<Person>
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task<ICollection<Person>> GetAllPersons()
        {
            return await _appDbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            var result = await _appDbContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            return result;
        }
    }
}
