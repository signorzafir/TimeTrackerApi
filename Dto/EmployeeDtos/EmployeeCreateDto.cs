using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerAPI.Dto.Employee
{
    public class EmployeeCreateDto
    {
        public string FullName { get; set; }
        public string UserId { get; set; }
        [Precision(18, 2)]
        public decimal HourlyWage { get; set; }
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
    }
}
