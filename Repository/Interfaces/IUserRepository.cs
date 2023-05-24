using Notes_API.Models;

namespace Notes_API.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<IEnumerable<User>> FindAll();
    }
}
