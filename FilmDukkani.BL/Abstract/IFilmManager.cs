using FilmDukkani.Entities;

namespace FilmDukkani.BL.Abstract
{
    public interface IFilmManager : IManagerBase<Film>
    {
        List<Film> FilmleriGetir();
        //Film GetById(int id);
    }
}
