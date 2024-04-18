namespace testTask.Models;

public class CreateCategoryModel
{
    public string Name { get; set; }

    public int? ParentCategoryId { get; set; }
}