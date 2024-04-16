namespace testTask.Entities
{
    public class Film : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }

        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}