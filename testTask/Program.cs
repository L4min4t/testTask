using Microsoft.EntityFrameworkCore;
using testTask.Context;
using testTask.Entities;
using testTask.Repositories.Implementations;
using testTask.Repositories.Interfaces;
using testTask.Services.Implementations;
using testTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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
    pattern: "{controller=Film}/{action=Index}/{id?}");

app.Run();