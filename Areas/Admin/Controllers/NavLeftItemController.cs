

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//
using lab1.models;
using lab1.models.viewmodels;
using lab1.services;
using lab1.data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class NavLeftItemController : Controller
{
    // Var
    private readonly lab1.data.ViewContext _context;

    // Constructor
    public NavLeftItemController(lab1.data.ViewContext context)
    {
        _context = context;
    }

    // Actions

    /**
     * Medthod: Get
     * Description: Get list of NavLeftDashboardAdmin
     */
    public IActionResult Index() {
        var listCourse = _context.NavLeftDashboardAdmin.ToList();
        return View(listCourse);
    }

    /**
     * Medthod: Get
     * Description: Create new NavLeftDashboardAdmin
     */
    public IActionResult Create() {
        return View();
    }

    /**
     * Medthod: Post
     * Description: Create new NavLeftDashboardAdmin
     */
    [HttpPost]
    public IActionResult Create(NavItem navItem) {
        if (!ModelState.IsValid) {
            return View();
        }
        // navItem.ID = _context.NavLeftDashboardAdmin.Max(c => c.ID) + 1;  
        _context.NavLeftDashboardAdmin.Add(navItem);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    /**
     * Method: Get
     * Description: Get details of NavLeftDashboardAdmin
     */
    public IActionResult Details(int Id) {
        var course = _context.NavLeftDashboardAdmin.FirstOrDefault(
            c => c.ID == Id
        );

        return View(course);
    }

    /**
     * Method: Post
     * Description: Edit NavLeftDashboardAdmin Details with id
     */
    [HttpPost]
    public IActionResult Details(NavItem navItem) {
        if (!ModelState.IsValid) {
            return View("Detail", navItem.ID);
        }
        
        var _nav = _context.NavLeftDashboardAdmin.FirstOrDefault(
            c => c.ID == navItem.ID
        );

        _nav.Area = navItem.Area;
        _nav.Controller = navItem.Controller;
        _nav.Action = navItem.Action;
        _nav.Text = navItem.Text;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    /**
     * Method: Post
     * Description: Delete a NavLeftDashboardAdmin
     */
    [HttpPost]
    public ActionResult Delete(int Id) {
        var nav = _context.NavLeftDashboardAdmin.FirstOrDefault(
            c => c.ID == Id
        );
        _context.NavLeftDashboardAdmin.Remove(nav);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}