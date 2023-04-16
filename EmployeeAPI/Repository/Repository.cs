using EmployeeAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppdbContext _context;

        public Repository(AppdbContext appdbContext)
        {
            _context = appdbContext;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }    
    }
}
