
using lab1.models;
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

    // POST: Create
    [HttpPost]
    public IActionResult Create(Student student)
    {
        student.Id = listStudent.Max(s => s.Id) + 1;
        listStudent.Add(student);
        return View("Index", listStudent);
    }

    // GET: Details
    public IActionResult Details(int id)
    {
        Student student = listStudent.FirstOrDefault(s => s.Id == id);
        return View(student);
    }

    // POST: Upgrade data Students
    [HttpPost]
    public IActionResult Upgrade(Student student)
    {
        Student studentUpdate = listStudent.FirstOrDefault(s => s.Id == student.Id);
        studentUpdate.Name = student.Name;
        studentUpdate.Branch = student.Branch;
        studentUpdate.Gender = student.Gender;
        studentUpdate.IsRegular = student.IsRegular;
        studentUpdate.Address = student.Address;
        studentUpdate.Email = student.Email;

        return View("Details", studentUpdate);
    }


    // POST: Upload Avatar User
    [HttpPost]
    public async Task<ActionResult> UploadAvatar(IFormFile file, int id)
    {
        const int maxFileSize = 1024 * 1024; // 2MB

        Student student = listStudent.FirstOrDefault(s => s.Id == id);

        if (file == null)
        {
            ViewBag.MessageUpLoadAvatar = "Please Upload A Picture.";
            ViewBag.StatusUpdateAvatar = false;
            return View("Details", student);
        }

        ImageService imageService = new ImageService();
        byte[] imageData = await imageService.ToByteAsync(file);

        List<string> dotImage = new List<string>(){"png", "webp", "jpeg", "jpg", "heic"};
        
        string[] fileExtension = file.FileName.Split(".");
        string extension = fileExtension[fileExtension.Length - 1];

        if (imageData != null && dotImage.Contains(extension))
        {   
            if (imageData.Length <= maxFileSize) {
                student.Avatar = imageData;
                ViewBag.MessageUpLoadAvatar = "File Upload Successful.";
                ViewBag.StatusUpdateAvatar = true;
            } else {
                ViewBag.MessageUpLoadAvatar = "Please Upload A Picture Smaller Than 1 MB.";
                ViewBag.StatusUpdateAvatar = false;
            }
        }
        else
        {
            ViewBag.MessageUpLoadAvatar = "File Upload Failed, Please Upload A Picture.";
            ViewBag.StatusUpdateAvatar = false;
        }

        return View("Details", student);
    }
}