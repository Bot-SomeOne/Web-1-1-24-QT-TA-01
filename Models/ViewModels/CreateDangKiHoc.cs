
using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models.viewmodels;

public class CreateDangKiHoc
{

    // Var
    public int LearnerID { get; set; }
    public List<int> CourseID { get; set; }
}