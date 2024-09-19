using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//
using lab1.models;
using lab1.data;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class UserController : Controller
{
    //Var
    private IdentityContext _context;
    // Constructor
    public UserController(IdentityContext identityContext)
    {
        _context = identityContext;
    }

    public IActionResult Index()
    {
        List<IdentityUserCustom> users = _context.Users.ToList();
        return View(users);
    }
}
