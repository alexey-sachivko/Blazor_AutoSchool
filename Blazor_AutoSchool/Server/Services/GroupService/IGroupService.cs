namespace Blazor_AutoSchool.Server.Services.GroupService;

public interface IGroupService
{
    Task<ServiceResponse<List<Group>>> GetGroups();
    Task<ServiceResponse<Group>> GetGroup(int groupId);
}