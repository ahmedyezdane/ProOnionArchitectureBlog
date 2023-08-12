using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Common.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class AllowedFileFormatsAttribute : ValidationAttribute
{
    private readonly IList<string> _allowedFileFormats;

    public AllowedFileFormatsAttribute(string allowedFileFormats)
    {
        _allowedFileFormats = allowedFileFormats.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public override bool IsValid(object value)
    {
        var file = value as IFormFile;
        if (file != null)
            return isValidFile(file);

        var files = value as IList<IFormFile>;

        if (files != null && files.Count() > 0)
        {
            foreach (var postedFile in files)
            {
                if (!isValidFile(postedFile))
                    return false;
            }
        }

        return true;
    }

    private bool isValidFile(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.FileName);

        var result = !string.IsNullOrWhiteSpace(fileExtension) &&
                     _allowedFileFormats.Any(ext => fileExtension.Equals(ext, StringComparison.OrdinalIgnoreCase));

        return result;
    }
}
