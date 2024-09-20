
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
// 
using lab1.areas.identity.models.viewmodels;
using lab1.models;
using lab1.data;
using lab1.helpers;

namespace lab1.areas.identity.controllers;

[Area("Identity")]
public class AccountController : Controller
{
    //Var
    private readonly IdentityContext _context;
    private readonly JwtHelper _jwtHelper;
    // Constructor
    public AccountController(IdentityContext identityContext, JwtHelper jwtHelper)
    {
        _context = identityContext;
        _jwtHelper = jwtHelper;
    }

    /**
     * Get Register
     */
    public IActionResult Register()
    {
        return View();
    }

    /**
     * Post Register
     */
    [HttpPost]
    public async Task<IActionResult> Register(Register model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUserCustom
            {
                UserName = model.Email,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password) // Hash Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }
        return View("Register");
    }

    /**
     * Get Login
     */
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    /**
     * Post Login
     */
    [HttpPost]
    public IActionResult Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            // var passwordHash = BCrypt.Net.BCrypt.HashPassword(loginViewModel.Password);
            var passwordHash = loginViewModel.Password; // TODO - remove it
            var user = _context.Users.FirstOrDefault(u => u.UserName == loginViewModel.UserName && u.PasswordHash == passwordHash);
            if (user != null)
            {
                var token = _jwtHelper.GenerateJwtToken(loginViewModel.UserName);
                // Set the token in cookies (or any other storage like session)
                Response.Cookies.Append("jwtToken", token);

                return Redirect("Index");
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }
        return View();
    }

}