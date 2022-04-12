namespace Blazor_AutoSchool.Server.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Employee>>> GetEmployees()
    {
        var response = new ServiceResponse<List<Employee>>()
        {
            Data = await _context.Employees
                .Include(e => e.Autos)
                .Include(e => e.Groups)
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<Employee>> GetEmployee(int employeeId)
    {
        var response = new ServiceResponse<Employee>();
        var employee = await _context.Employees
            .Include(e => e.Autos)
            .Include(e => e.Groups)
            .FirstOrDefaultAsync(e => e.Id == employeeId);

        if (employee == null)
        {
            response.Success = false;
            response.Message = "Employee not found";
        }
        else
        {
            response.Data = employee;
        }

        return response;
    }
}