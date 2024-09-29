

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
public class MajorController : Controller
{
    // Var
    private SchoolContext _schoolContext;

    // Constructor
    public MajorController(SchoolContext context)
    {
        _schoolContext = context;
    }

    // Actions

    /**
     * Medthod: Get
     * Description: Get list of Major
     */
    public IActionResult Index() {
        var listMajors = _schoolContext.Majors.ToList();
        return View(listMajors);
    }

    /**
     * Medthod: Get
     * Description: Create new Major
     */
    public IActionResult Create() {
        return View();
    }

    /**
     * Medthod: Post
     * Description: Create new Major
     */
    [HttpPost]
    public IActionResult Create(Major major) {
        if (!ModelState.IsValid) {
            return View();
        }
        _schoolContext.Majors.Add(major);
        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }

    /**
     * Method: Get
     * Description: Get details of Major
     */
    public IActionResult Details(int Id) {
        var major = _schoolContext.Majors.FirstOrDefault(c => c.MajorID == Id);

        return View(major);
    }

    /**
     * Method: Post
     * Description: Edit Major Details with id
     */
    [HttpPost]
    public IActionResult Details(Major major) {
        if (!ModelState.IsValid) {
            return View("Details", major);
        }
        
        var _course = _schoolContext.Majors.FirstOrDefault(c => c.MajorID == major.MajorID);

        _course.MajorName = major.MajorName;

        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }
    
    /**
     * Method: Post
     * Description: Delete a Major
     */
    [HttpPost]
    public ActionResult Delete(int Id) {
        var major = _schoolContext.Majors.FirstOrDefault(
            c => c.MajorID == Id);
        _schoolContext.Majors.Remove(major);
        _schoolContext.SaveChanges();
        return RedirectToAction("Index");
    }
}