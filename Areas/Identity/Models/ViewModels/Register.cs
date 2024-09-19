using System.ComponentModel.DataAnnotations;

namespace lab1.areas.identity.models.viewmodels;
public class Register
{
    [Required(ErrorMessage = "Please enter user name")]
    [Display(Name = "User Name")]
    public string UserName;

    [Required(ErrorMessage = "Please enter a valid email address")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please repeat the password")]
    [DataType(DataType.Password)]
    [Display(Name = "Repeat Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string RepeatPassword { get; set; }
}