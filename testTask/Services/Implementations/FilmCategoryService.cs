using testTask.Entities;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class FilmCategoryService : BaseService<FilmCategory>, IFilmCategoryService
{
    public FilmCategoryService(IBaseRepository<FilmCategory> repository) : base(repository)
    {
    }
}