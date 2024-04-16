using Microsoft.EntityFrameworkCore;
using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Implementations;
using testTask.Repositories.Interfaces;
using testTask.Services.Implementations;
using testTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBaseRepository<Film>, FilmRepository>();
builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IBaseRepository<FilmCategory>, FilmCategoryRepository>();

builder.Services.AddScoped<IBaseService<Film>, FilmService>();
builder.Services.AddScoped<IBaseService<Category>, CategoryService>();
builder.Services.AddScoped<IBaseService<FilmCategory>, FilmCategoryService>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();