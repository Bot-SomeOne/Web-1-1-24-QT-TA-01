
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//
using lab1.data;
using lab1.models;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class LearnerController : Controller
{
    // Variables
    private SchoolContext db;
    private int pageSize = 3;

    // Constructor
    public LearnerController(SchoolContext context)
    {
        db = context;
    }

    // GET: Learner
    public IActionResult Index(int? id)
    {
        var learners = db.Learners
            .Include(m => m.Major);

        if (id != null)
        {
            learners = db.Learners
                .Where(l => l.MajorID == id)
                .Include(m => m.Major);
        }

        int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
        ViewBag.pageNum = pageNum;
        ViewBag.pageIndexCurrent = 1;

        var result = learners.Take(pageSize).ToList();

        return View(result);
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

    // GET: Delete a Learner
    public IActionResult Delete(int id)
    {
        if (id == null || db.Learners == null)
            return NotFound();

        var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

        if (learner == null)
        {
            return NotFound();
        }

        if (learner.Enrollments.Count() > 0)
        {
            return Content("This learner has some enrollments, can't delete!");
        }

        return View(learner);
    }

    // POST: Delete a Learner
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (db.Learners == null)
        {
            return Problem("Entity set 'Learners' is null");
        }
        var learner = db.Learners.Find(id);
        if (learner != null)
        {
            db.Learners.Remove(learner);
        }
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // GET: Learner by MajorID - Help ajax
    public ActionResult LearnerByMajorID(int id)
    {
        var learners = db.Learners
           .Include(m => m.Major)
           .Where(m => m.MajorID == id)
           .ToList();

        return PartialView("LearnerTable", learners);
    }

    // GET: 
    public ActionResult LearnerFilter(int? id, string? keyword, int? pageIndex)
    {
        IQueryable<Learner> learners = db.Learners;
        int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);

        if (id != null)
        {
            learners = learners.Where(l => l.MajorID == id);
            ViewBag.MajorID = id;
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            learners = learners.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));
            ViewBag.keyword = keyword;
        }

        int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
        ViewBag.pageNum = pageNum;
        ViewBag.pageIndexCurrent = page;

        var result = learners.Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Include(m => m.Major)
            .ToList();

        return PartialView("LearnerTable", result);
    }

    /**
     * GET: Dang ki mon hoc
     */
    public IActionResult DangKiMonHoc(int id)
    {
        // Get Learner
        var Learner = db.Learners.Find(id);
        ViewBag.Learner = Learner;

        // Get the courses the learner has chosen
        var courseChoices = db.DangKiHocs
            .Where(l => l.LearnerID == id)
            .Include(c => c.Course)
            .ToList();

        // Store in ViewBag for use in the View
        ViewBag.CourseChoices = courseChoices;

        // Get all courses
        var courses = db.Courses.AsQueryable();

        // Get the courses the learner has NOT chosen
        var chosenCourseIds = courseChoices.Select(cc => cc.Course.CourseID).ToList();

        ViewBag.CourseDontChoice = courses
            .Where(c => !chosenCourseIds.Contains(c.CourseID))
            .ToList();

        return View();

    }

    /**
     * POST: Dang ki mon hoc
     */
    [HttpPost]
    public IActionResult DangKiMonHoc(List<int> CourseId, int learnerID)
    {
        foreach (var courseID in CourseId)
        {
            DangKiHoc dangKiHoc = new DangKiHoc
            {
                LearnerID = learnerID,
                CourseID = courseID
            };
            db.DangKiHocs.Add(dangKiHoc);
        }

        db.SaveChanges();

        return RedirectToAction(nameof(DangKiMonHoc));
    }

    /**
     * POST: Huy Dang Ki Mon Hoc
     */
    [HttpPost]
    public IActionResult HuyDangKiMonHoc(List<int> CourseId, int learnerID)
    {
        foreach (var courseID in CourseId)
        {
            DangKiHoc dangKiHoc = db.DangKiHocs.FirstOrDefault(d =>
                        d.LearnerID == learnerID && d.CourseID == courseID);
            if (dangKiHoc != null)
            {
                db.DangKiHocs.Remove(dangKiHoc);
            }
        }

        db.SaveChanges();

        return RedirectToAction(nameof(DangKiMonHoc), new { id = learnerID });
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
