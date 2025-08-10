using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerAPI.Dto.User
{
    public class RegisterEmployeeDto
    {
        [EmailAddress] 
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal HourlyWage { get; set; }
        [Required]
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
    }
}
