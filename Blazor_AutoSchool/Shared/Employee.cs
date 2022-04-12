namespace Blazor_AutoSchool.Shared;

public class Employee
{
    public int Id { get; set; }
    public string Surname { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string ThirdName { get; set; } = String.Empty;
    public DateTime Birthday { get; set; } = DateTime.Now;
    public string Address { get; set; } = String.Empty;
    public string Role { get; set; } = "Admin";
    public string Passport { get; set; } = String.Empty;
    public string Contact { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Auto> Autos { get; set; } = new List<Auto>();
}