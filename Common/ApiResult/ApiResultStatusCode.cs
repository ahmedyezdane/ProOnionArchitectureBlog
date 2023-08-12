using System.ComponentModel.DataAnnotations;
namespace Common.ApiResult;

public enum ApiResultStatusCode
{
    [Display(Name = "Task Done Successfully !")]
    Success = 0,

    [Display(Name = "Internal Server Error !")]
    ServerError = 1,

    [Display(Name = "Input Parameters Are Invalid !")]
    BadRequest = 2,

    [Display(Name = "Not Found !")]
    NotFound = 3,

    [Display(Name = "List Is Empty !")]
    ListEmpty = 4,

    [Display(Name = "An Error Has Occurred In Process !")]
    LogicError = 5,

    [Display(Name = "Authentication Error !")]
    UnAuthorized = 6

}
