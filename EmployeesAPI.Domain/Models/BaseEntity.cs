namespace EmployeesAPI.Domain.Models;

public class BaseEntity<TIdentity>
{
    public TIdentity Id { get; set; }
}
