using Microsoft.EntityFrameworkCore;
using Notes_API.Data;
using Notes_API.Models;
using Notes_API.Repository.Interfaces;
using System.Runtime.CompilerServices;

namespace Notes_API.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
             _context.Set<TEntity>().Remove(entity); 
        }

        public async Task<TEntity?> FindOneById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetIQueryable()
        {
            return  _context.Set<TEntity>().AsQueryable();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
        }
    }
}
