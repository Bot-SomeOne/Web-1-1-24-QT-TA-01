
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//
using lab1.data;
using lab1.models;

namespace lab1.controllers;
public class LearnerController : Controller
{
    // Variables
    private SchoolContext db;

    // Constructor
    public LearnerController(SchoolContext context)
    {
        db = context;
    }

    // GET: Learner
    public IActionResult Index()
    {
        var learners = db.Learners.Include(m => m.Major).ToList();
        return View(learners);
    }

    // GET: Create a new Learner
    public IActionResult Create()
    {
        ViewBag.MajorID = GetViewBagMajorID();
        return View();
    }

    // POST: Create a new Learner
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("FirstMidName, LastName ,MajorID, EnrollmentDate")]
            Learner learner
    )
    {
        if (ModelState.IsValid)
        {
            db.Learners.Add(learner);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // Else return to the form 
        ViewBag.MajorID = GetViewBagMajorID();
        return View();
    }

    /**
     * List Help funtion
     */

    // Help funtion Get ViewBag MajorID 
    private List<SelectListItem> GetViewBagMajorID() {
        var majors = new List<SelectListItem>(); 

        foreach (var item in db.Majors)
        {
            majors.Add(
                new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                }
            );
        }

        return majors; 
    }
    
}