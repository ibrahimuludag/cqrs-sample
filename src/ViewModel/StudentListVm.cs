using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsSample.ViewModel
{
    public class StudentListVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EnrolledCourseCount { get; set; }
    }
}
