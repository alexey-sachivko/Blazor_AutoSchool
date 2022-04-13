namespace Blazor_AutoSchool.Server.Services.AutoService;

public interface IAutoService
{
    Task<ServiceResponse<List<Auto>>> GetAutos();
    Task<ServiceResponse<Auto>> GetAuto(int autoId);
}