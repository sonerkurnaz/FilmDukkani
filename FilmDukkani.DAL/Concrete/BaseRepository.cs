using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilmDukkani.DAL.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected SqlDbContext db;
        public BaseRepository()
        {
            db = new SqlDbContext();
        }

        public virtual int Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public virtual int Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            return db.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return db.Set<T>().ToList();
            }
            else
            {
                return db.Set<T>().Where(filter).ToList();
            }
        }

        public virtual IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            var query = db.Set<T>().Where(filter);
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        }

        public virtual int Update(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChanges();
        }
    }
}
