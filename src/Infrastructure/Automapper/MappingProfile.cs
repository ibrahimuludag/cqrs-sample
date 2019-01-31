using AutoMapper;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;

namespace CqrsSample.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<StudentRegistrationDto, Student>().ReverseMap();
            CreateMap<StudentDetailDto, Student>().ReverseMap();
            CreateMap<Course, CourseDetailListDto>().ReverseMap();
            CreateMap<EnrollStudentDto, Enrollment>().ReverseMap();
            CreateMap<EnrollmentDetaiDto, Enrollment>().ReverseMap();
        }
    }
}
