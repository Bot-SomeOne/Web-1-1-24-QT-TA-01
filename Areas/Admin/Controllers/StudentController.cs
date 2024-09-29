

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using lab1.data;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class StudentController : Controller
{
    // Var
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
        return View(_schoolContext.Students);
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
        if (ModelState.IsValid)
        {
            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

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

    // GET: Details
    public IActionResult Details(int id)
    {
        Student? student = _schoolContext.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: Upgrade data Students
    [HttpPost]
    public IActionResult Upgrade(StudentUpdateViewModel student)
    {
        Student? studentUpdate = _schoolContext.Students.FirstOrDefault(s => s.Id == student.Id);
        
        if (studentUpdate == null)
        {
            return NotFound();
        }
        
        if (ModelState.IsValid)
        {
            studentUpdate.Name = student.Name;
            studentUpdate.Branch = student.Branch;
            studentUpdate.Gender = student.Gender;
            studentUpdate.IsRegular = student.IsRegular;
            studentUpdate.Address = student.Address;
            studentUpdate.Email = student.Email;
            studentUpdate.Point = student.Point;
            studentUpdate.DateOfBirth = student.DateOfBirth;
            _schoolContext.SaveChanges();
            return RedirectToAction("Index");
        } 
        return View("Details", studentUpdate);
    }

    // POST: Delete Student
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Student? student = _schoolContext.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        _schoolContext.Students.Remove(student);
        _schoolContext.SaveChanges();
        return RedirectToAction("Index");
    }

    // POST: Upload Avatar User
    [HttpPost]
    public async Task<ActionResult> UploadAvatar(IFormFile file, int id)
    {
        const int maxFileSize = 1024 * 1024; // 2MB

        Student? student = _schoolContext.Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        if (file == null)
        {
            ViewBag.MessageUpLoadAvatar = "Please Upload A Picture.";
            ViewBag.StatusUpdateAvatar = false;
            return View("Details", student);
        }

        ImageService imageService = new ImageService();
        byte[] imageData = await imageService.ToByteAsync(file);

        List<string> dotImage = new List<string>() { "png", "webp", "jpeg", "jpg", "heic" };

        string[] fileExtension = file.FileName.Split(".");
        string extension = fileExtension[fileExtension.Length - 1];

        if (imageData != null && dotImage.Contains(extension))
        {
            if (imageData.Length <= maxFileSize)
            {
                student.Avatar = imageData;
                ViewBag.MessageUpLoadAvatar = "File Upload Successful.";
                ViewBag.StatusUpdateAvatar = true;
                _schoolContext.SaveChanges();
            }
            else
            {
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