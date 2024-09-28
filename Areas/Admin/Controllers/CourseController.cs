

using System.Collections.Generic;
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
public class CourseController : Controller
{
    // Var
    private SchoolContext _schoolContext;

    // Constructor
    public CourseController(SchoolContext context)
    {
        _schoolContext = context;
    }

    // Actions

    /**
     * Medthod: Get
     * Description: Get list of Course
     */
    public IActionResult Index() {
        var listCourse = _schoolContext.Courses.ToList();
        return View(listCourse);
    }

    /**
     * Medthod: Get
     * Description: Create new Course
     */
    public IActionResult Create() {
        return View();
    }

    /**
     * Medthod: Post
     * Description: Create new Course
     */
    [HttpPost]
    public IActionResult Create(Course course) {
        if (!ModelState.IsValid) {
            return View();
        }
        course.CourseID = _schoolContext.Courses.Max(c => c.CourseID) + 1;  
        _schoolContext.Courses.Add(course);
        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }

    /**
     * Method: Get
     * Description: Get details of Course
     */
    public IActionResult Detail(int Id) {
        var course = _schoolContext.Courses.FirstOrDefault(c => c.CourseID == Id);

        return View(course);
    }

    /**
     * Method: Post
     * Description: Edit Course Details with id
     */
    [HttpPost]
    public IActionResult Detail(Course course) {
        if (!ModelState.IsValid) {
            return View("Detail", course.CourseID);
        }
        
        var _course = _schoolContext.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);

        _course.Title = course.Title;
        _course.Credits = course.Credits;

        _schoolContext.SaveChanges();

        return View("Index");
    }
    
    /**
     * Method: Post
     * Description: Delete a course
     */
    [HttpPost]
    public ActionResult Delete(int Id) {
        var course = _schoolContext.Courses.FirstOrDefault(
            c => c.CourseID == Id);
        _schoolContext.Courses.Remove(course);
        _schoolContext.SaveChanges();
        return RedirectToAction("Index");
    }
}