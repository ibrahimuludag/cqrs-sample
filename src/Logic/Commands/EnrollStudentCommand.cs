using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CqrsSample.Data.Entities;
using CqrsSample.Data.Repository;
using CqrsSample.ViewModel;
using MediatR;

namespace CqrsSample.Logic.Commands
{
    public class EnrollStudentCommand : IRequest<Enrollment>
    {
        private readonly EnrollStudentDto _enrollmentInfo;

        public EnrollStudentCommand(EnrollStudentDto enrollmentInfo)
        {
            _enrollmentInfo = enrollmentInfo;
        }

        internal class EnrollStudentCommandHandler : IRequestHandler<EnrollStudentCommand, Enrollment>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public EnrollStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Enrollment> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
            {
                var enrollment = _mapper.Map<Enrollment>(request._enrollmentInfo);
                _unitOfWork.Enrollments.Add(enrollment);
                await _unitOfWork.CommitAsync();
                return enrollment;
            }
        }
    }
}
