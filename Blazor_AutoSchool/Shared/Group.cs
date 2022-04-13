using System.Text.Json.Serialization;

namespace Blazor_AutoSchool.Shared;

public class Group
{
    public int Id { get; set; }
    public int GroupNumber { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now.Date;
    public DateTime EndDate { get; set; } = DateTime.Now.Date.AddMonths(3);
    public string? Description { get; set; }
    
    [JsonIgnore]
    public Employee? Employee { get; set; }
    public int EmployeeId { get; set; }
    
    public Category? Category { get; set; }
    public int CategoryId { get; set; }

    public List<Schedule> Schedule { get; set; } = new List<Schedule>();
}