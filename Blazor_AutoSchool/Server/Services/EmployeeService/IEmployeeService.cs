namespace Blazor_AutoSchool.Server.Services.EmployeeService;

public interface IEmployeeService
{
    Task<ServiceResponse<List<Employee>>> GetEmployees();
    Task<ServiceResponse<Employee>> GetEmployee(int employeeId);
}