using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using OvertimeMethods.Core;

namespace Entekhab.Domain.BusinessLogics.Infrastructures.Functions;

internal class HRSalaryTools
{
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه مبلغ اضافه کاری
    /// </summary>
    /// <param name="viewModel">ویومدل</param>
    /// <param name="overTimeHours">ساعات اضافه کاری</param>
    /// <returns></returns>
    public static SysResult CalculateOverTimeValue(double basicSalary, double allowance, short overTimeHours, string methodName)
    {
        try
        {
            OvertimePolicies overtimePolicies = new();

            // Get the method info using reflection
            var method = typeof(OvertimePolicies).GetMethod(methodName);

            if (method != null)
            {
                // Invoke the method with the provided arguments
                var result = method.Invoke(overtimePolicies, new object[] { basicSalary + allowance, overTimeHours });

                if (result != null)
                {
                    var overTimeValue = (double)result;
                    return Result.Success("مبلغ اضافه کاری با موفقیت محاسبه گردید", overTimeValue);
                }
                else
                {
                    return Result.Error("خطا در متد محاسبه حقوق");
                }
            }
            else
            {
                return Result.Error("متد موردنظر شما در سیستم محاسبه اضافه کار یافت نشد");
            }
        }
        catch (Exception ex)
        {
            return Result.ErrorOfException(ex);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// محاسبه مبلغ اضافه کاری
    /// </summary>
    /// <param name="Salary">جمع کل دریافتی</param>
    /// <returns></returns>
    public static SysResult CalculateTaxValue(double Salary) => Result.Success("مبلغ مالیات با موفقیت محاسبه گردید", Salary * 0.1);
    //********************************************************************************************************************
}
