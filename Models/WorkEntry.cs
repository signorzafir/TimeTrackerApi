using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerAPI.Models
{
    public class WorkEntry
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        //Navigation
        public Employee Employee { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal WageForEntry { get; set; }
    }
}
