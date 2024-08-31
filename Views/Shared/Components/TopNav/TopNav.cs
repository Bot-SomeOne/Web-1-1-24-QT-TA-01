
using Microsoft.AspNetCore.Mvc;
using lab1.models;

namespace lab1.viewcomponents;

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
                Controller = "Home",
                Action = "Contact",
                Text = "Contacts"
            },
            new NavItem() {
                Controller = "Student",
                Action = "Index",
                Text = "List Students"
            }   
        };
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        return View("Default", listNavItems);
    }
}