
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models;

public class Course {

    // Var
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseID { get; set; }

    [Required(ErrorMessage = "Khong duoc de trong")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Khong duoc de trong")]
    [RegularExpression("^[1-9][0-9]*", ErrorMessage = " Vui long nhap so nguyen lon hon 0")]
    public int Credits { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    
    // Constructor
    public Course() {
        Enrollments = new HashSet<Enrollment>();
    }
}