using System.ComponentModel.DataAnnotations;

namespace lab1.models;

public enum Gender {
    [Display(Name = "Nam")]
    Male = 1,

    [Display(Name = "Nữ")]
    Female = 2
}