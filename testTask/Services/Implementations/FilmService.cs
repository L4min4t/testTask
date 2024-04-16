using testTask.Entities;
using testTask.Models;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class FilmService : BaseService<Film>, IFilmService
{
    public FilmService(IFilmRepository repository) : base(repository)
    {
    }

    public async Task CreateAsync(CreateFilmModel filmModel)
    {
        var film = new Film
        {
            Name = filmModel.Name,
            Director = filmModel.Director,
            Release = filmModel.Release,
        };

        film.FilmCategories = filmModel.FilmCategories
            .Select(categoryId => new FilmCategory { CategoryId = categoryId }).ToList();

        await Repository.CreateAsync(film);
    }
}