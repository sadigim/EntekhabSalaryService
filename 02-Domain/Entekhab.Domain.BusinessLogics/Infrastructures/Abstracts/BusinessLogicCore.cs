using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Data.EntityFramework.DbContexts;
using System.Linq.Expressions;
using System.Reflection;

namespace Entekhab.Domain.BusinessLogics.Infrastructures.Abstracts;

/// <summary>
/// کلاس عملیات پایه ای استاندارد برای هر آبجکت در پلت فرم ipnovin
/// </summary>
/// <typeparam name="TDal">Dal Class</typeparam>
/// <typeparam name="TMapper">Mapper Class</typeparam>
/// <typeparam name="TModel">Model Of Object</typeparam>
/// <typeparam name="TViewModel">ViewModel Of Object</typeparam>
/// <typeparam name="TListViewModel">List ViewModel Of Object</typeparam>
public abstract class BusinessLogicCore<TDal, TMapper, TModel, TViewModel, TListViewModel> where TDal : class where TMapper : class where TModel : class where TViewModel : class where TListViewModel : class
{
    //********************************************************************************************************************
    /// <summary>
    /// عملیات افزودن
    /// </summary>
    /// <param name="dbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل مربوطه</param>
    /// <param name="erpCompanyId">شناسه شرکت یا سازمان جاری</param>
    /// <param name="userId">شناسه کاربر جاری</param>
    /// <returns></returns>
    public static SysResult Add(MainDbContext dbContext, TViewModel viewModel, int erpCompanyId, string userId)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), dbContext);

            var toModelMethod = typeof(TMapper).GetMethod("ToModel", BindingFlags.Public | BindingFlags.Static);

            var model = (TModel)toModelMethod.Invoke(null, new object[] { viewModel, erpCompanyId, userId });

            typeof(TDal).GetMethod("Add").Invoke(objDal, new object[] { model });
            typeof(TDal).GetMethod("Save").Invoke(objDal, null);

            return Result.Success("عمليات افزودن با موفقيت انجام شد", model);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// عملیات بروزرسانی تغییرات انجام شده
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="viewModel">ویومدل مربوطه</param>
    /// <param name="userId">شناسه کاربر جاری</param>
    /// <returns></returns>
    public static SysResult Update(MainDbContext mainDbContext, TViewModel viewModel, string userId)
    {
        throw new NotImplementedException();
    }
    //********************************************************************************************************************
    /// <summary>
    /// عملیات بروزرسانی تغییرات انجام شده بصورت دسته جمعی
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="models">ولیست مدل مربوطه</param>
    /// <param name="userId">شناسه کاربر جاری</param>
    /// <returns></returns>
    public static SysResult Update(MainDbContext mainDbContext, List<TModel> models)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            typeof(TDal).GetMethod("UpdateRange", new[] { typeof(List<TModel>) }).Invoke(objDal, new object[] { models });
            typeof(TDal).GetMethod("Save").Invoke(objDal, null);

            return Result.Success("عمليات حذف با موفقيت انجام شد");
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// عملیات حذف
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="id">شناسه رکورد موردنظر برای حذف</param>
    /// <returns></returns>
    public static SysResult Delete(MainDbContext mainDbContext, int id)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            typeof(TDal).GetMethod("Delete", new[] { typeof(int) }).Invoke(objDal, new object[] { id });
            typeof(TDal).GetMethod("Save").Invoke(objDal, null);

            return Result.Success("عمليات حذف با موفقيت انجام شد");
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// عملیات حذف براساس شرط
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <returns></returns>
    public static SysResult Delete(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            typeof(TDal).GetMethod("Delete",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate
                        });

            typeof(TDal).GetMethod("Save").Invoke(objDal, null);

            return Result.Success("عمليات حذف با موفقيت انجام شد");
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن لیست کلی از یک کلاس
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult SelectAll(MainDbContext mainDbContext, Expression<Func<TModel, object>>[] includeExpressions)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("SelectAll",
                        new[]
                        {
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("SelectAll", new Type[0])
                    .Invoke(objDal, new object[0]);
            }


            var toModelMethod = typeof(TMapper).GetMethod("ToListViewModel",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(IEnumerable<TModel>) },
                null);

            return (SysResult)toModelMethod.Invoke(null, new object[] { (IEnumerable<TModel>)result });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن لیست کلی از یک کلاس بصورت ویومدل و براساس شرایط خاص
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult Where(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>>[] includeExpressions)
    {
        try
        {
            if (predicate == null)
            {
                return Result.Error("پارامتر مربوط به شروط به درستی پاس نشده است");
            }

            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("Where",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>),
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate,
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("Where",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate
                        });
            }


            var toModelMethod = typeof(TMapper).GetMethod("ToListViewModel",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(IEnumerable<TModel>) },
                null);

            if (toModelMethod == null)
            {
                return Result.Error("متد ToListViewModel با یک آرگومان شامل لیستی از آبجکت های مدل در کلاس Mapper یافت نشد");
            }

            return (SysResult)toModelMethod.Invoke(null, new object[] { (IEnumerable<TModel>)result });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن لیست کلی از یک کلاس بصورت مدل و براساس شرایط خاص
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult WhereAsModel(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>>[] includeExpressions)
    {
        try
        {
            if (predicate == null)
            {
                return Result.Error("پارامتر مربوط به شروط به درستی پاس نشده است");
            }

            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("Where",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>),
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate,
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("Where",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate
                        });
            }

            return Result.Success("عملیات جستجو با موفقیت انجام گردید", (IEnumerable<TModel>)result);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن اولین رکورد منطبق با شرایط موردنظر از یک کلاس بصورت ویومدل
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult FirstOrDefault(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>>[] includeExpressions)
    {
        try
        {
            if (predicate == null)
            {
                return Result.Error("پارامتر مربوط به شروط به درستی پاس نشده است");
            }

            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("FirstOrDefault",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>),
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate,
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("FirstOrDefault",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate
                        });
            }


            var toModelMethod = typeof(TMapper).GetMethod("ToListViewModel",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(TModel) },
                null);

            if (toModelMethod == null)
            {
                return Result.Error("متد ToListViewModel با یک آرگومان شامل لیستی از آبجکت های مدل در کلاس Mapper یافت نشد");
            }

            return (SysResult)toModelMethod.Invoke(null, new object[] { (TModel)result });
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن اولین رکورد منطبق با شرایط موردنظر از یک کلاس بصورت مدل
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult FirstOrDefaultAsModel(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>>[] includeExpressions)
    {
        try
        {
            if (predicate == null)
            {
                return Result.Error("پارامتر مربوط به شروط به درستی پاس نشده است");
            }

            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("FirstOrDefault",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>),
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate,
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("FirstOrDefault",
                        new[]
                        {
                                typeof(Expression<Func<TModel, bool>>)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                predicate
                        });
            }

            return Result.Success("عملیات با موفقیت انجام گردید", (TModel)result);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// جستجوی یک رکورد از یک کلاس و برگرداندن خروجی بصورت ویومدل
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="id">شناسه رکورد موردنظر</param>
    /// <param name="includeExpressions">کلاس های مرتبط موردنیاز برای فراخوانی دیتا</param>
    /// <returns></returns>
    public static SysResult Find(MainDbContext mainDbContext, int id, Expression<Func<TModel, object>>[] includeExpressions = null)
    {
        try
        {
            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            object result;

            if (includeExpressions != null)
            {
                result = typeof(TDal).GetMethod("Find",
                        new[]
                        {
                                typeof(int),
                                typeof(Expression<Func<TModel, object>>[])
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                id,
                                includeExpressions
                        });
            }
            else
            {
                result = typeof(TDal).GetMethod("Find",
                        new[]
                        {
                                typeof(int)
                        })
                    .Invoke(objDal,
                        new object[]
                        {
                                id
                        });
            }

            if ((TModel)result == null)
            {
                return Result.Error("موردی یافت نشد");
            }

            var toModelMethod = typeof(TMapper).GetMethod("ToListViewModel",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(TModel) },
                null);

            var listViewModel = (TListViewModel)toModelMethod.Invoke(null, new object[] { (TModel)result });

            return Result.Success("عمليات جستجو با موفقيت انجام شد", listViewModel);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
    /// <summary>
    /// بررسی اینکه آیا رکورد یا رکوردهایی با شرایط موردنظر در کلاس مربوطه وجود دارد یا نه؟ خروجی بصورت ترو یا فالز می باشد
    /// </summary>
    /// <param name="mainDbContext">شیء ایجاد شده از پایگاه داده</param>
    /// <param name="predicate">شرط یا شرط های موردنظر</param>
    /// <returns></returns>
    public static SysResult HaveAnyBy(MainDbContext mainDbContext, Expression<Func<TModel, bool>> predicate)
    {
        try
        {
            if (predicate == null)
            {
                return Result.Error("پارامتر مربوط به شروط به درستی پاس نشده است");
            }

            var objDal = (TDal)Activator.CreateInstance(typeof(TDal), mainDbContext);

            var result = typeof(TDal).GetMethod("Where",
                    new[]
                    {
                            typeof(Expression<Func<TModel, bool>>)
                    })
                .Invoke(objDal,
                    new object[]
                    {
                            predicate
                    });

            return ((IEnumerable<TModel>)result).Any()
                ? Result.Success("دیتایی با شرایط مدنظر شما یافت شد", true)
                : Result.Success("دیتایی با شرایط مدنظر شما یافت نشد", false);
        }
        catch (Exception e)
        {
            return Result.ErrorOfException(e);
        }
    }
    //********************************************************************************************************************
}
