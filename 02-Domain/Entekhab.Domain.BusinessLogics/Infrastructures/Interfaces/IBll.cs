using Entekhab.Common.Objects;

namespace Entekhab.Domain.BusinessLogics.Infrastructures.Interfaces;

public interface IBll<in T> : IDisposable where T : class
{
    //********************************************************************************************************************
    /// <summary>
    /// افزودن ويو مدل دريافتي به ديتابيس در قالب مدل مربوطه
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    SysResult Add(T viewModel, string userId);
    //********************************************************************************************************************
    /// <summary>
    /// بروزرساني ويو مدل دريافتي به ديتابيس در قالب مدل مربوطه
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    SysResult Update(T viewModel, string userId);
    //********************************************************************************************************************
    /// <summary>
    /// حذف از ديتابيس براساس ويومدل وارد شده
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    SysResult Delete(T viewModel);
    //********************************************************************************************************************
    /// <summary>
    /// حذف از ديتابيس براساس لیستی از ويومدل های وارد شده
    /// </summary>
    /// <param name="viewModels"></param>
    /// <returns></returns>
    SysResult Delete(IEnumerable<T> viewModels);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي از آبجکت موردنظر
    /// </summary>
    /// <returns></returns>
    SysResult SelectAll();
    //********************************************************************************************************************
    /// <summary>
    /// جستجوی یک شیء براساس شناسه
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    SysResult Find(int id);
    //********************************************************************************************************************
}