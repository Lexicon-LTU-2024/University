using System.ComponentModel.DataAnnotations;
using University.API.Models.Entities;
using University.API.Validations;

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

    public record StudentCreateDto(
       // [StringLength(20)]
        string FirstName,
        [ValidateLastName]
        string LastName, 
        string Avatar,
        [StreetNrMaxValue(10)]
        string AddressStreet, 
        string AddressZipCode, 
        string AddressCity);

}
