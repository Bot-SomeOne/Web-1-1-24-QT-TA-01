
using Microsoft.AspNetCore.Mvc;

namespace lab1.areas.identity.controllers;

[Area("Identity")]
public class AccountController: Controller {
    // Var

    // Constructor

    // Action

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

    // Test
    public IActionResult Index() {
        return View();
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