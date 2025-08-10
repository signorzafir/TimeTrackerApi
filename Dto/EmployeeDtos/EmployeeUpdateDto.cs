using Microsoft.EntityFrameworkCore;

namespace TimeTrackerAPI.Dto.Employee
{
    public class EmployeeUpdateDto
    {
        public string FullName { get; set; }
        [Precision(18, 2)]
        public decimal HourlyWage { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
    }
}
