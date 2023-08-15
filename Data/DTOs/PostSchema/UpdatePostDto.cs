using Common.Attributes;
using Core.PostSchema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.PostSchema;

public class UpdatePostDto
{
    [Display(Name = nameof(PostId))]
    [Required]
    public int PostId { get; set; }

    [Display(Name = nameof(Title))]
    [MaxLength(100)]
    [Required]
    public string Title { get; set; }

    [Display(Name = nameof(Text))]
    [MaxLength(4000)]
    [Required]
    public string Text { get; set; }

    public string PictureName { get; set; }

    public bool IsDeleted { get; set; }

    [Display(Name = nameof(Picture))]
    [AllowedFileFormats(".jpg,.png,.jpeg")]
    public IFormFile Picture { get; set; }


    public static implicit operator Post(UpdatePostDto dto)
    {
        return new Post()
        {
            PostId = dto.PostId,
            Title = dto.Title,
            Text = dto.Text,
            IsDeleted = dto.IsDeleted,
            PictureName = dto.PictureName,
        };
    }
}
