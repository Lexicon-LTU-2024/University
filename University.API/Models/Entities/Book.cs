namespace University.API.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int NrOfPages { get; set; }

        //Foreign key
        public int AuthorId { get; set; }


        //Navigationprop
        public Author Author { get; set; }
        public ICollection<Course> UsedByCourses { get; set; }
    }


    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Navigationprop
        public ICollection<Book> WrittenBooks { get; set; }
    }
}
