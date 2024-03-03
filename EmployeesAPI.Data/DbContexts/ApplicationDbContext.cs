using EmployeesAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

}
