
using System.ComponentModel.DataAnnotations.Schema;
using lab1.models;
using Microsoft.Extensions.ObjectPool;

public class Enrollment {

    // Var
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int LearnerID { get; set; }
    public float Grade { get; set; }
    public virtual Learner? Learner { get; set; }
    public virtual Course? Course { get; set; }

}