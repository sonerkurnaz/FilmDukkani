using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using System.Linq.Expressions;

namespace FilmDukkani.DAL.Concrete
{
    public class RepositoryBase<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected SqlDbContext db;
        public RepositoryBase()
        {
            db = new SqlDbContext();
        }

        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
