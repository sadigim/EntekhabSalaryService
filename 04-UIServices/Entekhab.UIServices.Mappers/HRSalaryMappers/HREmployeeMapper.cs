using Entekhab.Common.Extensions;
using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Domain.Entities.HumanResourceModels;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;
using Entekhab.UIServices.ViewModels.Infrastructures.Abstracts;

namespace Entekhab.UIServices.Mappers.HRSalaryMappers;

public class HREmployeeMapper
{
    //********************************************************************************************************************
    /// <summary>
    /// تبدیل ویومدل آبجکت به مدل متناظر
    /// </summary>
    /// <param name="viewModel">ویومدل</param>
    /// <param name="erpCompanyId">شناسه شرکت یا سازمان جاری</param>
    /// <param name="userId">شناسه کاربر جاری</param>
    /// <returns></returns>
    public static HREmployeeModel ToModel(HREmployeeViewModel viewModel, int erpCompanyId, string userId)
    {
        return new HREmployeeModel
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            BasicSalary = viewModel.BasicSalary,
            Allowance = viewModel.Allowance,
            Transportation = viewModel.Transportation,
            Date = viewModel.Date,
            OverTime = viewModel.OverTime,
            TaxValue = viewModel.TaxValue,
            FinalSalary = viewModel.FinalSalary,

            CreatorUserId = userId,
            CreateDateTime = DateTime.UtcNow,

            EditorUserId = string.Empty
        };
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبدیل یک نمونه از مدل به ویومدل
    /// </summary>
    /// <param name="model">مدل</param>
    /// <returns></returns>
    public static SysResult ToListViewModel(HREmployeeModel model)
    {
        var viewModel = new HREmployeeListViewModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BasicSalary = model.BasicSalary,
            Allowance = model.Allowance,
            Transportation = model.Transportation,
            Date = model.Date,
            OverTime = model.OverTime,
            TaxValue = model.TaxValue,
            FinalSalary = model.FinalSalary,

            Details = new DetailViewModel
            {
                CreatorUserId = model.CreatorUserId,
                CreateDateTime = model.CreateDateTime.ToPersian(true),
                EditorUserId = model.EditorUserId,
                EditDateTime = model.EditDateTime.ToPersian(true)
            }
        };

        return Result.Success("عمليات با موفقيت انجام شد", viewModel);
    }
    //********************************************************************************************************************
    /// <summary>
    /// تبدیل لیستی از مدل مربوطه به لیستی از ویومدل متناظر
    /// </summary>
    /// <param name="models">لیستی از مدل</param>
    /// <returns></returns>
    public static SysResult ToListViewModel(IEnumerable<HREmployeeModel> models)
    {
        var viewModel = models.Select(o => new HREmployeeListViewModel()
        {
            Id = o.Id,
            FirstName = o.FirstName,
            LastName = o.LastName,
            BasicSalary = o.BasicSalary,
            Allowance = o.Allowance,
            Transportation = o.Transportation,
            Date = o.Date,
            OverTime = o.OverTime,
            TaxValue = o.TaxValue,
            FinalSalary = o.FinalSalary,

            Details = new DetailViewModel()
            {
                CreatorUserId = o.CreatorUserId,
                CreateDateTime = o.CreateDateTime.ToPersian(true),
                EditorUserId = o.EditorUserId,
                EditDateTime = o.EditDateTime.ToPersian(true)
            }
        }).ToList();

        return Result.Success("عمليات با موفقيت انجام شد", viewModel);
    }
    //********************************************************************************************************************
}
