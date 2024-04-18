namespace testTask.Models;

public class EditCategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? ParentCategoryId { get; set; }
}