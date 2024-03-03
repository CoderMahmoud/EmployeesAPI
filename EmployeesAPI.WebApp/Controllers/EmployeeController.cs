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
        return Ok(await _services.GetEmployeesAsync());
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



}
