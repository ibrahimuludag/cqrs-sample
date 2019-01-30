using System.Collections.Generic;

namespace CqrsSample.Data.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
