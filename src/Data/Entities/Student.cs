﻿using System.Collections.Generic;

namespace CqrsSample.Data.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
