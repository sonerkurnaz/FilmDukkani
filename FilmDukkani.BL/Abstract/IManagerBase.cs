using FilmDukkani.Entities;
using System.Linq.Expressions;

namespace FilmDukkani.BL.Abstract
{
    public interface IManagerBase<T> where T : BaseEntity, new()
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        T Get(int id);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] include);
    }
}
