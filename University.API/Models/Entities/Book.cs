namespace University.API.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int NrOfPages { get; set; }

        public ICollection<Course> UsedByCourses { get; set; }
    }
}
