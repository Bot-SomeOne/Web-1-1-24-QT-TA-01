
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
// 
using lab1.areas.identity.models.viewmodels;
using lab1.models;
using lab1.data;

namespace lab1.areas.identity.controllers;

[Area("Identity")]
public class AccountController: Controller {
    // Var
    //Var
    private IdentityContext _context;
    // Constructor
    public AccountController(IdentityContext identityContext)
    {
        _context = identityContext;
    }

    /**
     * Get Login
     */
    [HttpGet]
    public IActionResult Login() {
        return View();
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
            return RedirectToAction("Index", "Home");
        }
        return View("Register");
    }

    /**
     * Post Login
     */


    /**
     * Post Logout
     */


    /**
     * Get Manage
     */

}   