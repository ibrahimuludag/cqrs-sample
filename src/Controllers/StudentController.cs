using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsSample.Data;
using CqrsSample.Data.Entities;
using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Attributes;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CqrsSample.Controllers
{
    [ApiController]
    [ValidateModel]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> List()
        {
            var list = (await _unitOfWork.Students.GetAllAsync()).Select(c => new StudentDetailListVm()
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                Id = c.Id,
                EnrolledCourseCount = 0 // TODO
            });

            return Ok(list);
        }

        [HttpPost]
        [Route("registerstudent")]
        public async Task<ActionResult> RegisterStudent(StudentRegistrationVm student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            _unitOfWork.Students.Add(studentEntity);

            await _unitOfWork.CommitAsync();

            return Created("", _mapper.Map<StudentDetailVm>(studentEntity)); // TODO
        }
    }
}
