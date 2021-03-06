namespace Blazor_AutoSchool.Shared;

public class Schedule
{
    public int Id { get; set; }
    public DateTime Time { get; set; } = DateTime.Now;
    public DayOfWeek DayOfWeek { get; set; } = DayOfWeek.Monday;
    
    public Group Group { get; set; }
    public int GroupId { get; set; }
}