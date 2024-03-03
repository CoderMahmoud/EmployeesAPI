using EmployeesAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesAPI.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(employee => employee.Salary)
                .HasPrecision(7, 3)
                .IsRequired();

        builder.Property(employee => employee.Department)
                .HasMaxLength(50)
                .IsRequired();

        builder.Property(employee => employee.HasHealthInsurance)
                .IsRequired();
    }
}
