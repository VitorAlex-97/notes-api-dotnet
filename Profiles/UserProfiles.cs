using AutoMapper;
using Notes_API.Data.Dtos.UserDtos;
using Notes_API.Models;

namespace Notes_API.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User[], ReadUserDto[]>();
            CreateMap<User, ReadUserDto>()
                .ForMember(
                    user => user.Password, options => {
                        options.Ignore();
                    }
                );
            CreateMap<UpdateUserDto, User>();
        }
    }
}
