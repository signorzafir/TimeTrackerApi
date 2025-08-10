using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TimeTrackerAPI.Models;


namespace TimeTrackerAPI.Dto.WorkEntry
{
    public class WorkEntryReadDto
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int EmployeeId { get; set; }
        [Precision(18, 2)]
        public decimal WageForEntry { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

    }
}
