﻿using testTask.Entities;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Services.Implementations;

public class CategoryService : BaseService<Category>, ICategoryService
{
    public CategoryService(IBaseRepository<Category> repository) : base(repository)
    {
    }
}