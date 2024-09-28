using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lab1.models;
namespace lab1.data;
public class SchoolContext : DbContext
{   
    // Variables
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Learner> Learners { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<Major> Majors { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    
    // Constructor
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    // Override
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Create the context instance for the model builder
        modelBuilder.Entity<Course>().ToTable(nameof(Course));
        modelBuilder.Entity<Learner>().ToTable(nameof(Learner));
        modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));
        modelBuilder.Entity<Major>().ToTable(nameof(Major));
        modelBuilder.Entity<Student>().ToTable(nameof(Student));

        // Auto generated primary key
        modelBuilder.Entity<Course>()
            .Property(e => e.CourseID)
            .ValueGeneratedOnAdd(); 

        modelBuilder.Entity<Learner>()
            .Property(e => e.LearnerID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Enrollment>()
            .Property(e => e.EnrollmentID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Major>()
            .Property(e => e.MajorID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}
