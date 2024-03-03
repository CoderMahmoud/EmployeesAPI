using EmployeesAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesAPI.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {

        builder.Property(person => person.Id)
               .ValueGeneratedOnAdd();

        builder.Property(person => person.FirstName)
                .HasMaxLength(50)
                .IsRequired();

        builder.Property(person => person.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Ignore(person => person.FullName);

        builder.Property(person => person.Gender)
                .HasMaxLength(30).IsRequired();

        builder.HasIndex(person => new { person.FirstName, person.LastName });

        builder.UseTpcMappingStrategy();
    }
}
