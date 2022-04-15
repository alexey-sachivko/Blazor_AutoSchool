using System.Text.Json.Serialization;

namespace Blazor_AutoSchool.Shared;

public class Driving
{
    public int Id { get; set; }
    public DateTime DateTimeStart { get; set; } = DateTime.Now;
    public DateTime DateTimeEnd { get; set; } = DateTime.Now.AddHours(1);
    public string StartPoint { get; set; } = String.Empty;
    public string EndPoint { get; set; } = String.Empty;
    
    public Student Student { get; set; }
    public int StudentId { get; set; }
}