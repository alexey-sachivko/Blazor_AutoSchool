namespace Blazor_AutoSchool.Client.Services.GroupService;

public class GroupService : IGroupService
{
    private readonly HttpClient _http;

    public GroupService(HttpClient http)
    {
        _http = http;
    }
    
    public List<Group> Groups { get; set; } = new List<Group>();
    
    public string Message { get; set; } = "Loading groups...";
    
    public async Task GetGroups()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Group>>>("api/Group");
        Groups = result.Data;

        if (result == null || result.Data.Count == 0)
        {
            Message = "Groups not found.";
        }
    }

    public async Task<ServiceResponse<Group>> GetGroup(int id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Group>>($"api/Group/{id}");

        return result;
    }
}