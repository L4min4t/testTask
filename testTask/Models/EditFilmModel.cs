namespace testTask.Models;

public class EditFilmModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Director { get; set; }
    public DateTime Release { get; set; }
    public List<int> FilmCategories { get; set; }
}