using Entekhab.Common.Objects;

namespace Entekhab.Common.Extensions;

public static class ExceptionExtensions
{
    //********************************************************************************************************************
    /// <summary>
    /// توضیحات کامل در مورد خطای رخ داده
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static SysError GetError(this Exception ex)
    {
        var error = new SysError()
        {
            Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
            Source = ex.Source ?? string.Empty
        };

        return error;
    }
    //********************************************************************************************************************
}