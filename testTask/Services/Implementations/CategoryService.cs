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
        if (categories != null)
        {
            foreach (var category in categories)
                if (category.ParentCategoryId == id)
                    category.ParentCategoryId = null;

            var categoryToDelete = await Repository.FindByIdAsync(id);
            if (categoryToDelete != null)
                await Repository.DeleteAsync(categoryToDelete);
        }
    }

    public async Task UpdateAsync(EditCategoryModel editCategoryModel)
    {
        var category = await Repository.FindByIdAsync(editCategoryModel.Id);
        if (category != null)
        {
            category.Name = editCategoryModel.Name;
            category.ParentCategoryId = editCategoryModel.ParentCategoryId;

            await Repository.UpdateAsync(category);
        }
    }

    public async Task<List<Category>?> GetInheritAvailableCategoriesAsync(int id)
    {
        var categories = await Repository.FindAllAsync();

        if (categories == null || categories.Count == 0)
            return null;

        var availableCategories = new List<Category>();

        foreach (var category in categories)
        {
            if (category.Id != id)
                if (!IsInherited(category, id))
                    availableCategories.Add(category);
        }

        return availableCategories.Count > 0 ? availableCategories : null;
    }

    private bool IsInherited(Category category, int id)
    {
        var parent = category.ParentCategory;

        while (parent != null)
        {
            if (parent.Id == id)
                return true;

            parent = parent.ParentCategory;
        }

        return false;
    }

    public async Task<EditCategoryModel?> GetEditCategoryModelAsync(int id)
    {
        var category = await Repository.FindByIdAsync(id);

        return category != null
            ? new EditCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            }
            : null;
    }

    public async Task<List<ViewCategoryModel>?> GetViewCategoryModelsAsync()
    {
        var categories = await Repository.FindAllAsync();
        if (categories != null)
        {
            var viewModels = new List<ViewCategoryModel>();

            foreach (var category in categories)
            {
                var viewModel = new ViewCategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentCategoryId = category.ParentCategoryId,
                    ParentCategory = category.ParentCategory,
                    Films = category.Films
                };
                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        return null;
    }
}