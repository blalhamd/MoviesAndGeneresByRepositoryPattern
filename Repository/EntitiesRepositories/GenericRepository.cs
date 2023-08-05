

using Microsoft.EntityFrameworkCore;
using MiddleLayer.APPDBCONTEXT;
using MiddleLayer.Interfaces;

namespace MiddleLayer.EntitiesRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            var query = await _context.Set<T>().ToListAsync();
           
            return query;
        }

        public async Task<T> GetById(object id)
        {
            var search = await _context.Set<T>().FindAsync(id);

            return search;
        }

        public void add(T entity)
        {
             _context.Set<T>().Add(entity);

        }

        public void addRange(IEnumerable<T> entities)
        {
             _context.Set<T>().AddRange(entities);

        }


        public void update(T entity)
        {
            
            _context.Set<T>().Update(entity);
        }

        public void delete(T entity)
        {

            _context.Set<T>().Remove(entity);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
