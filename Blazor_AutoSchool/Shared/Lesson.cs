namespace Blazor_AutoSchool.Shared;

public class Lesson
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Student? Student { get; set; }
    public int StudentId { get; set; }

    public Topic? Topic { get; set; }
    public int TopicId { get; set; }
}