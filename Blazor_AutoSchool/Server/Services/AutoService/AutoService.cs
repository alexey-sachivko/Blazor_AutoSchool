namespace Blazor_AutoSchool.Server.Services.AutoService;

public class AutoService : IAutoService
{
    private readonly DataContext _context;

    public AutoService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Auto>>> GetAutos()
    {
        var response = new ServiceResponse<List<Auto>>()
        {
            Data = await _context.Autos
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<Auto>> GetAuto(int autoId)
    {
        var response = new ServiceResponse<Auto>();
        var auto = await _context.Autos
            .Include(a => a.Students)
            .ThenInclude(s => s.Group)
            .FirstOrDefaultAsync(a => a.Id == autoId);

        if (auto == null)
        {
            response.Success = false;
            response.Message = "Auto not found.";
        }
        else
        {
            response.Data = auto;
        }

        return response;
    }
}