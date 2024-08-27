using AutoMapper;
using University.API.Models.Dtos;
using University.API.Models.Entities;

namespace University.API.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentCreateDto>().ReverseMap();

            CreateMap<Student, StudentDto>()
                .ConstructUsing(src => new StudentDto(src.Id, src.FullName, src.Avatar, src.Address.City));
        }
    }
}
