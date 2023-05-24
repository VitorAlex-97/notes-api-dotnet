using Microsoft.EntityFrameworkCore;
using Notes_API.Data;
using Notes_API.Models;
using Notes_API.Repository.Interfaces;

namespace Notes_API.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> FindAll()
        {
            return await this.GetIQueryable()
                             .AsNoTracking()
                             .ToListAsync();
        }
    }
}
