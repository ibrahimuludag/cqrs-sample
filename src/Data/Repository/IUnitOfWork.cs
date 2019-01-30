using System.Threading.Tasks;
using CqrsSample.Data.Entities;

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
