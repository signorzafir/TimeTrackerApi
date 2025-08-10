using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TimeTrackerAPI.Data;

namespace TimeTrackerAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        public string? UserId {  get; set; }
        public virtual ApplicationUser User {  get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal HourlyWage { get; set; }
        [Required]
        public string PersonalNumber { get; set; }
        public string  PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public ICollection<WorkEntry> WorkEntries { get; set; }


    }
}
