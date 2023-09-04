using System.Globalization;
using Entekhab.Common.Functions;

namespace Entekhab.Common.Extensions;

public static class DateTimeExtentions
{
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ ميلادي به صورت متنی کامل
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToFull(this DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();

        string monthName;

        switch (dateTime.Month)
        {
            case 1:
                monthName = "January";
                break;

            case 2:
                monthName = "February";
                break;

            case 3:
                monthName = "March";
                break;

            case 4:
                monthName = "April";
                break;

            case 5:
                monthName = "May";
                break;

            case 6:
                monthName = "June";
                break;

            case 7:
                monthName = "July";
                break;

            case 8:
                monthName = "August";
                break;

            case 9:
                monthName = "September";
                break;

            case 10:
                monthName = "October";
                break;

            case 11:
                monthName = "November";
                break;

            case 12:
                monthName = "December";
                break;

            default:
                monthName = "Eror";
                break;
        }

        return dateTime.DayOfWeek + " - " + dateTime.Day + " " + monthName + dateTime.Year;
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ ميلادي به تاريخ شمسي - بدون فرمت بندي
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="withHour"></param>
    /// <returns></returns>
    public static string ToPersian(this DateTime dateTime, bool withHour = false)
    {
        if (dateTime == DateTime.MinValue)
            return string.Empty;

        dateTime = dateTime.ToLocalTime();

        var pc = new PersianCalendar();
        var year = pc.GetYear(dateTime);
        var month = pc.GetMonth(dateTime);
        var day = pc.GetDayOfMonth(dateTime);
        var hour = pc.GetHour(dateTime);
        var minute = pc.GetMinute(dateTime);
        var second = pc.GetSecond(dateTime);

        if (withHour)
            return year + "/" + month.ToString("00") + "/" + day.ToString("00") + " ساعت " + hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

        return year + "/" + month.ToString("00") + "/" + day.ToString("00");
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ ميلادي به تاريخ شمسي - به صورت متنی کامل
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToPersianFull(this DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();

        var pc = new PersianCalendar();
        var year = pc.GetYear(dateTime);
        var month = pc.GetMonth(dateTime);
        var day = pc.GetDayOfMonth(dateTime);
        var hour = pc.GetHour(dateTime);
        var minute = pc.GetMinute(dateTime);
        var second = pc.GetSecond(dateTime);

        string monthName;

        switch (month)
        {
            case 1:
                monthName = "فروردين";
                break;

            case 2:
                monthName = "ارديبهشت";
                break;

            case 3:
                monthName = "خرداد";
                break;

            case 4:
                monthName = "تير";
                break;

            case 5:
                monthName = "مرداد";
                break;

            case 6:
                monthName = "شهريور";
                break;

            case 7:
                monthName = "مهر";
                break;

            case 8:
                monthName = "آبان";
                break;

            case 9:
                monthName = "آذر";
                break;

            case 10:
                monthName = "دي";
                break;

            case 11:
                monthName = "بهمن";
                break;

            case 12:
                monthName = "اسفند";
                break;

            default:
                monthName = "خطا";
                break;
        }

        string dayName;

        switch (dateTime.DayOfWeek)
        {
            case DayOfWeek.Saturday:
                dayName = "شنبه";
                break;

            case DayOfWeek.Sunday:
                dayName = "يكشنبه";
                break;

            case DayOfWeek.Monday:
                dayName = "دوشنبه";
                break;

            case DayOfWeek.Tuesday:
                dayName = "سه‌شنبه";
                break;

            case DayOfWeek.Wednesday:
                dayName = "چهار‌شنبه";
                break;

            case DayOfWeek.Thursday:
                dayName = "پنجشنبه";
                break;

            case DayOfWeek.Friday:
                dayName = "جمعه";
                break;

            default:
                dayName = "خطا";
                break;
        }

        return dayName + " - " + day + " " + monthName + year;
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ ميلادي به تاريخ قمری - به صورت متنی کامل
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToHijriFull(this DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();

        var hc = new HijriCalendar();
        var year = hc.GetYear(dateTime);
        var month = hc.GetMonth(dateTime);
        var day = hc.GetDayOfMonth(dateTime);
        var hour = hc.GetHour(dateTime);
        var minute = hc.GetMinute(dateTime);
        var second = hc.GetSecond(dateTime);

        string monthName;

        switch (month)
        {
            case 1:
                monthName = "مُحَرَّم";
                break;

            case 2:
                monthName = "صَفَر";
                break;

            case 3:
                monthName = "رَبيع الأوّل";
                break;

            case 4:
                monthName = "رَبيع الثاني";
                break;

            case 5:
                monthName = "جُمادى الأولى";
                break;

            case 6:
                monthName = "جُمادى الآخرة";
                break;

            case 7:
                monthName = "رَجَب";
                break;

            case 8:
                monthName = "شَعْبان";
                break;

            case 9:
                monthName = "رَمَضان";
                break;

            case 10:
                monthName = "شَوّال";
                break;

            case 11:
                monthName = "ذی‌القعدة";
                break;

            case 12:
                monthName = "ذی‌الحجة";
                break;

            default:
                monthName = "خطا";
                break;
        }

        string dayName;

        switch (dateTime.DayOfWeek)
        {
            case DayOfWeek.Saturday:
                dayName = "السبت";
                break;

            case DayOfWeek.Sunday:
                dayName = "الأحد";
                break;

            case DayOfWeek.Monday:
                dayName = "الإثنين";
                break;

            case DayOfWeek.Tuesday:
                dayName = "الثلاثاء";
                break;

            case DayOfWeek.Wednesday:
                dayName = "الأربعاء";
                break;

            case DayOfWeek.Thursday:
                dayName = "الخميس";
                break;

            case DayOfWeek.Friday:
                dayName = "الجمعة";
                break;

            default:
                dayName = "خطا";
                break;
        }

        return dayName + " - " + day + " " + monthName + year;
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ شمسی به تاريخ میلادی - بدون فرمت بندي
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToMiladi(this DateTime dateTime)
    {
        var pc = new PersianCalendar();
        return pc.ToDateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبدیل رشته حاوی تاریخ شمسی به تاریخ میلادی
    /// </summary>
    /// <param name="shamsiDate"></param>
    /// <returns></returns>
    public static DateTime ToMiladi(this string shamsiDate)
    {
        var persianDate = shamsiDate.Split('/');
        var intYear = int.Parse(persianDate[0]);
        var intMonth = int.Parse(persianDate[1]);
        var intDay = int.Parse(persianDate[2]);

        var pc = new PersianCalendar();
        return pc.ToDateTime(intYear, intMonth, intDay, 1, 1, 1, 1);
    }
    //********************************************************************************************************************
    /// <summary>
    /// نمايش تاريخ و ساعت بصورت مجزا از هم - مثال: 1396/01/01 ساعت 15:42
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToSepprateDateTime(this DateTime dateTime)
    {
        return string.Format("{0:yyyy/MM/dd} ساعت {0:HH:mm}", dateTime);
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبديل تاريخ با فرمت ساعت هماهنگ جهاني به تاريخ و زمان فرمت کشور ايران
    /// </summary>
    /// <param name="utcDateTime"></param>
    /// <returns></returns>
    public static DateTime UtcToNormalDateTime(this DateTimeOffset utcDateTime)
    {
        //Set the time zone information to Iran Standard Time
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
        //Get date and time in Iran Standard Time
        return TimeZoneInfo.ConvertTime(utcDateTime.UtcDateTime, timeZoneInfo);
        //Print out the date and time
    }
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه زمان نسبی سپری شده يا مانده به يک تاريخ و زمان با فرمت عادي
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToRelativeDateString(this DateTime date)
    {
        return DateTimeFuncs.GetRelativeDateValue(date, DateTime.Now);
    }
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه زمان نسبی سپری شده يا مانده به يک تاريخ و زمان با فرمت ساعت هماهنگ جهاني
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToRelativeDateStringUtc(this DateTime date)
    {
        return DateTimeFuncs.GetRelativeDateValue(date, DateTime.UtcNow);
    }
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه اختلاف تعداد روزهای بین دو تاریخ
    /// </summary>
    /// <param name="firstDate"></param>
    /// <param name="secondDate"></param>
    /// <returns></returns>
    public static int DateDiff(this DateTime firstDate, DateTime secondDate)
    {
        return (int)secondDate.Date.Subtract(firstDate.Date).TotalDays;
    }
    //********************************************************************************************************************
}