
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using lab1.data;

namespace lab1.controllers;

public class StudentController : Controller
{
    // Variables
    private SchoolContext _schoolContext;
    
    // Constructor
    public StudentController(SchoolContext context) 
    {
        _schoolContext = context;
    }

    // Actions

    // GET: Student
    public IActionResult Index()
    {
        List<Student> listStudent = _schoolContext.Students.ToList();
        return View(listStudent);
    }

    // GET: Create
    [HttpGet]
    public IActionResult Create()
    {
        // Lấy Enum Genders tạo thành list và gán vào ViewBag => Tạo radio button
        ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

        ViewBag.AllBranches = new List<SelectListItem>() {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" },
        };
        return View();
    }
}