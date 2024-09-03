
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1.controllers;

public class StudentController : Controller
{
    // Variables
    private static List<Student> listStudent = new List<Student>(){
        new Student() {
                Id = 101,
                Name = "Hai Nam",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A1-2018",
                Email = "nam@gmail.com",
                Point = 5.5
            },
        new Student() {
            Id = 102,
            Name = "Minh Tu",
            Branch = Branch.BE,
            Gender = Gender.Female,
            IsRegular = true,
            Address = "A1-2019",
            Email = "tu@gmail.com",
            Point = 7.5
        },
        new Student() {
            Id = 103,
            Name = "Hoang Phong",
            Branch = Branch.CE,
            Gender = Gender.Male,
            IsRegular = false,
            Address = "A1-2020",
            Email = "phong@gmail.com",
            Point = 4
        },
        new Student() {
            Id = 104,
            Name = "Xuan Mai",
            Branch = Branch.EE,
            Gender = Gender.Female,
            IsRegular = false,
            Address = "A1-2021",
            Email = "mai@gmail.com",
            Point = 8.5
        },
        new Student() {
            Id = 105,
            Name = "Hai Yen",
            Branch = Branch.IT,
            Gender = Gender.Female,
            IsRegular = true,
            Address = "A1-2022",
            Email = "yenh@gmail.com",
            Point = 6.5
        }
    };

    // Constructor
    public StudentController()
    {
    }

    // Actions

    // GET: Student
    public IActionResult Index()
    {
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