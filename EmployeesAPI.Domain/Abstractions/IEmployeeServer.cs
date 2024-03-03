using EmployeesAPI.Domain.Models;
using System.Linq.Expressions;

namespace EmployeesAPI.Domain.Abstractions;

public interface IEmployeeServices
{
    Task<bool> AddEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string department, CancellationToken cancellationToken = default);
    Task<Employee?> GetEmployeeByAsync(Expression<Func<Employee, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
    Task<bool> DeleteEmployeeAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default);
}
