
using lab1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1.Controllers;

public class StudentController : Controller {
    // Variables
    private List<Student> listStudent = new List<Student>();

    // Constructor
    public StudentController() {
        this.listStudent = new List<Student>(){
            new Student() {
                Id = 101,
                Name = "Hai Nam",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A1-2018",
                Email = "nam@gmail.com"
            },
            new Student() {
                Id = 102,
                Name = "Minh Tu",
                Branch = Branch.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A1-2019",
                Email = "tu@gmail.com"
            },
            new Student() {
                Id = 103,
                Name = "Hoang Phong",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "A1-2020",
                Email = "phong@gmail.com"
            },
            new Student() {
                Id = 104,
                Name = "Xuan Mai",
                Branch = Branch.EE,
                Gender = Gender.Female,
                IsRegular = false,
                Address = "A1-2021",
                Email = "mai@gmail.com"
            },
        };
    }

    // Actions

    // GET: Student
    public IActionResult Index() {
        return View(this.listStudent);
    }

    // GET: Create
    [HttpGet]
    public IActionResult Create() {
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

    // POST: Create
    [HttpPost]
    public IActionResult Create(Student student) {
        student.Id = this.listStudent.Count + 1;
        this.listStudent.Add(student);
        return View("Index", this.listStudent);
    }
}