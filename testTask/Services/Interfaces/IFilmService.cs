using testTask.Entities;
using testTask.Models;

namespace testTask.Services.Interfaces;

public interface IFilmService : IBaseService<Film>
{
    public Task CreateAsync(CreateFilmModel filmModel);
    public Task UpdateAsync(EditFilmModel model);
}