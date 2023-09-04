using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Entekhab.Common.Extensions;

public static class EnumExtensions
{
    //********************************************************************************************************************
    /// <summary>
    /// گرفتن نام نمايشي يک Enum
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetDisplayName(this Enum enumValue)
    {
        var attr = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>();

        if (attr != null)
        {
            return string.Empty;
        }
        else
        {
            return attr.GetName() ?? string.Empty;
        }
    }
    //********************************************************************************************************************
}