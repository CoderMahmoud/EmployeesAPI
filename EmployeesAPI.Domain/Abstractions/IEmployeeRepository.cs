using EmployeesAPI.Domain.Models;
using System.Linq.Expressions;

namespace EmployeesAPI.Domain.Abstractions;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    public Task<IEnumerable<Employee>> GetEmployeesByGenderAsync(string gender, CancellationToken cancellationToken = default);
    public Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string department, CancellationToken cancellationToken = default);
    public Task<Employee?> GetEmployeeByAsync(Expression<Func<Employee, bool>> predicate, CancellationToken cancellationToken = default);

}
