namespace EmployeesAPI.Domain.Models;

public class Employee : Person
{
    public decimal Salary { set; get; }
    public string Department { set; get; } = string.Empty;
    public bool HasHealthInsurance { set; get; }
}
