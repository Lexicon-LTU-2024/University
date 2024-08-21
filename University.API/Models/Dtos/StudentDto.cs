using University.API.Models.Entities;

namespace University.API.Models.Dtos
{
    public record StudentDto(int Id, string FullName, string Avatar, string City);
}
