

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using lab1.data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class DangKiHocController : Controller
{
    // Var
    private SchoolContext _schoolContext;

    // Constructor
    public DangKiHocController(SchoolContext context)
    {
        _schoolContext = context;
    }

    // Actions

    /**
     *  GET: Admin/DangKiHoc
     *  Get list data of DangKiHoc
     */
    public IActionResult Index() {
        var dangkiHocs = _schoolContext.DangKiHocs
            .Include(e => e.Course)
            .Include(e => e.Learner)
            .ToList();

        return View(dangkiHocs);
    }

    /**
     *  GET: Admin/DangKiHoc/Create
     *  Create new DangKiHoc
     */
    public IActionResult Create() {
        ViewBag.ListLearner = new List<SelectListItem>();
        foreach (var learner in _schoolContext.Learners.ToList()) {
            ViewBag.ListLearner.Add(
                new SelectListItem{
                    Value = learner.LearnerID.ToString(),
                    Text = learner.FirstMidName.ToString() + " " + learner.LastName.ToString()
                }
            );
        }

        return View();
    }

    /**
     *  POST: Admin/DangKiHoc/Create
     *  Create new DangKiHoc
     */
    [HttpPost]
    public IActionResult Create(CreateDangKiHoc model) {
        if (ModelState.IsValid) {
            foreach(int idCourse in model.CourseID) {
                var dangkiHoc = new DangKiHoc {
                    LearnerID = model.LearnerID,
                    CourseID = idCourse
                };

                _schoolContext.DangKiHocs.Add(dangkiHoc);
            }
            _schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // string listCourseId = "";
        // foreach (int idCourse in model.CourseID) {
        //     listCourseId += idCourse + ", ";
        // }
        // System.Console.WriteLine(
        //     $"LearnerID: {model.LearnerID}, listIdCourse: {listCourseId}"
        // );

        ViewBag.ListLearner = new List<SelectListItem>();
        foreach (var learner in _schoolContext.Learners.ToList()) {
            ViewBag.ListLearner.Add(
                new SelectListItem{
                    Value = learner.LearnerID.ToString(),
                    Text = learner.FirstMidName.ToString() + " " + learner.LastName.ToString()
                }
            );
        }
        return View(model);
    }

    /**
     * DELETE: Admin/DangKiHoc/Delete/{id}
     * Delete DangKiHoc by id
     */
    public IActionResult Delete(int id) {
        var dangkiHoc = _schoolContext.DangKiHocs.Find(id);
        if (dangkiHoc == null) {
            return NotFound();
        }

        _schoolContext.DangKiHocs.Remove(dangkiHoc);
        _schoolContext.SaveChanges();

        return RedirectToAction("Index");
    }

    // API

    /**
     * GET: Admin/DangKiHoc/GetUnregisteredCourse/{id}
     * Get list course Unregistered by Learner
     */
    [HttpGet]
    public IActionResult GetUnregisteredCourse(int id) {
        var listCourse = _schoolContext.Courses.ToList();
        var listDangKiHoc = _schoolContext.DangKiHocs.Where(e => e.LearnerID == id).ToList();
        var res = new List<Course>();

        foreach (var course in listCourse) {
            if (listDangKiHoc.Find(e => e.CourseID == course.CourseID) == null) {
                res.Add(course);
            }
        }

        return Json(res);
    }
}