using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Data.EntityFramework.HRSalaryRepositories;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;

namespace Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.BusinessRule;

public class HREmployeeBr
{
    //********************************************************************************************************************
    /// <summary>
    /// بررسی پیش شرط های لازم برای ادامه عملیات افزودن
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل آبجکت موردنظر</param>
    /// <param name="erpCompanyId">شناسه شرکت جاری</param>
    /// <returns></returns>
    public static SysResult AddPrecondition(MainDbContext mainDbContext, HREmployeeViewModel viewModel, int erpCompanyId)
    {
        var repository = new HREmployeeRepository(mainDbContext);

        var result = repository.Where(x => x.FirstName == viewModel.FirstName &&
                                            x.LastName == viewModel.LastName &&
                                            x.Date == viewModel.Date);

        if (result.Any())
        {
            return Result.Error("قبلا اطلاعاتي با اين مشخصات ايجاد شده است");
        }

        return Result.Success("هیچ مانعی برای ادامه عملیات افزودن وجود ندارد");
    }
    //********************************************************************************************************************
    /// <summary>
    /// بررسی پیش شرط های لازم برای ادامه عملیات بروزرسانی تغییرات انجام شده
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل آبجکت موردنظر</param>
    /// <param name="erpCompanyId">شناسه شرکت جاری</param>
    /// <returns></returns>
    public static SysResult UpdatePrecondition(MainDbContext mainDbContext, HREmployeeViewModel viewModel, int erpCompanyId)
    {
        var HREmployeeRepository = new HREmployeeRepository(mainDbContext);

        var result = HREmployeeRepository.Where(x => x.FirstName == viewModel.FirstName &&
                                                    x.LastName == viewModel.LastName &&
                                                    x.Date == viewModel.Date &&
                                                    x.Id != viewModel.Id).ToList();

        if (result.Any())
        {
            Result.Error("امکان ویرایش وجود ندارد، قبلا اطلاعاتي با اين مشخصات ايجاد شده است");
        }

        return Result.Success("هیچ مانعی برای ادامه عملیات بروزرسانی تغییرات وجود ندارد");
    }
    //********************************************************************************************************************
    /// <summary>
    /// بررسی پیش شرط های لازم برای ادامه عملیات حذف
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل آبجکت موردنظر</param>
    /// <returns></returns>
    public static SysResult DeletePrecondition(MainDbContext mainDbContext, HREmployeeViewModel viewModel)
    {
        return Result.Success("هیچ مانعی برای ادامه عملیات حذف وجود ندارد");
    }
    //********************************************************************************************************************
}
