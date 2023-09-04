using System.Linq.Expressions;

namespace Entekhab.Data.EntityFramework.Infrastructures.Interfaces;

public interface IDal<T> : IDisposable where T : class
{
    //********************************************************************************************************************
    /// <summary>
    /// افزودن مدل مربوطه به ديتابيس
    /// </summary>
    /// <param name="model"></param>
    void Add(T model);
    //********************************************************************************************************************
    /// <summary>
    /// افزودن گروهی از مدل به دیتابیس
    /// </summary>
    /// <param name="model"></param>
    void AddRange(List<T> model);
    //********************************************************************************************************************
    /// <summary>
    /// بروزرساني ديتابيس از مدل مربوطه
    /// </summary>
    /// <param name="model"></param>
    void Update(T model);
    //********************************************************************************************************************
    /// <summary>
    /// بروزرساني ديتابيس از مدل مربوطه
    /// </summary>
    /// <param name="model"></param>
    void UpdateRange(List<T> model);
    //********************************************************************************************************************
    /// <summary>
    /// حذف از ديتابيس با شناسه
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    //********************************************************************************************************************
    /// <summary>
    /// حذف از ديتابيس با مدل مربوطه
    /// </summary>
    /// <param name="model"></param>
    void Delete(T model);
    //********************************************************************************************************************
    /// <summary>
    /// حذف از دیتابیس براساس شرایط دلخواه
    /// </summary>
    /// <param name="predicate"></param>
    void Delete(Expression<Func<T, bool>> predicate);
    //********************************************************************************************************************
    /// <summary>
    /// جستجوي يک نمونه از يک شي در ديتابيس براساس شناسه
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T Find(int id);
    //********************************************************************************************************************
    /// <summary>
    /// جستجوي در ديتابيس براساس شرط دلخواه
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
    //********************************************************************************************************************
    /// <summary>
    /// جستجو در دیتابیس براساس شرایط دلخواه و امکان Lazy Loading با گرفتن لیست پارامترهای Virtual
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeExpressions"></param>
    /// <returns></returns>
    IEnumerable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي از يک شيء
    /// </summary>
    /// <returns></returns>
    IEnumerable<T> SelectAll();
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي از يک شيء با امکان Lazy Loading با گرفتن لیست پارامترهای Virtual
    /// </summary>
    /// <param name="includeExpressions"></param>
    /// <returns></returns>
    IEnumerable<T> SelectAll(params Expression<Func<T, object>>[] includeExpressions);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي قابل گزارشگیری از يک شيء
    /// </summary>
    /// <returns></returns>
    IQueryable<T> SelectAllAsQuerable(Expression<Func<T, bool>> predicate);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي قابل گزارشگیری از يک شيء
    /// </summary>
    /// <returns></returns>
    IQueryable<T> SelectAllAsQuerable(params Expression<Func<T, object>>[] includeExpressions);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن ليست کلي قابل گزارشگیری از يک شيء براساس شرط های دلخواه
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeExpressions"></param>
    /// <returns></returns>
    IQueryable<T> SelectAllAsQuerable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
    //********************************************************************************************************************
    /// <summary>
    /// بازگرداندن آخرين رديف ثبت شده از يک شيء
    /// </summary>
    /// <returns></returns>
    int GetLast();
    //********************************************************************************************************************
    /// <summary>
    /// ذخيره سازي تمامي تغييرات در ديتا کانتکست اصلي سيستم و اعمال در ديتابيس
    /// </summary>
    void Save();
    //********************************************************************************************************************
}