using System.ComponentModel.DataAnnotations;

namespace lab1.models;

public class Student
{

    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    public string? Password { get; set; }

    [Required]
    public Branch? Branch { get; set; }
    public Gender? Gender { get; set; }
    public bool IsRegular { get; set; } // Hệ: true - chính qui; false - phi chính qui
    
    [Required]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime? DateOfBirth { get; set; }
    // public string? AvatarPath { get; set; }
    
    public byte[]? Avatar { get; set; }
}