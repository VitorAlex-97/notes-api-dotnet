using Notes_API.Data.Dtos.UserDtos;
using Notes_API.Models;
using Notes_API.Services.BaseService;

namespace Notes_API.Services.UserService.Interface
{
    public interface IUserService : IBaseService<User>
    {
        public Task<ReadUserDto> CreateAsync(CreateUserDto user);
    }
}
