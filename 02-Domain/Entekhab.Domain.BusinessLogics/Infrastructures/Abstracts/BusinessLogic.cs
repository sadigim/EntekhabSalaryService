using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Domain.BusinessLogics.Infrastructures.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Entekhab.Domain.BusinessLogics.Infrastructures.Abstracts;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TDal">Dal Class</typeparam>
/// <typeparam name="TModel">Model Of Object</typeparam>
/// <typeparam name="TViewModel">ViewModel Of Object</typeparam>
/// <typeparam name="TBusinessRule">Business Rule Class</typeparam>
/// <typeparam name="TCore">Core Class</typeparam>
public abstract class BusinessLogic<TDal, TModel, TViewModel, TBusinessRule, TCore> : IBll<TViewModel> where TDal : class where TModel : class where TViewModel : class where TBusinessRule : class where TCore : class
{
    private readonly int _erpCompanyId;
    private readonly MainDbContext _dbContext;
    private readonly TDal _HREmployeeDal;

    public Expression<Func<TModel, object>>[] Includes;
    //********************************************************************************************************************
    protected BusinessLogic(int erpCompanyId, Expression<Func<TModel, object>>[] includes)
    {
        _erpCompanyId = erpCompanyId;
        _dbContext = new MainDbContext();
        _HREmployeeDal = (TDal)Activator.CreateInstance(typeof(TDal), _dbContext);

        Includes = includes;
    }
    //********************************************************************************************************************
    public virtual SysResult Add(TViewModel viewModel, string userId)
    {
        try
        {
            var addPreconditionResult = typeof(TBusinessRule).GetMethod("AddPrecondition",
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                null,
                new[] { typeof(MainDbContext), typeof(TViewModel), typeof(int) },
                null)
                .Invoke(null, new object[] { _dbContext, viewModel, _erpCompanyId });

            if (!((SysResult)addPreconditionResult).Successed)
            {
                return (SysResult)addPreconditionResult;
            }

            var HREmployeeAddResult = typeof(TCore).GetMethod("Add",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(TViewModel), typeof(int), typeof(string) },
                    null)
                .Invoke(null, new object[] { _dbContext, viewModel, _erpCompanyId, userId });

            return ((SysResult)HREmployeeAddResult).Successed
                ? Result.Success("عملیات افزودن با موفقیت انجام گردید")
                : (SysResult)HREmployeeAddResult;
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    public virtual SysResult Update(TViewModel viewModel, string userId)
    {
        try
        {
            var updatePreconditionResult = typeof(TBusinessRule).GetMethod("UpdatePrecondition",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(TViewModel), typeof(int) },
                    null)
                .Invoke(null, new object[] { _dbContext, viewModel, _erpCompanyId });

            if (!((SysResult)updatePreconditionResult).Successed)
            {
                return (SysResult)updatePreconditionResult;
            }

            var HREmployeeUpdateResult = typeof(TCore).GetMethod("Update",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(TViewModel), typeof(string) },
                    null)
                .Invoke(null, new object[] { _dbContext, viewModel, userId });

            return ((SysResult)HREmployeeUpdateResult).Successed
                ? Result.Success("عمليات بروزرساني با موفقيت انجام شد")
                : (SysResult)HREmployeeUpdateResult;
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    public virtual SysResult Delete(TViewModel viewModel)
    {
        try
        {
            var deletePreconditionResult = typeof(TBusinessRule).GetMethod("DeletePrecondition",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(TViewModel) },
                    null)
                .Invoke(null, new object[] { _dbContext, viewModel });


            if (!((SysResult)deletePreconditionResult).Successed)
            {
                return (SysResult)deletePreconditionResult;
            }


            // Get the type of FieldsClass.
            var fieldsType = typeof(TViewModel);

            // Get an array of FieldInfo objects.
            var fields = ((TypeInfo)fieldsType).DeclaredFields;

            var id = fields.FirstOrDefault(x => x.Name == "<Id>k__BackingField")?.GetValue(viewModel);



            return (SysResult)typeof(TCore).GetMethod("Delete",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(int) },
                    null)
                .Invoke(null, new[] { _dbContext, id });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    public virtual SysResult Delete(IEnumerable<TViewModel> viewModels)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                foreach (var viewModel in viewModels)
                {
                    var deleteResult = Delete(viewModel);

                    if (!deleteResult.Successed)
                    {
                        return deleteResult;
                    }
                }

                transaction.Commit();

                return Result.Success("عمليات حذف با موفقيت انجام شد");
            }
            catch (Exception e)
            {
                transaction.Rollback();

                return Result.ErrorOfException(e);
            }
        }
    }
    //********************************************************************************************************************
    public virtual SysResult SelectAll()
    {
        try
        {
            return (SysResult)typeof(TCore).GetMethod("SelectAll",
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                null,
                new[] { typeof(MainDbContext), typeof(Expression<Func<TModel, object>>[]) },
                null)
                .Invoke(null, new object[] { _dbContext, Includes });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    public virtual SysResult Find(int id)
    {
        try
        {
            return (SysResult)typeof(TCore).GetMethod("Find",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy,
                    null,
                    new[] { typeof(MainDbContext), typeof(int), typeof(Expression<Func<TModel, object>>[]) },
                    null)
                .Invoke(null, new object[] { _dbContext, id, Includes });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    //********************************************************************************************************************
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;

        if (_HREmployeeDal != null)
        {
            typeof(TDal).GetMethod("Dispose", new Type[0])
                .Invoke(_HREmployeeDal, new object[0]);
        }
    }
    //********************************************************************************************************************
}
