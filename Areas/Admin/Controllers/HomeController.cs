using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab1.models;

namespace lab1.areas.admin.controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
