using FilmDukkani.BL.Abstract;
using FilmDukkani.Entities;

namespace FilmDukkani.BL.Concrete
{
    public class FilmManager : ManagerBase<Film>, IFilmManager
    {
        public List<Film> FilmleriGetir()
        {
            
            var result = base.repository.GetAll();
            return result.ToList();
        }
    }
}
