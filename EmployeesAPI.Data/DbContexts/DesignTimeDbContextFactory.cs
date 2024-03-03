using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeesAPI.Data.DbContexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        var connectionString = "Data Source=.;Database =EmpAPIs;Integrated Security=SSPI;Trust Server Certificate=True";

        optionBuilder.UseSqlServer(connectionString, x =>
        {
            x.MigrationsAssembly("EmployeesAPI.Data");
        });

        return new ApplicationDbContext(optionBuilder.Options);
    }
}
