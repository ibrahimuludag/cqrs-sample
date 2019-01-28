using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;

        public CourseController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> List()
        {
            var list = await _context.Courses.ToListAsync();

            return Ok(_mapper.Map<IList<CourseListVm>>(list));
        }
    }
}
