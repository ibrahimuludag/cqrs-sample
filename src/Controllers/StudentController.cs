using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> List()
        {
            var list = await _context.Students.Select(c => new StudentListVm()
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                Id = c.Id,
                EnrolledCourseCount = 0 // TODO
            }).ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        [Route("registerstudent")]
        public async Task<ActionResult> RegisterStudent(StudentRegistrationVm student)
        {
            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            await _context.AddAsync(newStudent);
            var registeredStudent = await _context.SaveChangesAsync();

            return Created("", registeredStudent); // TODO
        }
    }
}
