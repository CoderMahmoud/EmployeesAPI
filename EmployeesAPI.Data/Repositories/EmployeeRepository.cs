using EmployeesAPI.Data.DbContexts;
using EmployeesAPI.Domain.Abstractions;
using EmployeesAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace EmployeesAPI.Data.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ILogger<EmployeeRepository> logger, ApplicationDbContext dbContext)
    : base(logger, dbContext) { }

    public async Task<Employee?> GetEmployeeByAsync(Expression<Func<Employee, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(predicate, cancellationToken);

    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string department, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees.Where(emp => emp.Department == department).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByGenderAsync(string gender, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees.Where(emp => emp.Gender == gender).ToListAsync(cancellationToken);
    }
}
