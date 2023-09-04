using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Data.EntityFramework.HRSalaryRepositories;
using Entekhab.Domain.Entities.HumanResourceModels;
using Entekhab.UIServices.Mappers.HRSalaryMappers;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;

namespace Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.Core;

public class HREmployeeCore : Infrastructures.Abstracts.BusinessLogicCore<HREmployeeRepository, HREmployeeMapper, HREmployeeModel, HREmployeeViewModel, HREmployeeListViewModel>
{
    //********************************************************************************************************************
    /// <summary>
    /// عملیات بروزرسانی تغییرات انجام شده
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل مربوطه</param>
    /// <param name="userId">شناسه کاربر جاری</param>
    /// <returns></returns>
    public new static SysResult Update(MainDbContext mainDbContext, HREmployeeViewModel viewModel, string userId)
    {
        try
        {
            var HREmployeeRepository = new HREmployeeRepository(mainDbContext);

            var model = HREmployeeRepository.Where(x => x.FirstName == viewModel.FirstName &
                                                        x.LastName == viewModel.LastName &&
                                                        x.Date == viewModel.Date).FirstOrDefault();

            if (model == null)
            {
                return Result.Error("اطلاعات حقوق برای فرد و تاریخ موردنظر یافت نشد");
            }

            model.BasicSalary = viewModel.BasicSalary;
            model.Allowance = viewModel.Allowance;
            model.Transportation = viewModel.Transportation;
            model.OverTime = viewModel.OverTime;
            model.TaxValue = viewModel.TaxValue;
            model.FinalSalary = viewModel.FinalSalary;

            model.EditorUserId = userId;
            model.EditDateTime = DateTime.UtcNow;

            HREmployeeRepository.Update(model);
            HREmployeeRepository.Save();

            return Result.Success("عمليات بروزرساني با موفقيت انجام شد", model);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
}
