using testTask.Entities;
using testTask.Models;

namespace testTask.Services.Interfaces;

public interface ICategoryService : IBaseService<Category>
{
    public Task CreateAsync(CreateCategoryModel createCategoryModel);
    public Task UpdateAsync(EditCategoryModel editCategoryModel);
    public Task<List<Category>?> GetInheritAvailableCategoriesAsync(int id);
    public Task<EditCategoryModel?> GetEditCategoryModelAsync(int id);
    public Task<List<ViewCategoryModel>?> GetViewCategoryModelsAsync();
}