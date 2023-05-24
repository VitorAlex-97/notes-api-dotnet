namespace Notes_API.Services.BaseService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        public Task<TEntity?> GetOneByIdAsync(Guid id);
        public Task CreateAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<bool> SaveChangesAsync();
    }
}
