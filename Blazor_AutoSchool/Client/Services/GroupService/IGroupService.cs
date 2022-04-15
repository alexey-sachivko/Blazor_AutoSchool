namespace Blazor_AutoSchool.Client.Services.GroupService;

public interface IGroupService
{
    List<Group> Groups { get; set; }
    string Message { get; set; }
    Task GetGroups();
    Task<ServiceResponse<Group>> GetGroup(int id);
}