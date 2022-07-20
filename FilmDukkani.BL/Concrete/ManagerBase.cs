using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Abstract;
using FilmDukkani.Entities;
using System.Linq.Expressions;

namespace FilmDukkani.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        protected IBaseRepository<T> repository;
        public int Add(T entity)
        {
            return repository.Add(entity);
        }

        public int Delete(T entity)
        {
            return repository.Delete(entity);
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return repository.GetAll(null);
        }

        public IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            return repository.GetAllInclude(filter, include);
        }

        public int Update(T entity)
        {
            return repository.Update(entity);
        }
    }
}
