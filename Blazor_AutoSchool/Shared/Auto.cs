using System.Text.Json.Serialization;

namespace Blazor_AutoSchool.Shared;

public class Auto
{
    public int Id { get; set; }
    public string Brand { get; set; } = String.Empty;
    public string Model { get; set; } = String.Empty;
    public string RegistrationNumber { get; set; } = String.Empty;
    public string Color { get; set; } = String.Empty;
    public string YearOfManufacture { get; set; } = String.Empty;
    public string Status { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;

    public List<Student> Students { get; set; } = new List<Student>();
    
    public Employee? Employee { get; set; }
    public int? EmployeeId { get; set; }
}