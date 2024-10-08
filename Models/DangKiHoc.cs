
using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models;

public class DangKiHoc
{

    // Var
    public int Id { get; set; }
    public int LearnerID { get; set; }
    public int CourseID { get; set; }
    public virtual Course Course { get; set; }
    public virtual Learner Learner { get; set; }
}