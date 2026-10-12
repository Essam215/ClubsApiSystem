using ClubManagmentSystem.Data;
using ClubManagmentSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ClubContext _context;

        public GenericRepo(ClubContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
