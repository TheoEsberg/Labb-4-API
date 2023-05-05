namespace Labb_4_API.Services
{
    public interface IPerson<T>  
    {
        Task<ICollection<T>> GetAllPersons();
        Task<T> GetPersonById(int id);
    }
}
