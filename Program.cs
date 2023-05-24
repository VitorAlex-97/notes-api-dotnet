using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes_API.Data;
using Notes_API.Models;
using Notes_API.Repository;
using Notes_API.Repository.Interfaces;
using Notes_API.Services.BaseService;
using Notes_API.Services.CategoryService;
using Notes_API.Services.UserService;
using Notes_API.Services.UserService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();

builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
builder.Services.AddScoped<IBaseService<Category>, BaseService<Category>>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("NotesDb"));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
