using Common.ApiResult;
using System.Net;

namespace Common.Exceptions;
public class AppException : Exception
{
    public ApiResultStatusCode ApiStatusCode { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public object AdditionalData { get; set; }

    #region Constructors

    public AppException() : this(ApiResultStatusCode.ServerError) { }

    public AppException(ApiResultStatusCode statusCode) : this(statusCode, null) { }

    public AppException(string message) : this(ApiResultStatusCode.ServerError, message)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message)
        : this(apiStatusCode, message, HttpStatusCode.InternalServerError)
    {

    }

    public AppException(string message, object additionalData)
        : this(ApiResultStatusCode.ServerError, message, additionalData)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, object additionalData)
        : this(apiStatusCode, null, additionalData)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, object additionalData)
        : this(apiStatusCode, message, HttpStatusCode.InternalServerError, additionalData)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, HttpStatusCode httpStatusCode)
        : this(apiStatusCode, message, httpStatusCode, null)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, HttpStatusCode httpStatusCode, object additionalData)
        : this(apiStatusCode, message, httpStatusCode, null, additionalData)
    {

    }

    public AppException(string message, Exception exception)
        : this(ApiResultStatusCode.ServerError, message, exception)
    {

    }

    public AppException(string message, Exception exception, object additionalData)
        : this(ApiResultStatusCode.ServerError, message, exception, additionalData)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, Exception exception)
        : this(apiStatusCode, message, HttpStatusCode.InternalServerError, exception)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, Exception exception, object additionalData)
        : this(apiStatusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, HttpStatusCode httpStatusCode, Exception exception)
        : this(apiStatusCode, message, httpStatusCode, exception, null)
    {

    }

    public AppException(ApiResultStatusCode apiStatusCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
        : base(message, exception)
    {
        ApiStatusCode = apiStatusCode;
        HttpStatusCode = httpStatusCode;
        AdditionalData = additionalData;
    }

    #endregion Constructors
}
