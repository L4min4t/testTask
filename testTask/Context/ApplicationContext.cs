using Microsoft.EntityFrameworkCore;
using testTask.Entities;

namespace testTask.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FilmCategory> FilmCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);

            entity.Property(e => e.Director).IsRequired().HasMaxLength(200);

            entity.Property(e => e.Release).IsRequired();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);

            entity.HasOne(c => c.ParentCategory)
                .WithOne()
                .HasForeignKey<Category>(c => c.ParentCategoryId)
                .IsRequired(false);
        });

        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasKey(fc => new { fc.FilmId, fc.CategoryId });

            entity.HasOne(fc => fc.Film)
                .WithMany(f => f.FilmCategories)
                .HasForeignKey(fc => fc.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(fc => fc.Category)
                .WithMany(c => c.FilmCategories)
                .HasForeignKey(fc => fc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}