using Core.PostSchema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Xml.Linq;

namespace Core.UserSchema;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } 
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderType Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Post> Posts{ get; set; }
    public ICollection<Comment> Comments { get; set; }
}

public enum GenderType
{
    [Display(Name = "Male")]
    Male = 1,
    [Display(Name = "Female")]
    Female = 2
}