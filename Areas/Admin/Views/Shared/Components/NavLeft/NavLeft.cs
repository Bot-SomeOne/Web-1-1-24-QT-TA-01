
using Microsoft.AspNetCore.Mvc;

// 
using lab1.models;
using lab1.data;

namespace lab1.areas.viewcomponents;

public class NavLeft : ViewComponent
{
    // Variables
    // private SchoolContext db;
    private List<NavItem> navItems;

    // Constructor
    public NavLeft()
    {
        // db = _context;
        navItems = new List<NavItem>(){
            new NavItem() {
                Area = "",
                Controller = "Home",
                Action = "Index",
                Text = "Back To User Dashboard"
            },
            new NavItem() {
                Area = "Admin",
                Controller = "Home",
                Action = "Index",
                Text = "Dashboard Admin"
            },
            new NavItem() {
                Area = "Admin",
                Controller = "Student",
                Action = "Index",
                Text = "Students"
            },
            new NavItem() {
                Area = "Admin",
                Controller = "Learner",
                Action = "Index",
                Text = "Learners"
            },
        };
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // return View("RenderMajor", majors);
        return View("RenderNavLeft", navItems);
    }
}