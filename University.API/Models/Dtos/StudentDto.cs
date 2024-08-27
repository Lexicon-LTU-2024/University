using University.API.Models.Entities;

namespace University.API.Models.Dtos
{
    public record StudentDto(int Id, string FullName, string Avatar, string AddressCity);

    public record CourseDto(string Title, int Grade);
    
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string AddressCity { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }

    public record StudentCreateDto(string FirstName, string LastName, string Avatar, string AddressStreet, string AddressZipCode, string AddressCity);

}
