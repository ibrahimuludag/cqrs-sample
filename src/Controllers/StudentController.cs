using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsSample.Data.Entities;
using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Attributes;
using CqrsSample.Logic.Commands;
using CqrsSample.Logic.Queries;
using CqrsSample.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Controllers
{
    [ApiController]
    [ValidateModel]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : RootContollerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StudentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var list = await _mediator.Send(new GetStudentListQuery()).ConfigureAwait(false);

            return Ok(list);
        }

        [HttpPost]
        [Route("registerstudent")]
        public async Task<IActionResult> RegisterStudent(StudentRegistrationDto student)
        {
            var newStudent = await _mediator.Send(new RegisterStudentCommand(student)).ConfigureAwait(false);

            return Created("", _mapper.Map<StudentDetailDto>(newStudent)); // TODO : Specify url
        }
    }
}
