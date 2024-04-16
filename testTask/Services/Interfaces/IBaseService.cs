using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace testTask.Services.Interfaces;

public interface IBaseService<T>
    where T : class
{
    Task<List<T>?> FindAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task DeleteAsync(int id);
}