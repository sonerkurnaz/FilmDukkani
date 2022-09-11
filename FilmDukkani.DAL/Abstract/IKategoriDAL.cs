using FilmDukkani.Entities;

namespace FilmDukkani.DAL.Abstract
{
    public interface IKategoriDAL : IBaseRepository<Kategori>
    {
        List<Kategori> KategorileriAl();
    }
}
