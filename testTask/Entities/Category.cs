using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testTask.Entities
{
    public class Category : IEntity, IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        
        public virtual ICollection<Category> Children { get; set; }

        public ICollection<Film> Films { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == ParentCategoryId)
            {
                yield return new ValidationResult("Category Id cannot be the same as ParentCategoryId",
                    new[] { nameof(Id), nameof(ParentCategoryId) });
            }
        }
        
        public int GetNestingLevel(testTask.Entities.Category category, int level = 0)
        {
            if (category.ParentCategoryId == null) return level;
            else return GetNestingLevel(category.ParentCategory, level + 1);
        }
    }
}