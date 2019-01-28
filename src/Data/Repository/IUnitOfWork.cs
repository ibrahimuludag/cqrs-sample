using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Data.Repository
{
    public interface IUnitOfWork     {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Enrollment> Enrollments { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
