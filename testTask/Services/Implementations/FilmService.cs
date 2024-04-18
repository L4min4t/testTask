using testTask.Entities;
using testTask.Models;
using testTask.Repositories.Implementations;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class FilmService : BaseService<Film>, IFilmService
{
    private readonly ICategoryRepository _categoryRepository;

    public FilmService(IFilmRepository repository, ICategoryRepository categoryRepository) : base(repository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(CreateFilmModel filmModel)
    {
        var film = new Film
        {
            Name = filmModel.Name,
            Director = filmModel.Director,
            Release = filmModel.Release,
            Categories = new List<Category>()
        };

        foreach (var categoryId in filmModel.FilmCategories)
        {
            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category != null)
            {
                film.Categories.Add(category);
            }
        }

        await Repository.CreateAsync(film);
    }

    public async Task UpdateAsync(EditFilmModel model)
    {
        var film = await Repository.FindByIdAsync(model.Id);

        film.Categories.Clear();

        foreach (var categoryId in model.FilmCategories)
        {
            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category != null)
            {
                film.Categories.Add(category);
            }
        }

        film.Name = model.Name;
        film.Director = model.Director;
        film.Release = model.Release;

        await Repository.UpdateAsync(film);
    }
}