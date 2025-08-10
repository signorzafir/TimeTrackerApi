using System.ComponentModel.DataAnnotations;

namespace TimeTrackerAPI.Dto.User
{
    public class UserDto : LoginUserDto
    {
        
        [Required]
        public string FullName { get; set; }
    }
}