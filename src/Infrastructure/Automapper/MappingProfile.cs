using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            CreateMap<StudentRegistrationVm, Student>().ReverseMap();
            CreateMap<StudentDetailVm, Student>().ReverseMap();
            CreateMap<Course, CourseDetailListVm>().ReverseMap();
            CreateMap<EnrollStudentVm, Enrollment>().ReverseMap();
            CreateMap<EnrollmentDetailVm, Enrollment>().ReverseMap();
        }
    }
}
