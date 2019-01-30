﻿namespace CqrsSample.Data.Entities
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
