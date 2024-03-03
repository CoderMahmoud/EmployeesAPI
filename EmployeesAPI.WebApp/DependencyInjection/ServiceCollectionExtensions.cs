using EmployeesAPI.Data.DbContexts;
using EmployeesAPI.Data.Repositories;
using EmployeesAPI.Domain.Abstractions;
using EmployeesAPI.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.WebApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupEmployeesAPIsDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var configurationBuilder = new ConfigurationBuilder()
                                          .AddJsonFile("appsettings.json")
                                          .Build();

                var connectionString = configurationBuilder.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString,
                    x =>
                    {
                        x.MigrationsAssembly("EmployeesAPI.Data");
                        x.UseDateOnlyTimeOnly();
                    });

            });
            //services.AddLogging();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeServices, EmployeeService>();

        }
    }
}
