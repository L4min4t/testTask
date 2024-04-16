using System.Linq.Expressions;
using testTask.Entities;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T>
    where T : class, IEntity, new()
{
    protected readonly IBaseRepository<T> Repository = repository;

    public virtual async Task<List<T>?> FindAllAsync()
    {
        var entities = await Repository.FindAllAsync();
        return entities;
    }

    public virtual async Task<T?> FindByIdAsync(int id)
    {
        var entity = await Repository.FindByIdAsync(id);
        return entity;
    }

    public virtual async Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> expression)
    {
        var entities = await Repository.FindByConditionAsync(expression);
        return entities;
    }

    public virtual async Task CreateAsync(T entity) => await Repository.CreateAsync(entity);


    public virtual async Task UpdateAsync(T entity)
    {
        await Repository.UpdateAsync(entity);
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await Repository.FindByIdAsync(id);
        if (entity != null)
        {
            await Repository.DeleteAsync(entity);
        }
    }
}