using System.Linq.Expressions;
using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Data.EntityFramework.Infrastructures.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entekhab.Data.EntityFramework.Infrastructures.Repositories;

public class DalRepository<T> : IDal<T> where T : class
{
    private readonly MainDbContext _db;
    //********************************************************************************************************************
    public DalRepository(MainDbContext dbContext)
    {
        _db = dbContext;
    }
    //********************************************************************************************************************
    public void Add(T model)
    {
        _db.Add(model);
    }
    //********************************************************************************************************************
    public void AddRange(List<T> model)
    {
        _db.AddRange(model);
    }
    //********************************************************************************************************************
    public void Update(T model)
    {
        _db.Update(model);
    }
    //********************************************************************************************************************
    public void UpdateRange(List<T> model)
    {
        _db.UpdateRange(model);
    }
    //********************************************************************************************************************
    public void Delete(int id)
    {
        var dbSet = _db.Set<T>();
        var entity = dbSet.Find(id);
        _db.Entry(entity).State = EntityState.Deleted;
    }
    //********************************************************************************************************************
    public void Delete(T model)
    {
        _db.Remove(model);
    }
    //********************************************************************************************************************
    public void Delete(Expression<Func<T, bool>> predicate)
    {
        var dbSet = _db.Set<T>();

        var range = dbSet.Where(predicate);
        dbSet.RemoveRange(range);
    }
    //********************************************************************************************************************
    public T Find(int id)
    {
        var dbSet = _db.Set<T>();
        return dbSet.Find(id);
    }
    //********************************************************************************************************************
    private IEnumerable<IProperty> GetPrimaryKeyProperties<T>()
    {
        return _db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
    }
    //********************************************************************************************************************
    private Expression<Func<T, bool>> FilterByPrimaryKeyPredicate<T>(int id)
    {
        var keyProperties = GetPrimaryKeyProperties<T>();
        var parameter = Expression.Parameter(typeof(T), "e");
        var body = keyProperties
            // e => e.PK[i] == id[i]
            .Select((p, i) => Expression.Equal(
                Expression.Property(parameter, p.Name),
                Expression.Convert(
                    Expression.PropertyOrField(Expression.Constant(new { id }), "id"),
                    p.ClrType)))
            .Aggregate(Expression.AndAlso);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
    //********************************************************************************************************************
    public T Find(int id, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().Where(FilterByPrimaryKeyPredicate<T>(id));

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query.FirstOrDefault();
    }
    //********************************************************************************************************************
    public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
    {
        var dbSet = _db.Set<T>();
        return dbSet.Where(predicate);
    }
    //********************************************************************************************************************
    public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().Where(predicate);

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query;
    }
    //********************************************************************************************************************
    public T FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        var dbSet = _db.Set<T>();
        return dbSet.Where(predicate).FirstOrDefault();
    }
    //********************************************************************************************************************
    public T FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().Where(predicate);

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query.FirstOrDefault();
    }
    //********************************************************************************************************************
    public IEnumerable<T> SelectAll()
    {
        var dbSet = _db.Set<T>();
        return dbSet.AsEnumerable();
    }
    //********************************************************************************************************************
    public IEnumerable<T> SelectAll(params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().AsQueryable();

        if (includeExpressions == null)
            return query.AsEnumerable();

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query.AsEnumerable();
    }
    //********************************************************************************************************************
    public IQueryable<T> SelectAllAsQuerable(params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().AsQueryable();

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query;
    }
    //********************************************************************************************************************
    public IQueryable<T> SelectAllAsQuerable(Expression<Func<T, bool>> predicate)
    {
        var query = _db.Set<T>().Where(predicate).AsQueryable();

        return query;
    }
    //********************************************************************************************************************
    public IQueryable<T> SelectAllAsQuerable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _db.Set<T>().Where(predicate).AsQueryable();

        if (includeExpressions.Any())
        {
            query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return query;
    }
    //********************************************************************************************************************
    public int GetCount(Expression<Func<T, bool>> predicate)
    {
        var dbSet = _db.Set<T>();
        return dbSet.Count(predicate);
    }
    //********************************************************************************************************************
    public int GetLast()
    {
        //    DbSet<T> dbSet = _db.Set<T>();
        //    if (dbSet.Any())
        //        return dbSet.OrderByDescending().First().Id;
        //    else
        return 0;
    }
    //********************************************************************************************************************
    public void Save()
    {
        _db.SaveChanges();
    }
    //********************************************************************************************************************
    public void Dispose()
    {
        //Dispose(true);
        GC.SuppressFinalize(this);
    }
    //********************************************************************************************************************
    //protected virtual void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        if (_db != null)
    //        {
    //            _db.Dispose();
    //            _db = null;
    //        }
    //    }
    //}
    //********************************************************************************************************************
}
