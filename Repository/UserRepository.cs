using Microsoft.EntityFrameworkCore;
using Notes_API.Data;
using Notes_API.Models;
using Notes_API.Repository.Interfaces;

namespace Notes_API.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await this.GetIQueryable().ToListAsync();
        }
    }
}
