namespace Blazor_AutoSchool.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<ServiceResponse<int>> Register(Employee employee, string password);
    Task<bool> UserExists(string username);
}