
using System.ComponentModel.DataAnnotations.Schema;
using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models;

public class Course {

    // Var
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    
    // Constructor
    public Course() {
        Enrollments = new HashSet<Enrollment>();
    }
}