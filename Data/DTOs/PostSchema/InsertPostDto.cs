using Common.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.PostSchema;
public class InsertPostDto
{
    [Display(Name = nameof(Title))]
    [MaxLength(100)]
    [Required]
    public string Title { get; set; }

    [Display(Name = nameof(Text))]
    [MaxLength(4000)]
    [Required]
    public string Text { get; set; }

    [Display(Name = nameof(Slug))]
    [MaxLength(100)]
    [Required]
    public string Slug { get; set; }

    [Required]
    [Display(Name = nameof(Picture))]
    [AllowedFileFormats(".jpg,.png,.jpeg")]
    public IFormFile Picture { get; set; }
}
