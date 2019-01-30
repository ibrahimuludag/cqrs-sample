using System.ComponentModel.DataAnnotations;

namespace CqrsSample.ViewModel
{
    public class StudentRegistrationVm
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
