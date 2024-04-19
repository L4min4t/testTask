using System.ComponentModel.DataAnnotations;

namespace testTask.Models;

public class EditCategoryModel
{
    public int Id { get; set; }
    [MinLength(3)] [MaxLength(200)] public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}