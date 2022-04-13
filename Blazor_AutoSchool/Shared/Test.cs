using System.Text.Json.Serialization;

namespace Blazor_AutoSchool.Shared;

public class Test
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public bool Result { get; set; } = false;
    
    [JsonIgnore]
    public Student? Student { get; set; }
    public int StudentId { get; set; }
    
    public Topic? Topic { get; set; }
    public int TopicId { get; set; }
}