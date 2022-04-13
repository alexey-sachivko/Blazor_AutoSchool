using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Blazor_AutoSchool.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        var response = new ServiceResponse<string>();
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Username.ToLower().Equals(username.ToLower()));

        if (employee == null)
        {
            response.Success = false;
            response.Message = "Employee not found";
        }
        else if (!VerifyPasswordHash(password, employee.PasswordHash, employee.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        }
        else
        {
            response.Data = CreateToken(employee);
        }

        return response;
    }

    public async Task<ServiceResponse<int>> Register(Employee employee, string password)
    {
        if (await UserExists(employee.Username))
        {
            return new ServiceResponse<int>
            {
                Success = false, 
                Message = "Employee already exists."
            };
        }
        
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        employee.PasswordHash = passwordHash;
        employee.PasswordSalt = passwordSalt;

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return new ServiceResponse<int> {Data = employee.Id, Message = "Employee added successfully."};
    }

    public async Task<bool> UserExists(string username)
    {
        if (await _context.Employees.AnyAsync(user => user.Username.ToLower().Equals(username.ToLower())))
        {
            return true;
        }

        return false;
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA256())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA256(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(Employee employee)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new Claim(ClaimTypes.Name, employee.Username),
            new Claim(ClaimTypes.Role, employee.Role)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}