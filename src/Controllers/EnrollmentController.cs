using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly StudentContext _context;
        public EnrollmentController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("enrollstudent")]
        public async Task<ActionResult> EnrollStudent(EnrollmentStudentVm registrationInfo)
        {
            var info = new Enrollment() {CourseId = registrationInfo.CourseId, StudentId = registrationInfo.StudentId};
            await _context.AddAsync(info);
            var registration = await _context.SaveChangesAsync();
            return Created("", registration); // TODO
        }
    }
}
