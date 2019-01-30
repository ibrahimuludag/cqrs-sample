using System.Threading.Tasks;
using CqrsSample.Data.Entities;
using CqrsSample.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CqrsSample.Data.Repository;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("enrollstudent")]
        public async Task<ActionResult> EnrollStudent(EnrollStudentVm enrollmentInfo)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentInfo);
            _unitOfWork.Enrollments.Add(enrollment);
            await _unitOfWork.CommitAsync();
            return Created("", _mapper.Map<EnrollmentDetailVm>(enrollment)); // TODO
        }
    }
}
