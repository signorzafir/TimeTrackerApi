using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeTrackerAPI.Constants;
using TimeTrackerAPI.Data;
using TimeTrackerAPI.Dto.User;
using TimeTrackerAPI.Models;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IEmployeeRepository employeeRepository;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmployeeRepository employeeRepository)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    FullName = userDto.FullName
                };
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded == false)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, ApiRoles.User);

                return Accepted(result);
            }
            catch (Exception)
            {

                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
            
        }

        [HttpPost]
        [Route("registerEmployee")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeDto dto)
        {
            //Check if Email Already Registered
            var existingUser = await userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return BadRequest("Email already in use");
            }
            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    FullName = dto.FullName,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                var employee = new Employee
                {
                    UserId = user.Id,
                    FullName = dto.FullName,
                    PersonalNumber = dto.PersonalNumber,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address,
                    EmergencyContact = dto.EmergencyContact,
                    HourlyWage = dto.HourlyWage,
                    User = user
                };
                await employeeRepository.AddAsync(employee);
                await employeeRepository.SaveChangesAsync();

                await userManager.AddToRoleAsync(user, ApiRoles.User);

                return StatusCode(201);

            }
            catch (Exception)
            {

                return Problem($"Something Went Wrong in {nameof(RegisterEmployee)}", statusCode: 500);
                ;
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginUserDto userDto)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userDto.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, userDto.Password);
                if (user == null || passwordValid == false) 
                {
                    return Unauthorized(userDto);
                }

                // Add Whatever is needed to create jwt
                string tokenString = await GenerateToken(user);
                var response = new AuthResponse()
                {
                    Email = userDto.Email,
                    Token = tokenString,
                    UserId = user.Id
                };

                return Ok(response);
            }
            catch (Exception)
            {

                return Problem($"Oops! Error in the {nameof(Register)}", statusCode: 500);
            }
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid , user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims)
            .ToList();

            Employee? userEmployee = await employeeRepository.GetByUserIdAsync(user.Id);

            if (userEmployee != null)
            {
                Claim employeeClaim = new(CustomClaimTypes.Rid, userEmployee.Id.ToString());
                claims.Add(employeeClaim);
            }

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
