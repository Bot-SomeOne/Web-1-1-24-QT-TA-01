
using Microsoft.AspNetCore.Mvc;
using lab1.models;

namespace lab1.areas.identity.viewcomponents;

public class TopNav : ViewComponent
{
    // Variables
    private List<NavItem> listNavItems = new List<NavItem>();

    // Constructor
    public TopNav() {
        listNavItems = new List<NavItem>(){
            new NavItem() {
                Controller = "Home",
                Action = "Index",
                Text = "Home"
            },
            new NavItem() {
                Area = "Identity",
                Controller = "Account",
                Action = "Register",
                Text = "Register"
            },
        };
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        return View("Default", listNavItems);
    }
}