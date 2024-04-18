using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
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
            .Include(c => c.ParentCategory)
            .Include(c => c.Films)
            .ToListAsync();
    }
}