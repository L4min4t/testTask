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
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(c => c.ParentCategoryId).IsUnique(false);
        });

        modelBuilder.Entity<Film>()
            .HasMany(f => f.Categories)
            .WithMany(c => c.Films)
            .UsingEntity<Dictionary<string, object>>(
                "FilmCategory",
                j => j
                    .HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .HasConstraintName("FK_FilmCategory_CategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .HasConstraintName("FK_FilmCategory_FilmId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.ToTable("FilmCategories");
                    j.HasKey("FilmId", "CategoryId");
                });
    }
}