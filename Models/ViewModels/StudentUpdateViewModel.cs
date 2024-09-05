using System.ComponentModel.DataAnnotations;

namespace lab1.models.viewmodels;
public class StudentUpdateViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có ít nhất 4 ký tự")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email không hợp lệ - Phải có đuôi @gmail.com")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Branch không được để trống")]
    public Branch? Branch { get; set; }

    [Required(ErrorMessage = "Giới tính không được để trống")]
    public Gender? Gender { get; set; }

    public bool IsRegular { get; set; } // Hệ: true - chính qui; false - phi chính qui

    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    public string? Address { get; set; }

    [Range(0, 10, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
    [Required(ErrorMessage = "Điểm không được để trống")]
    public double? Point { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    public DateTime? DateOfBirth { get; set; }
}