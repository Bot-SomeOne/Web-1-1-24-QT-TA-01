
using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models;

public class Learner {

    // Var
    public int LearnerID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int MajorID { get; set; }
    public virtual Major? Major { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<DangKiHoc> DangKiHocs { get; set; }
    
    // Constructor
    public Learner() {
        Enrollments = new HashSet<Enrollment>();
    }
}