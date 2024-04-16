﻿namespace testTask.Entities
{
    public class FilmCategory : IEntity
    {
        public int Id { get; set; }

        public int FilmId { get; set; }
        public int CategoryId { get; set; }

        public Film Film { get; set; }
        public Category Category { get; set; }
    }
}