namespace Blazor_AutoSchool.Server.Services.AutoService;

public interface IAutoService
{
    Task<ServiceResponse<List<Auto>>> GetAutos();
    Task<ServiceResponse<Auto>> GetAuto(int autoId);
    Task<ServiceResponse<Auto>> CreateAuto(Auto auto);
    Task<ServiceResponse<Auto>> UpdateAuto(Auto auto);
    Task<ServiceResponse<bool>> DeleteAuto(int autoId);
}