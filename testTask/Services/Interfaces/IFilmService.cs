using testTask.Entities;
using testTask.Models;

namespace testTask.Services.Interfaces;

public interface IFilmService : IBaseService<Film>
{
    public Task CreateAsync(CreateFilmModel filmModel);
    public Task UpdateAsync(EditFilmModel model);
    public Task<List<ViewFilmModel>?> GetFilmViewModelsAsync();
    public Task<ViewFilmModel?> GetFilmViewModelAsync(int id);
    public Task UpdateFilmCategoriesAsync(EditFilmCategoriesModel model);
    public Task<EditFilmModel?> GetEditFilmModel(int id);
}