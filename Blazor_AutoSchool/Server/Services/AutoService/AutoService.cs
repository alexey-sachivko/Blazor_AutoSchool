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

    public async Task<ServiceResponse<Auto>> CreateAuto(Auto auto)
    {
        _context.Autos.Add(auto);
        await _context.SaveChangesAsync();

        return new ServiceResponse<Auto>()
        {
            Data = auto
        };
    }

    public async Task<ServiceResponse<Auto>> UpdateAuto(Auto auto)
    {
        var dbAuto = await _context.Autos.FindAsync(auto.Id);
        if (dbAuto == null)
        {
            return new ServiceResponse<Auto>()
            {
                Success = false,
                Message = "Auto not found."
            };
        }

        dbAuto.Brand = auto.Brand;
        dbAuto.Model = auto.Model;
        dbAuto.Color = auto.Color;
        dbAuto.RegistrationNumber = auto.RegistrationNumber;
        dbAuto.YearOfManufacture = auto.YearOfManufacture;
        dbAuto.Type = auto.Type;
        dbAuto.Status = auto.Status;
        dbAuto.EmployeeId = auto.EmployeeId;

        await _context.SaveChangesAsync();

        return new ServiceResponse<Auto>()
        {
            Data = auto
        };
    }

    public async Task<ServiceResponse<bool>> DeleteAuto(int autoId)
    {
        var dbAuto = await _context.Autos.FindAsync(autoId);
        if (dbAuto == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Data = false,
                Message = "Auto not found."
            };
        }

        _context.Autos.Remove(dbAuto);
        await _context.SaveChangesAsync();
        
        return new ServiceResponse<bool> { Data = true };
    }
}