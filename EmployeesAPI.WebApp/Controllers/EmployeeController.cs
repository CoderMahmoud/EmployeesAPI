using EmployeesAPI.Domain.Abstractions;
using EmployeesAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.WebApp.Controllers;
[ApiController]
[Route("Api/[Controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeServices _services;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services)
    {
        _logger = logger;
        _services = services;
    }

    [HttpGet("getAllEmployees")]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _services.GetEmployeesAsync();

        if (employees is null)
        {
            return NotFound();
        }

        return Ok(employees);
    }

    [HttpGet("getEmployee/{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _services.GetEmployeeByIdAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        if (employee == null)
        {
            return BadRequest();
        }

        await _services.AddEmployeeAsync(employee);

        return CreatedAtAction(nameof(CreateEmployee), new { employee.Id }, employee);

    }

    [HttpPut("UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }

        var existingEmployee = await _services.GetEmployeeByIdAsync(id);

        if (existingEmployee is null)
            return NotFound();

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Gender = employee.Gender;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.HasHealthInsurance = employee.HasHealthInsurance;

        if (await _services.UpdateEmployeeAsync(existingEmployee))
            return NoContent();

        return BadRequest();
    }

    [HttpDelete("DeleteEmployee/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        if (await _services.DeleteEmployeeAsync(id))
            return NoContent();

        return NotFound();
    }
}
