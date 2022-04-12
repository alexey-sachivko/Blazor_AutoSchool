namespace Blazor_AutoSchool.Shared;

public class Topic
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public Category? Category { get; set; }
    public int CategoryId { get; set; }

    public List<Test> Tests { get; set; } = new List<Test>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
}