using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes_API.Models;
using System.Reflection.Emit;

namespace Notes_API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("tb_users");

            modelBuilder.HasKey(p => p.Id)
            .HasName("id");

            modelBuilder.Property(p => p.Id)
            .HasMaxLength(255)
            .HasColumnName("id")
            .HasColumnType("character varying")
            .ValueGeneratedOnAdd();

            modelBuilder.Property(p => p.Username)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("username");

            modelBuilder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("email");

            modelBuilder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("password");

            modelBuilder.Property(p => p.Photo)
            .HasColumnType("text")
            .HasColumnName("photo");
        }
    }
}
