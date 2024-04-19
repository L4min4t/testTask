using testTask.Entities;

namespace testTask.Models;

public class ViewFilmModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Director { get; set; }
    public DateTime Release { get; set; }

    public ICollection<Category> Categories { get; set; }

    public string GetFormattedReleaseDate() => Release.Date.ToString("yyyy-MM-dd");

    public string GetStringOfCategoriesSeparatedByComma() => string.Join(", ", Categories.Select(c => c.Name));

    public string GetStringOfCategories()
    {
        string result = "";

        if (Categories != null)
        {
            foreach (var category in Categories)
            {
                result += "| " + category.Name + " ";
            }

            return result += "|";
        }
        else
        {
            return "there are no categories.";
        }
    }
}