using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Notes_API.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<TEntity?> FindOneById(Guid id);

        public IQueryable<TEntity> GetIQueryable();
        public Task CreateAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<bool> SaveChangesAsync();
    }
}
