using System.ComponentModel.DataAnnotations;

namespace CqrsSample.ViewModel
{
    public class StudentRegistrationDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
