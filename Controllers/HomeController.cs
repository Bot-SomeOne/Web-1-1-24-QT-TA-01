using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab1.models;

namespace lab1.controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        @ViewBag.GitHubUser = "Youknow2509"; 
        // @ViewBag.GitHubUser = "Bot-SomeOne"; 
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
