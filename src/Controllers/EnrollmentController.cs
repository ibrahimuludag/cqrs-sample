using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("enrollstudent")]
        public async Task<ActionResult> EnrollStudent(EnrollmentStudentVm enrollmentInfo)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentInfo);
            await _context.AddAsync(enrollment);
            var registration = await _context.SaveChangesAsync();
            return Created("", registration); // TODO
        }
    }
}
