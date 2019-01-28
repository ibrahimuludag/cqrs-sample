using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;

        public StudentController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            await _context.AddAsync(_mapper.Map<Student>(student));
            var registeredStudent = await _context.SaveChangesAsync();

            return Created("", registeredStudent); // TODO
        }
    }
}
