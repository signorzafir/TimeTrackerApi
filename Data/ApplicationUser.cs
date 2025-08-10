using Microsoft.AspNetCore.Identity;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public Employee? Employee { get; set; }
    }
}
