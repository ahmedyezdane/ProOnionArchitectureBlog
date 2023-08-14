using Common.Utilities;
using Core.UserSchema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.DTOs.UserSchema;

public class UpdateUserDto : IValidatableObject
{
    public int UserId { get; set; }   

    [Display(Name = nameof(UserName))]
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

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
        if (!BirthDate.IsValidDateString())
            yield return new ValidationResult("Invalid BirthDate; please enter a valid date with this format : yyyy-MM-dd", new[] { nameof(UserName) });
    }

    public static implicit operator User(UpdateUserDto user)
    {
        return new User
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender,
            BirthDate = user.BirthDate.DateStringToDateTime()
        };
    }
}
