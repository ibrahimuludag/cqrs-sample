using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CqrsSample.Data.Repository;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> List()
        {
            var list = await _unitOfWork.Courses.GetAllAsync();

            return Ok(_mapper.Map<IList<CourseDetailListVm>>(list));
        }
    }
}
