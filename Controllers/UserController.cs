using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes_API.Data;
using Notes_API.Data.Dtos.UserDtos;
using Notes_API.Models;
using Notes_API.Services.UserService.Interface;

namespace Notes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController (IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllasync(Guid id)
        {
            var user = await _userService.GetOneByIdAsync(id);
            ReadUserDto readUserDto = _mapper.Map<ReadUserDto>(user);
            if (readUserDto is null)
            {
                return NotFound();
            }
            return Ok(readUserDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            var readUserDto = await _userService.CreateAsync(createUserDto);
            return CreatedAtAction(nameof(Create), new { Id = readUserDto.Id }, readUserDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return Ok(_mapper.Map<ReadUserDto[]>(users));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDto updateUserDto)
        {
            var userToUpdate = _mapper.Map<User>(updateUserDto);
            _userService.Update(userToUpdate);
            var isValid = await _userService.SaveChangesAsync();
            if (isValid)
            {
                return Ok(_mapper.Map<ReadUserDto>(userToUpdate));
            }
            else
            {
                return BadRequest("Ocorreu um erro ao tentar atualizar o usuário" + updateUserDto.Id);
            }    
        }
        
    }
}
