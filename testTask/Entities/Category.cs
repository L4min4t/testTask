﻿namespace testTask.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}