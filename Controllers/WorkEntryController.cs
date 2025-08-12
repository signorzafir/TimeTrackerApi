using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TimeTrackerAPI.Constants;
using TimeTrackerAPI.Dto.WorkEntry;
using TimeTrackerAPI.Models;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkEntryController : ControllerBase
    {
        private readonly IWorkEntryRepository workEntryRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public WorkEntryController(IWorkEntryRepository workEntryRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.workEntryRepository = workEntryRepository;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        // Get all entries for one employee 
        [HttpGet("GetWorkEntrybyEmployeeId/{employeeId}")]
        [Authorize(Roles = ApiRoles.UserAndAdmin)]
        public async Task<ActionResult<IEnumerable<WorkEntryReadDto>>> GetByEmployee(int employeeId)
        {
            try
            {
                // If User is regular User, make sure they are accessing their own entries
                if (User.IsInRole(ApiRoles.User))
                {
                    var userId = User.FindFirstValue(CustomClaimTypes.Uid);
                    var employee = await employeeRepository.GetByIdAsync(employeeId);
                    if (employee == null || employee.UserId != userId)
                        return Forbid();
                }

                var entries = await workEntryRepository.GetByEmployeeIdAsync(employeeId);
                var dto = mapper.Map<IEnumerable<WorkEntryReadDto>>(entries);
                return Ok(dto);

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retreiving Entries.");
            }
        }

        // Create new entry (Admin or User for self)
        [HttpPost]
        [Authorize(Roles = ApiRoles.UserAndAdmin)]
        public async Task<ActionResult<WorkEntryReadDto>> Create([FromBody] WorkEntryCreateDto dto)
        {
            try
            {
                // verify employee exists
                var employee = await employeeRepository.GetByIdAsync(dto.EmployeeId);
                if (employee == null)
                    return BadRequest("Employee does not exist");

                // If User, ensure they are accessing their own entries
                if (User.IsInRole(ApiRoles.User))
                {
                    var userId = User.FindFirstValue(CustomClaimTypes.Uid);
                    if (employee.UserId != userId)
                        return Forbid();
                }

                var entry = mapper.Map<WorkEntry>(dto);

                // Calculate wage for entry
                var totalHours = (decimal)dto.Duration.TotalHours;
                entry.WageForEntry = Math.Round(employee.HourlyWage * totalHours);

                await workEntryRepository.AddAsync(entry);
                await workEntryRepository.SaveChangesAsync();

                var readDto = mapper.Map<WorkEntryReadDto>(entry);
               // return CreatedAtAction(nameof(GetById), new { id = entry.Id }, readDto);
               return Ok(readDto);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while Creating entry.");

            }
        }

        // Get one Entry
        [HttpGet("{id}")]
        [Authorize(Roles = ApiRoles.UserAndAdmin)]
        public async Task<ActionResult<WorkEntryReadDto>> GetById(int id)
        {
            try
            {
                var entry = await workEntryRepository.GetByIdAsync(id);
                if (entry == null)
                    return NotFound();

                var dto = mapper.Map<WorkEntryReadDto>(entry);
                return Ok(dto);

            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retreiving Entry.");

            }
        }

        //updating an entry
        [HttpPut("{id}")]
        [Authorize(Roles = ApiRoles.Administrator)]
        public async Task<IActionResult> Update(int id, WorkEntryUpdateDto dto)
        {
            try
            {
                var entry = await workEntryRepository.GetByIdAsync(id);
                if (entry == null)
                    return NotFound();

                mapper.Map(dto, entry);
                await workEntryRepository.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while Updatin Entry.");
            }
        }

        // Delete
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.Administrator)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entry = await workEntryRepository.GetByIdAsync(id);
                if (entry == null)
                    return NotFound();

                workEntryRepository.Delete(entry);
                await workEntryRepository.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting Entry.");
            }
        }
    }
}
