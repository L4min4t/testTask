using testTask.Entities;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class FilmService : BaseService<Film>, IFilmService
{
    public FilmService(IBaseRepository<Film> repository) : base(repository)
    {
    }
}