namespace Blazor_AutoSchool.Client.Services.EmployeeService;

public interface IEmployeeService
{
    List<Employee> Employees { get; set; }
    string Message { get; set; }
    Task GetEmployees();
    Task<ServiceResponse<Employee>> GetEmployee(int id);
}