namespace Blazor_AutoSchool.Client.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _http;

    public EmployeeService(HttpClient http)
    {
        _http = http;
    }

    public List<Employee> Employees { get; set; }
    public string Message { get; set; } = "Loading employees...";
    
    public async Task GetEmployees()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Employee>>>("api/Employee");
        Employees = result.Data;

        if (result == null || result.Data.Count == 0)
        {
            Message = "Employees not found.";
        }
    }

    public async Task<ServiceResponse<Employee>> GetEmployee(int id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Employee>>($"api/Employee/{id}");

        return result;
    }
}