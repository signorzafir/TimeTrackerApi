using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Constants;
using TimeTrackerAPI.Dto.Employee;
using TimeTrackerAPI.Models;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepo;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.mapper = mapper;
        }

        //View all Employees // Admin Only
        [HttpGet]
        [Authorize(Roles = ApiRoles.Administrator)]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await employeeRepo.GetAllAsync();
                var employeeDtos = mapper.Map<IEnumerable<EmployeeReadDto>>(employees);
                return Ok(employeeDtos);
            }
            catch (Exception)
            {

                return StatusCode(500, "An Error occured while fetching Employees.");
            }
        }

        //View own profile // User , Admin
        [HttpGet("{id}")]
        [Authorize(Roles = ApiRoles.UserAndAdmin)]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployeeById(int id)
        {
            try
            {

                var employee = await employeeRepo.GetByIdAsync(id);
                if (employee == null)
                    return NotFound();

                var dto = mapper.Map<EmployeeReadDto>(employee);
                return Ok(dto);
            }
            catch (Exception)
            {

                return StatusCode(500, "An Error occured while fetching the Employee.");

            }
        }

        // create new employees Admin Only
        [HttpPost]
        [Authorize(Roles = ApiRoles.Administrator)]
        public async Task<ActionResult<EmployeeReadDto>> CreateEmployee(EmployeeCreateDto dto)
        {
            try
            {
                var employee = mapper.Map<Employee>(dto);
                await employeeRepo.AddAsync(employee);
                await employeeRepo.SaveChangesAsync();

                var readDto = mapper.Map<EmployeeReadDto>(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, readDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An Error occured while Createing Employee.");

            }
        }

        //update an employee //Admin Only
        [HttpPut("{id}")]
        [Authorize(Roles = ApiRoles.UserAndAdmin)]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            try
            {
                var employee = await employeeRepo.GetByIdAsync(id);
                if (employee == null)
                    return NotFound();

                mapper.Map(dto, employee);
                employeeRepo.Update(employee);
                await employeeRepo.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(500, "An Error occured while updating the Employee.");
            }
        }

        // Admin deletes an employee
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.Administrator)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await employeeRepo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employeeRepo.Delete(employee);
            await employeeRepo.SaveChangesAsync();

            return NoContent();
        }

    }
}
