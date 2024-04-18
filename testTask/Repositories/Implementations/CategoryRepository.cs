using Microsoft.EntityFrameworkCore;
using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Interfaces;

namespace testTask.Repositories.Implementations;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }

    public override async Task<List<Category>?> FindAllAsync()
    {
        return await DbSet
            .Include(c => c.Films)
            .Include(c => c.ParentCategory)
            .ToListAsync();
    }
}