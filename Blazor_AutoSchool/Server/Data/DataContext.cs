using Microsoft.EntityFrameworkCore;

namespace Blazor_AutoSchool.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Auto> Autos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Driving> Drivings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Topic> Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(e => e.Group)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Surname = "John",
                Name = " Joe",
                ThirdName = "Adam",
                Birthday = new DateTime(1982, 01, 10),
                Address = "1600 Pennsylvania Avenue NW, Washington, DC 20500",
                Role = "Admin",
                Passport = "31195855",
                Contact = "1-891-456-3476",
                Username = "admin",
                PasswordHash = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20},
                PasswordSalt = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20}
            }
        );

        modelBuilder.Entity<Auto>().HasData(
            new Auto
            {
                Id = 1,
                Brand = "BMW",
                Model = "3 Series",
                Color = "Black",
                RegistrationNumber = "3YU-89I",
                Type = "Passenger Car",
                YearOfManufacture = "2020",
                Status = "In action",
                EmployeeId = 1
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "A"
            },
            new Category{
                Id = 2,
                Name = "B"
            },
            new Category
            {
                Id = 3,
                Name = "C"
            }
        );

        modelBuilder.Entity<Group>().HasData(
            new Group
            {
                Id = 1,
                GroupNumber = 1,
                StartDate = new DateTime(2022, 01, 01),
                EndDate = new DateTime(2022, 04, 01),
                Description = "Example text.",
                EmployeeId = 1,
                CategoryId = 2
            }
        );
    }
}