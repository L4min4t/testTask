using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Interfaces;

namespace testTask.Repositories.Implementations;

public class FilmCategoryRepository : BaseRepository<FilmCategory>, IFilmCategoryRepository
{
    public FilmCategoryRepository(ApplicationContext context) : base(context)
    {
    }
}