namespace Blazor_AutoSchool.Server.Services.GroupService;

public class GroupService : IGroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Group>>> GetGroups()
    {
        var response = new ServiceResponse<List<Group>>
        {
            Data = await _context.Groups
                .Include(g => g.Employee)
                .Include(g => g.Students)
                .Include(g => g.Category)
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<Group>> GetGroup(int groupId)
    {
        var response = new ServiceResponse<Group>();
        var group = await _context.Groups
            .Include(g => g.Employee)
            .Include(g => g.Students)
            .Include(g => g.Category)
            .FirstOrDefaultAsync(g => g.Id == groupId);

        if (group == null)
        {
            response.Success = false;
            response.Message = "Group not found.";
        }
        else
        {
            response.Data = group;
        }

        return response;
    }
}