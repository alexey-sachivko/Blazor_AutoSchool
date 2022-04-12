using System.ComponentModel.DataAnnotations;

namespace Blazor_AutoSchool.Shared;

public class Group
{
    public int Id { get; set; }
    public int GroupNumber { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(3);
    public string? Description { get; set; }
    
    public Employee? Employee { get; set; }
    public int EmployeeId { get; set; }

    public List<Schedule> Schedule { get; set; } = new List<Schedule>();
}