using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes_API.Data.Dtos.CategoryDtos;
using Notes_API.Data.Dtos.UserDtos;
using Notes_API.Models;
using Notes_API.Services.CategoryService;

namespace Notes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper) 
        {
            _categoryService = categoryService;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneByIdAsync(Guid id)
        {
            var category = await _categoryService.GetOneByIdAsync(id);

            if (category is not null)
            {
                return Ok(category);
            }

            return BadRequest("Categoria com id " + id + "não existe");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var newCategory = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.CreateAsync(newCategory);
            var isCreted = await _categoryService.SaveChangesAsync();
            if (isCreted)
            {
                return CreatedAtAction(nameof(Create), new { Id = newCategory.Id }, newCategory);
            }
            else
            {
                return BadRequest("Não foi possível criar uma nova categoria");
            }
            
        }
    }
}
