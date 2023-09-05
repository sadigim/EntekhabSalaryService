using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Data.EntityFramework.HRSalaryRepositories;
using Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.BusinessRule;
using Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.Core;
using Entekhab.Domain.BusinessLogics.Infrastructures.Abstracts;
using Entekhab.Domain.BusinessLogics.Infrastructures.Functions;
using Entekhab.Domain.Entities.HumanResourceModels;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;
using System.Linq.Expressions;

namespace Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.BusinessLogic;

public class HREmployeeBl : BusinessLogic<HREmployeeRepository, HREmployeeModel, HREmployeeViewModel, HREmployeeBr, HREmployeeCore>
{
    private readonly int _companyId;
    private readonly MainDbContext _dbContext;

    public static Expression<Func<HREmployeeModel, object>>[] IncludeExpressions = null;
    //********************************************************************************************************************
    public HREmployeeBl(int erpCompanyId) : base(erpCompanyId, IncludeExpressions)
    {
        _companyId = erpCompanyId;
        _dbContext = new MainDbContext();
    }
    //********************************************************************************************************************
    public override SysResult Add(HREmployeeViewModel viewModel, string userId)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var addPreconditionResult = HREmployeeBr.AddPrecondition(_dbContext, viewModel, _companyId);
                
                if (!addPreconditionResult.Successed)
                    return addPreconditionResult;


                // محاسبه مبلغ اضافه کاری
                //---------------------------------------------------------------------------------------
                SysResult CalculateOverTimeValueResult= HRSalaryTools.CalculateOverTimeValue(viewModel.BasicSalary, viewModel.Allowance, 40, viewModel.MethodName);

                if (!CalculateOverTimeValueResult.Successed)
                    return CalculateOverTimeValueResult;

                if (CalculateOverTimeValueResult.Value != null)
                    viewModel.OverTime = Math.Round((double)CalculateOverTimeValueResult.Value,2);
                else
                    return Result.Error("خطا در محاسبه مبلغ اضافه کاری");
                //---------------------------------------------------------------------------------------


                // محاسبه مبلغ مالیات
                //---------------------------------------------------------------------------------------
                SysResult CalculateTaxValueResult = HRSalaryTools.CalculateTaxValue(viewModel.BasicSalary+viewModel.Allowance+ viewModel.Transportation+viewModel.OverTime);

                if (!CalculateTaxValueResult.Successed)
                    return CalculateTaxValueResult;

                if (CalculateTaxValueResult.Value != null)
                    viewModel.TaxValue = Math.Round((double)CalculateTaxValueResult.Value,2);
                else
                    return Result.Error("خطا در محاسبه مبلغ اضافه کاری");
                //---------------------------------------------------------------------------------------

                // محاسبه حقوق خالص
                //---------------------------------------------------------------------------------------
                viewModel.FinalSalary=  viewModel.BasicSalary + viewModel.Allowance + viewModel.Transportation + viewModel.OverTime - viewModel.TaxValue;
                //---------------------------------------------------------------------------------------


                var addResult = HREmployeeCore.Add(_dbContext, viewModel, _companyId, userId);

                if (!addResult.Successed)
                {
                    return addResult;
                }

                transaction.Commit();

                return Result.Success("عملیات افزودن با موفقیت انجام گردید");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return Result.ErrorOfException(e);
            }
        }
    }
    //********************************************************************************************************************
    public override SysResult Update(HREmployeeViewModel viewModel, string userId)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var updatePreconditionResult = HREmployeeBr.UpdatePrecondition(_dbContext, viewModel, _companyId);

                if (!updatePreconditionResult.Successed)
                    return updatePreconditionResult;


                // محاسبه مبلغ اضافه کاری
                //---------------------------------------------------------------------------------------
                SysResult CalculateOverTimeValueResult = HRSalaryTools.CalculateOverTimeValue(viewModel.BasicSalary, viewModel.Allowance, 40, viewModel.MethodName);

                if (!CalculateOverTimeValueResult.Successed)
                    return CalculateOverTimeValueResult;

                if (CalculateOverTimeValueResult.Value != null)
                    viewModel.OverTime = Math.Round((double)CalculateOverTimeValueResult.Value, 2);
                else
                    return Result.Error("خطا در محاسبه مبلغ اضافه کاری");
                //---------------------------------------------------------------------------------------


                // محاسبه مبلغ مالیات
                //---------------------------------------------------------------------------------------
                SysResult CalculateTaxValueResult = HRSalaryTools.CalculateTaxValue(viewModel.BasicSalary + viewModel.Allowance + viewModel.Transportation + viewModel.OverTime);

                if (!CalculateTaxValueResult.Successed)
                    return CalculateTaxValueResult;

                if (CalculateTaxValueResult.Value != null)
                    viewModel.TaxValue = Math.Round((double)CalculateTaxValueResult.Value, 2);
                else
                    return Result.Error("خطا در محاسبه مبلغ اضافه کاری");
                //---------------------------------------------------------------------------------------

                // محاسبه حقوق خالص
                //---------------------------------------------------------------------------------------
                viewModel.FinalSalary = viewModel.BasicSalary + viewModel.Allowance + viewModel.Transportation + viewModel.OverTime - viewModel.TaxValue;
                //---------------------------------------------------------------------------------------


                var updateResult = HREmployeeCore.Update(_dbContext, viewModel, userId);

                if (!updateResult.Successed)
                {
                    return updateResult;
                }

                transaction.Commit();

                return Result.Success("عملیات بروزرسانی با موفقیت انجام گردید");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return Result.ErrorOfException(e);
            }
        }
    }
    //********************************************************************************************************************
    public override SysResult Delete(HREmployeeViewModel viewModel)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var deletePreconditionResult = HREmployeeBr.DeletePrecondition(_dbContext, viewModel);

                if (!deletePreconditionResult.Successed)
                    return deletePreconditionResult;

                var deleteResult = HREmployeeCore.Delete(_dbContext, x => x.FirstName == viewModel.FirstName &&
                                                                        x.LastName == viewModel.LastName &&
                                                                        x.Date == viewModel.Date);

                if (!deleteResult.Successed)
                {
                    return deleteResult;
                }

                transaction.Commit();

                return Result.Success("عملیات حذف با موفقیت انجام گردید");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return Result.ErrorOfException(e);
            }
        }
    }
    //********************************************************************************************************************
    public SysResult Get(HREmployeeViewModel viewModel)
    {
        try
        {
                
            var result = HREmployeeCore.FirstOrDefault(_dbContext, 
                                                                    x => x.FirstName == viewModel.FirstName &&
                                                                        x.LastName == viewModel.LastName &&
                                                                        x.Date == viewModel.Date,
                                                                    IncludeExpressions);

            return result;
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
        
    }
    //********************************************************************************************************************
    public SysResult GetRange(string firstName, string lastName, string startDate, string endDate)
    {
        try
        {

            var result = HREmployeeCore.Where(_dbContext,
                                            x => x.FirstName == firstName &&
                                                x.LastName == lastName &&
                                                x.Date.CompareTo(startDate) >= 0 &&
                                                x.Date.CompareTo(endDate) <= 0,
                                            IncludeExpressions);

            return result;
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }

    }
    //********************************************************************************************************************
}
