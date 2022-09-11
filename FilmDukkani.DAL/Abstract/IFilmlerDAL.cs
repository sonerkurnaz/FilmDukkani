using FilmDukkani.Entities;

namespace FilmDukkani.DAL.Abstract
{
    public interface IFilmlerDAL : IBaseRepository<Film>
    {
        List<Film> FilmleriGetir();
    }
}
