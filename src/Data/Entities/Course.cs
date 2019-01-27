using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CqrsSample.Data.Entities
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
