using testTask.Entities;
using testTask.Models;
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

        if (film != null)
        {
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

    public async Task<List<ViewFilmModel>?> GetFilmViewModelsAsync()
    {
        var films = await FindAllAsync();

        if (films != null)
        {
            var viewModels = new List<ViewFilmModel>();

            foreach (var film in films)
            {
                var viewModel = new ViewFilmModel()
                {
                    Id = film.Id,
                    Name = film.Name,
                    Director = film.Director,
                    Release = film.Release,
                    Categories = film.Categories
                };
                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        return null;
    }

    public async Task<ViewFilmModel?> GetFilmViewModelAsync(int id)
    {
        var film = await FindByIdAsync(id);

        if (film != null)
        {
            return new ViewFilmModel()
            {
                Id = film.Id,
                Name = film.Name,
                Director = film.Director,
                Release = film.Release,
                Categories = film.Categories
            };
        }

        return null;
    }

    public async Task UpdateFilmCategoriesAsync(EditFilmCategoriesModel model)
    {
        var film = await FindByIdAsync(model.Id);
        if (film != null)
        {
            film.Categories.Clear();

            foreach (var categoryId in model.FilmCategories)
            {
                var category = await _categoryRepository.FindByIdAsync(categoryId);

                if (category != null) film.Categories.Add(category);
            }

            await Repository.UpdateAsync(film);
        }
    }

    public async Task<EditFilmModel?> GetEditFilmModel(int id)
    {
        var film = await Repository.FindByIdAsync(id);

        if (film != null)
        {
            return new EditFilmModel
            {
                Id = film.Id,
                Name = film.Name,
                Director = film.Director,
                Release = film.Release,
                FilmCategories = film.Categories.Select(fc => fc.Id).ToList()
            };
        }

        return null;
    }
}