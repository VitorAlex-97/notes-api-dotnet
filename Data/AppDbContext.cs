using Microsoft.EntityFrameworkCore;
using Notes_API.Data.Configurations;
using Notes_API.Models;

namespace Notes_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
