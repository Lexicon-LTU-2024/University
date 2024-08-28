using AutoMapper;
using University.API.Models.Dtos;
using University.API.Models.Entities;

namespace University.API.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentCreateDto>()
              //  .ForMember(dest => dest.Banan, opt => opt.MapFrom(src => src.Address.Street))
                .ReverseMap();

            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<Student, StudentDto>()
                .ConstructUsing(src => new StudentDto(src.Id, src.FullName, src.Avatar, src.Address.City));

            CreateMap<Course, CourseDto>()
                .ConstructUsing(src => new CourseDto(src.Title, src.Enrollment.First(e => e.CourseId == src.Id).Grade));

            CreateMap<Student, StudentDetailsDto>().ReverseMap();
                //.ForMember(dest => dest.Courses,
                //opt => opt.MapFrom(src => src.Enrollments.Select(e => new CourseDto(e.Course.Title, e.Grade))));
        }
    }
}
