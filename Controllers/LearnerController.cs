
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//
using lab1.data;
using lab1.models;

namespace lab1.controllers;
public class LearnerController : Controller
{
    // Variables
    private SchoolContext db;

    // Constructor
    public LearnerController(SchoolContext context)
    {
        db = context;
    }
    public IActionResult Index()
    {
        var learners = db.Learners.Include(m => m.Major).ToList();
        return View(learners);
    }
}