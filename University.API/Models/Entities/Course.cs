using University.API.Controllers;

namespace University.API.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
