using EmployeesAPI.Domain.Abstractions;
using EmployeesAPI.Domain.Models;
using System.Linq.Expressions;

namespace EmployeesAPI.Service.Services;


public class EmployeeService : IEmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<bool> AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.AddAsync(employee, cancellationToken);
    }

    public async Task<bool> DeleteEmployeeAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<Employee?> GetEmployeeByAsync(Expression<Func<Employee, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetEmployeeByAsync(predicate, cancellationToken);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetAllAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string department, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetEmployeesByDepartmentAsync(department, cancellationToken);
    }

    public async Task<bool> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.UpdateAsync(employee, cancellationToken);
    }
}
