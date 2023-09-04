using Entekhab.Common.Extensions;
using Entekhab.Common.Objects;

namespace Entekhab.Common.Functions;

public class Result
{
    //********************************************************************************************************************
    public static SysResult Success(string message, object? value = null) => new()
        {
            Successed = true,
            Message = message,
            Value = value
        };
    //********************************************************************************************************************
    public static SysResult Error(string message, object? value = null) => new()
        {
            Successed = false,
            Message = message,
            Value = value
        };
    //********************************************************************************************************************
    public static SysResult ErrorOfException(Exception e) => new()
        {
            Successed = false,
            Message = "سیستم با خطا مواجه شد",
            Errors = new List<SysError> { e.GetError() }
        };
    //********************************************************************************************************************
}