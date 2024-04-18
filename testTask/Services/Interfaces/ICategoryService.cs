using testTask.Entities;
using testTask.Models;

namespace testTask.Services.Interfaces;

public interface ICategoryService : IBaseService<Category>
{
    public Task CreateAsync(CreateCategoryModel createCategoryModel);
    public Task UpdateAsync(EditCategoryModel editCategoryModel);
}