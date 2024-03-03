namespace EmployeesAPI.Domain.Models;

public abstract class Person : BaseEntity<int>
{
    public string FirstName { set; get; } = string.Empty;
    public string LastName { set; get; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Gender { set; get; } = string.Empty;
}
