using System.ComponentModel.DataAnnotations;

namespace testTask.Models;

public class CreateFilmModel
{
    [MaxLength(200)]
    [MinLength(3)]
    public string Name { get; set; }
    [MaxLength(200)]
    [MinLength(3)]
    public string Director { get; set; }
    public DateTime Release { get; set; }
    public List<int> FilmCategories { get; set; }
}