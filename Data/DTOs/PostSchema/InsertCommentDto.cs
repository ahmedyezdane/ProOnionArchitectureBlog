using Core.PostSchema;
using Core.UserSchema;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.PostSchema;

public class InsertCommentDto
{
    [Required]
    [Display(Name = nameof(Text))]
    [MaxLength(4000)]
    public string Text { get; set; }

    [Required]
    public int PostId { get; set; }
}
