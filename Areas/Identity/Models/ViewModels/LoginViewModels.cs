using System.ComponentModel.DataAnnotations;

namespace lab1.areas.identity.models.viewmodels;
public class LoginViewModel 
{
    [Required(ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}