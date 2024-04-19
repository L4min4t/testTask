using System.ComponentModel.DataAnnotations;

namespace testTask.Models;

public class CreateCategoryModel
{
    [MinLength(3)] [MaxLength(200)] public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}