using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Interfaces;

namespace testTask.Repositories.Implementations;

public class FilmRepository : BaseRepository<Film>, IFilmRepository
{
    public FilmRepository(ApplicationContext context) : base(context)
    {
    }
}