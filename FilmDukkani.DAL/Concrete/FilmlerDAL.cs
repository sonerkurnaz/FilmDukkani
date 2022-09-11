using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;

namespace FilmDukkani.DAL.Concrete
{
    public class FilmlerDAL : BaseRepository<Film>, IFilmlerDAL
    {
        public List<Film> FilmleriGetir()
        {
            using (var context = new SqlDbContext()) 
            {
                 return context.Filmler.ToList();
            }
        }
    }
}
