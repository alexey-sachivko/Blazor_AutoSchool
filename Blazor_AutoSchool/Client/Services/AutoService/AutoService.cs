namespace Blazor_AutoSchool.Client.Services.AutoService;

public class AutoService : IAutoService
{
    private readonly HttpClient _http;

    public AutoService(HttpClient http)
    {
        _http = http;
    }
    
    public List<Auto> Autos { get; set; }
    public string Message { get; set; } = "Loading autos...";
    
    public async Task GetAutos()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Auto>>>("api/Auto");
        Autos = result.Data;

        if (result == null || result.Data.Count == 0)
        {
            Message = "Autos not found.";
        }
    }

    public async Task<ServiceResponse<Auto>> GetAuto(int id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Auto>>($"api/Auto/{id}");

        return result;
    }
}