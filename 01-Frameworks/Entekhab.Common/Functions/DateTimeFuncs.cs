using System.Globalization;
using Entekhab.Common.Extensions;

namespace Entekhab.Common.Functions;

public class DateTimeFuncs
{
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه زمان نسبی سپری شده 
    /// </summary>
    /// <param name="date"></param>
    /// <param name="comparedTo"></param>
    /// <returns></returns>
    public static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
    {
        var diff = comparedTo.Subtract(date);
        if (diff.Days >= 7)
            return string.Concat("در ", date.ToPersian());
        else if (diff.Days > 1)
            return string.Concat(diff.Days, " روز قبل");
        else if (diff.Days == 1)
            return "دیروز";
        else if (diff.Hours >= 2)
            return string.Concat(diff.Hours, " ساعت قبل");
        else if (diff.Minutes >= 60)
            return "بیشتر از یک ساعت قبل";
        else if (diff.Minutes >= 5)
            return string.Concat(diff.Minutes, " دقیقه قبل");
        return diff.Minutes >= 1 ? "چند دقیقه قبل" : "کمتر از یک دقیقه قبل";
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن سال شمسی
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static int GetPersianYear(DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();

        var pc = new PersianCalendar();
        var year = pc.GetYear(dateTime);

        return year;
    }
    //********************************************************************************************************************
}