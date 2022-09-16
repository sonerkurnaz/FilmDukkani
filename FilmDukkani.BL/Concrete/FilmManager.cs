using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Concrete;
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

        //public Film GetById(int id)
        //{
        //    return filmManager.GetById(id);
        //}
    }
}
