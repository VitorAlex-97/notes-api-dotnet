using AutoMapper;
using Notes_API.Data.Dtos.UserDtos;
using Notes_API.Models;
using Notes_API.Repository.Interfaces;
using Notes_API.Services.BaseService;
using Notes_API.Services.UserService.Interface;

namespace Notes_API.Services.UserService
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository) : base(userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<ReadUserDto> CreateAsync(CreateUserDto userDto)
        {
            var user = _mapper.Map<CreateUserDto, User>(userDto);

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<User, ReadUserDto>(user);
        }

        
    }
}
