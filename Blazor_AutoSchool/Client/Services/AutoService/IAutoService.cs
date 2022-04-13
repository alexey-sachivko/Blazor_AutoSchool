namespace Blazor_AutoSchool.Client.Services.AutoService;

public interface IAutoService
{
    List<Auto> Autos { get; set; }
    string Message { get; set; }
    Task GetAutos();
    Task<ServiceResponse<Auto>> GetAuto(int id);
}