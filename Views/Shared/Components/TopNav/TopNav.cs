
using Microsoft.AspNetCore.Mvc;
using lab1.models;

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
                Action = "Privacy",
                Text = "Privacy"
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