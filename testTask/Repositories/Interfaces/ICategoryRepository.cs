using testTask.Entities;

namespace testTask.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public Task<List<Category>?> FindAllAsync();
}