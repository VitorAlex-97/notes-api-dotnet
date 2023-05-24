using Notes_API.Models;
using Notes_API.Repository.Interfaces;
using Notes_API.Services.BaseService;
using Notes_API.Services.UserService.Interface;

namespace Notes_API.Services.CategoryService
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUserService _userService;
        public CategoryService(IBaseRepository<Category> repository, IUserService userService) : base(repository)
        {
           _userService = userService;
        }

        override public async Task CreateAsync(Category category)
        {
            var isExisteUser = await _userService.GetOneByIdAsync(category.UserId);

            if (isExisteUser is not null) 
            {
               await this.CreateAsync(category);
               await this.SaveChangesAsync();
            }
        }
    }
}
