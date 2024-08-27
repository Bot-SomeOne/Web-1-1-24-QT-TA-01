using System.ComponentModel.DataAnnotations;

namespace lab1.models;

public class Student
{

    public int Id { get; set; }
    public string? Name { get; set; }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public Branch? Branch { get; set; }
    public Gender? Gender { get; set; }
    public bool IsRegular { get; set; } // Hệ: true - chính qui; false - phi chính qui
    public string? Address { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
    // public string? AvatarPath { get; set; }
    public byte[]? Avatar { get; set; }
}