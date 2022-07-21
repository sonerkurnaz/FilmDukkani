using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Concrete;
using FilmDukkani.Entities;
using System.Linq.Expressions;

namespace FilmDukkani.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        protected IBaseRepository<T> repository;
        public ManagerBase()
        {
            repository = new BaseRepository<T>();
        }
        public virtual int Add(T entity)
        {
            return repository.Add(entity);
        }

        public virtual int Delete(T entity)
        {
            return repository.Delete(entity);
        }

        public virtual T Get(int id)
        {
            return repository.Get(id);
        }

        public virtual IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return repository.GetAll(null);
        }

        public virtual IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            return repository.GetAllInclude(filter, include);
        }

        public virtual int Update(T entity)
        {
            return repository.Update(entity);
        }
    }
}
