using Microsoft.EntityFrameworkCore;
using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Interfaces;

namespace testTask.Repositories.Implementations;

public class FilmRepository : BaseRepository<Film>, IFilmRepository
{
    public FilmRepository(ApplicationContext context) : base(context)
    {
    }

    public override async Task<List<Film>?> FindAllAsync() => await DbSet.Include(f => f.Categories).ToListAsync();
}