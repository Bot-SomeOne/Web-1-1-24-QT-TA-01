
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
// 
using lab1.areas.identity.models.viewmodels;
using lab1.models;
using lab1.data;

namespace lab1.areas.identity.controllers;

[Area("Identity")]
public class AccountController: Controller {
    //Var
    private IdentityContext _context;
    // Constructor
    public AccountController(IdentityContext identityContext)
    {
        _context = identityContext;
    }

    /**
     * Get Register
     */
    public IActionResult Register() {
        return View();
    }

    /**
     * Post Register
     */
    [HttpPost]
    public async Task<IActionResult> Register(Register model) {
        if (ModelState.IsValid) {
            var user = new IdentityUserCustom {
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
    public IActionResult Login() {
        return View();
    }

    /**
     * Post Login
     */
    [HttpPost]
    public IActionResult Login(LoginViewModel loginViewModel) { 
        if (ModelState.IsValid) {
            // var passwordHash = BCrypt.Net.BCrypt.HashPassword(loginViewModel.Password);
            var passwordHash = loginViewModel.Password; // TODO - remove it
            var user = _context.Users.FirstOrDefault(u => u.UserName == loginViewModel.UserName && u.PasswordHash == passwordHash);
            if (user != null) {
                Console.WriteLine($"User {user.UserName} logged in");
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }
        return View();
    }

}   