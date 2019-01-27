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
    public class CourseController : ControllerBase
    {
        private readonly StudentContext _context;
        public CourseController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("list")]
        public ActionResult List()
        {
            var list = _context.Courses.Select(c => new CourseListVm
            {
                Name = c.CourseName,
                Id = c.Id
            });

            return Ok(list);
        }
    }
}
