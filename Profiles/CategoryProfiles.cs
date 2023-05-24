using AutoMapper;
using Notes_API.Data.Dtos.CategoryDtos;
using Notes_API.Models;

namespace Notes_API.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
