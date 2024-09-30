

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using lab1.data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class EnrollmentController : Controller
{
    // Var
    private SchoolContext _schoolContext;

    // Constructor
    public EnrollmentController(SchoolContext context)
    {
        _schoolContext = context;
    }

    // Actions

    /**
     * Medthod: Get
     * Description: Get list of Enrollment
     */
    public IActionResult Index() {
        var listEnrollments = _schoolContext.Enrollments
            .Include(e => e.Course)
            .Include(e => e.Learner)
            .ToList();
        return View(listEnrollments);
    }

    /**
     * Medthod: Get
     * Description: Create new Enrollment
     */
    public IActionResult Create() {
        // ViewBag.CourseID = new SelectList(_schoolContext.Courses, "CourseID", "CourseID");
        // ViewBag.LearnerID = new SelectList(_schoolContext.Learners, "LearnerID", "LearnerID");
        
        ViewBag.ListLearner = new List<SelectListItem>();

        foreach (var learner in _schoolContext.Learners.ToList()) {
            ViewBag.ListLearner.Add(
                new SelectListItem{
                    Value = learner.LearnerID.ToString(),
                    Text = learner.FirstMidName.ToString() + " " + learner.LastName.ToString()
                }
            );
        }

        ViewBag.ListCourse = new List<SelectListItem>();
        foreach (var course in _schoolContext.Courses.ToList()) {
            ViewBag.ListCourse.Add(
                new SelectListItem{
                    Value = course.CourseID.ToString(),
                    Text = course.Title.ToString()
                }
            );
        }

        return View();
    }

    /**
     * Medthod: Post
     * Description: Create new Enrollment
     */
    [HttpPost]
    public IActionResult Create(Enrollment enrollment) {
        if (!ModelState.IsValid) {
            return View();
        }
        _schoolContext.Enrollments.Add(enrollment);
        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }

    /**
     * Method: Get
     * Description: Get details of Enrollment
     */
    public IActionResult Details(int Id) {
        var enrollment = _schoolContext.Enrollments.FirstOrDefault(
            c => c.EnrollmentID == Id);

        ViewBag.CourseID = new SelectList(_schoolContext.Courses, "CourseID", "CourseID");
        ViewBag.LearnerID = new SelectList(_schoolContext.Learners, "LearnerID", "LearnerID");

        return View(enrollment);
    }

    /**
     * Method: Post
     * Description: Edit Enrollment Details with id
     */
    [HttpPost]
    public IActionResult Details(Enrollment enrollment) {
        if (!ModelState.IsValid) {
            return View("Details", enrollment);
        }
        
        var _enrollment = _schoolContext.Enrollments.FirstOrDefault(
            c => c.EnrollmentID == enrollment.EnrollmentID
        );

        _enrollment.CourseID = enrollment.CourseID;
        _enrollment.LearnerID = enrollment.LearnerID;
        _enrollment.Grade = enrollment.Grade;

        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }
    
    /**
     * Method: Post
     * Description: Delete a Enrollment
     */
    [HttpPost]
    public ActionResult Delete(int Id) {
        var enrollment = _schoolContext.Enrollments.FirstOrDefault(
            c => c.EnrollmentID == Id);
        _schoolContext.Enrollments.Remove(enrollment);
        _schoolContext.SaveChanges();
        return RedirectToAction("Index");
    }
}