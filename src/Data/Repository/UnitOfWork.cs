using System;
using System.Threading.Tasks;
using CqrsSample.Data.Entities;

namespace CqrsSample.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;

        private readonly StudentContext _context;
        public UnitOfWork(StudentContext context)
        {
            _context = context;
        }

        IGenericRepository<Student> _studentRepository;
        public IGenericRepository<Student> Students => _studentRepository ?? (_studentRepository = new GenericRepository<Student>(_context));

        IGenericRepository<Course> _courseRepository;
        public IGenericRepository<Course> Courses => _courseRepository ?? (_courseRepository = new GenericRepository<Course>(_context));

        IGenericRepository<Enrollment> _enrollmentRepository;
        public IGenericRepository<Enrollment> Enrollments => _enrollmentRepository ?? (_enrollmentRepository = new GenericRepository<Enrollment>(_context));


        public int Commit()
        {
            return _context.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _context.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

    }
}
