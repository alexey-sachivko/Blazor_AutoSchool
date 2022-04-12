using System.ComponentModel.DataAnnotations;

namespace Blazor_AutoSchool.Shared;

public class Student
{
    public int Id { get; set; }
    public string Surname { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string ThirdName { get; set; } = String.Empty;
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; } = DateTime.Now;
    public string Address { get; set; } = String.Empty;
    public string Passport { get; set; } = String.Empty;
    public string Contact { get; set; } = String.Empty;
    public bool MedicalInfo { get; set; } = false;
    public int NumberOfHoursDriven { get; set; } = 0;
    public int NumberOfTestsPassed { get; set; } = 0;
    public bool TheoryExam { get; set; } = false;
    public bool DrivingExam { get; set; } = false;
    
    public Auto? Auto { get; set; }
    public int AutoId { get; set; }
    
    public Group? Group { get; set; }
    public int GroupId { get; set; }

    public List<Test> Tests { get; set; } = new List<Test>();
    public List<Driving> Drivings { get; set; } = new List<Driving>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
}