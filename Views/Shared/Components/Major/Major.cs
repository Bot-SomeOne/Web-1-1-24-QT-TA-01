
using Microsoft.AspNetCore.Mvc;

// 
using lab1.models;
using lab1.data;

namespace lab1.viewcomponents;

public class Major : ViewComponent
{
    // Variables
    private SchoolContext db;
    List<lab1.models.Major> majors;

    // Constructor
    public Major(SchoolContext _context)
    {
        db = _context;
        majors = db.Majors.ToList();
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // return View("RenderMajor", majors);
        return View("RenderDropMajor", majors);
    }
}