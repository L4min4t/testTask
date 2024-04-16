using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace testTask.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<List<T>?> FindAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}