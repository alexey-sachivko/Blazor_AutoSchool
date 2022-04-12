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
    }
}