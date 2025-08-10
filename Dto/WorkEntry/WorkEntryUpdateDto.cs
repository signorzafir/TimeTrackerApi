using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Dto.WorkEntry
{
    public class WorkEntryUpdateDto
    {
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        [Precision(18, 2)]
        public decimal WageForEntry { get; set; }
    }
}
