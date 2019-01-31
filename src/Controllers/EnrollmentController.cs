using System.Threading.Tasks;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Attributes;
using CqrsSample.Logic.Commands;
using CqrsSample.Logic.Queries;
using MediatR;

namespace CqrsSample.Controllers
{
    [ApiController]
    [ValidateModel]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EnrollmentController : RootContollerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EnrollmentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("enrollstudent")]
        public async Task<IActionResult> EnrollStudent(EnrollStudentDto enrollmentInfo)
        {
            var newEnrollment = await _mediator.Send(new EnrollStudentCommand (enrollmentInfo)).ConfigureAwait(false);

            return Created("", _mapper.Map<EnrollmentDetaiDto>(newEnrollment)); // TODO : Add Url
        }
    }
}
