
using Microsoft.AspNetCore.Mvc;

// 
using lab1.models;
using lab1.data;

namespace lab1.areas.viewcomponents;

public class NavLeft : ViewComponent
{
    // Variables
    private ViewContext db;
    private List<NavItem> navItems;

    // Constructor
    public NavLeft(ViewContext _context)
    {
        db = _context;
        navItems = db.NavLeftDashboardAdmin.ToList();
    }
   

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // return View("RenderMajor", majors);
        return View("RenderNavLeft", navItems);
    }
}