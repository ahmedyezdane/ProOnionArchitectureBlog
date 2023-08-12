using Common.Utilities;
using Core.UserSchema;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.UserSchema;
public class RegisterUserDto : IValidatableObject
{
    [Display(Name = nameof(UserName))]
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    [Display(Name = nameof(Password))]
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    [Display(Name = nameof(ConfirmPassword))]
    [Required]
    [MaxLength(100)]
    [Compare(nameof(Password), ErrorMessage = "Password Should Match its repetition")]
    public string ConfirmPassword { get; set; }

    [Display(Name = nameof(Email))]
    [Required]
    [MaxLength(100)]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter a valid email")]
    public string Email { get; set; }

    [Display(Name = nameof(FirstName))]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Display(Name = nameof(LastName))]
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Display(Name = nameof(Gender))]
    [Required]
    public GenderType Gender { get; set; }

    [Display(Name = nameof(BirthDate))]
    [Required]
    public string BirthDate { get; set; }


    // for custom business logic validations
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(!BirthDate.IsValidDateString())
            yield return new ValidationResult("Invalid BirthDate; please enter a valid date with this format : yyyy-MM-dd", new[] { nameof(UserName) });
    }
}
