using testTask.Entities;
using testTask.Models;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class CategoryService : BaseService<Category>, ICategoryService
{
    public CategoryService(ICategoryRepository repository) : base(repository)
    {
    }

    public async Task CreateAsync(CreateCategoryModel createCategoryModel)
    {
        var category = new Category() { Name = createCategoryModel.Name };

        if (createCategoryModel.ParentCategoryId != null)
        {
            var parentCategory = await Repository.FindByIdAsync(createCategoryModel.ParentCategoryId.Value);
            if (parentCategory != null) category.ParentCategoryId = createCategoryModel.ParentCategoryId;
        }

        await Repository.CreateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var categories = await Repository.FindAllAsync();
        foreach (var category in categories)
        {
            if (category.ParentCategoryId == id) category.ParentCategoryId = null;
        }

        var categoryToDelete = await Repository.FindByIdAsync(id);

        await Repository.DeleteAsync(categoryToDelete);
    }

    public async Task UpdateAsync(EditCategoryModel editCategoryModel)
    {
        var category = await Repository.FindByIdAsync(editCategoryModel.Id);

        category.Name = editCategoryModel.Name;
        category.ParentCategoryId = editCategoryModel.ParentCategoryId;

        await Repository.UpdateAsync(category);
    }
}