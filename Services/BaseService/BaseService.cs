using Microsoft.EntityFrameworkCore;
using Notes_API.Repository.Interfaces;

namespace Notes_API.Services.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetIQueryable()
                                    .AsNoTracking()
                                    .ToListAsync();
        }

        public async Task<TEntity?> GetOneByIdAsync(Guid id)
        {
            return await _repository.FindOneById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return await _repository.SaveChangesAsync();
        }
    }
}
