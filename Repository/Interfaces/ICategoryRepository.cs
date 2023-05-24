using Notes_API.Models;

namespace Notes_API.Repository.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Task<IEnumerable<Category>> FindAll();

    }
}
