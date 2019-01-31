using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Attributes;
using CqrsSample.Infrastructure.Utils;
using CqrsSample.Logic.Queries;
using MediatR;

namespace CqrsSample.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ValidateModel]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class CourseController : RootContollerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var list = await _mediator.Send(new GetCourseListQuery()).ConfigureAwait(false);

            return Ok(list);
        }
    }
}
