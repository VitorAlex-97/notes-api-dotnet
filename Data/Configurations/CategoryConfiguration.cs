using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes_API.Models;

namespace Notes_API.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.ToTable("tb_categories");

            modelBuilder.HasKey(x => x.Id)
                        .HasName("id");

            modelBuilder.Property(p => p.Id)
                        .HasMaxLength(255)
                        .HasColumnName("id")
                        .HasColumnType("character varying")
                        .ValueGeneratedOnAdd();

            modelBuilder.Property(p => p.Label)
                        .IsRequired()
                        .HasColumnName("label");

            modelBuilder.Property(p => p.UserId)
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("user_id");
        }
    }
}
