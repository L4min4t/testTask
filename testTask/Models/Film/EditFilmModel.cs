using System.ComponentModel.DataAnnotations;

namespace testTask.Models;

public class EditFilmModel
{
    public int Id { get; set; }
    [MinLength(3)] [MaxLength(200)] public string Name { get; set; }
    [MinLength(3)] [MaxLength(200)] public string Director { get; set; }
    public DateTime Release { get; set; }
    public List<int> FilmCategories { get; set; }
}