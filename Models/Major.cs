
using lab1.models;
using Microsoft.Extensions.ObjectPool;

namespace lab1.models;

public class Major {

    // Var
    public int MajorID { get; set; }

    public string MajorName { get; set; }

    public virtual ICollection<Learner> Learners { get; set; }
    
    // Constructors 
    public Major() {
        Learners = new HashSet<Learner>();
    }
}