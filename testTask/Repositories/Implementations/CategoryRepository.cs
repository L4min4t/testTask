using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Interfaces;

namespace testTask.Repositories.Implementations;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}