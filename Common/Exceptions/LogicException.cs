using Common.ApiResult;

namespace Common.Exceptions;
public class LogicError : AppException
{
    public LogicError() : base(ApiResultStatusCode.LogicError)
    {

    }

    public LogicError(string message) : base(ApiResultStatusCode.LogicError, message)
    {
    }

    public LogicError(object additionalData) : base(ApiResultStatusCode.LogicError, additionalData)
    {
    }

    public LogicError(string message, object additionalData)
        : base(ApiResultStatusCode.LogicError, message, additionalData)
    {
    }

    public LogicError(string message, Exception exception)
        : base(ApiResultStatusCode.LogicError, message, exception)
    {
    }

    public LogicError(string message, Exception exception, object additionalData)
        : base(ApiResultStatusCode.LogicError, message, exception, additionalData)
    {
    }
}
