using Common.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.PostSchema;

public class UpdatePostDto
{
    [Display(Name = nameof(Title))]
    [MaxLength(100)]
    [Required]
    public string Title { get; set; }

    [Display(Name = nameof(Title))]
    [MaxLength(4000)]
    [Required]
    public string Text { get; set; }

    public string PictureName { get; set; }

    public bool IsDeleted { get; set; }

    [Display(Name = nameof(Picture))]
    [AllowedFileFormats(".jpg,.png,.jpeg")]
    public IFormFile Picture { get; set; }
}
