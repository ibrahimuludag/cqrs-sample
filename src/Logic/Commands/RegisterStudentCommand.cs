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
    public class RegisterStudentCommand : IRequest<Student>
    {
        private readonly StudentRegistrationDto _student;

        public RegisterStudentCommand(StudentRegistrationDto student)
        {
            _student = student;
        }

        internal class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, Student>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public RegisterStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Student> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<Student>(request._student);
                var studentEntity = _mapper.Map<Student>(student);
                _unitOfWork.Students.Add(studentEntity);

                await _unitOfWork.CommitAsync();
                return studentEntity;
            }
        }
    }
}
