
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

    // GET: Edit a Learner
    public IActionResult Edit(int id)
    {
        if (id == null || db.Learners == null)
            return NotFound();

        var learner = db.Learners.Find(id);

        if (learner == null)
            return NotFound();

        ViewBag.MajorID = GetViewBagMajorID();
        return View(learner);
    }

    // POST: Edit a Learner
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id,
        [Bind("LearnerID, FirstMidName, LastName, MajorID, EnrollmentDate")]
            Learner learner
    )
    {
        if (id != learner.LearnerID)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                db.Update(learner);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerExists(learner.LearnerID))
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.MajorId = GetViewBagMajorID();
        return View(learner);
    }

    /**
     * List Help funtion
     */

    // Help funtion Get ViewBag MajorID 
    private List<SelectListItem> GetViewBagMajorID()
    {
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

    // Help function to check if Learner exists
    private bool LearnerExists(int id)
    {
        return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
    }
}
