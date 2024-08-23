using University.API.Models.Entities;

namespace University.API.Models.Dtos
{
    public record StudentDto(int Id, string FullName, string Avatar, string City);

    public record CourseDto(string Title, int Grade);
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string AddressCity { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }


    public class StudentCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
