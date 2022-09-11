using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;

namespace FilmDukkani.DAL.Concrete
{
    public class KategoriDAL : BaseRepository<Kategori>, IKategoriDAL
    {
        public List<Kategori> KategorileriAl()
        {
            var context = new SqlDbContext();
            return context.Kategoriler.ToList();
        }
    }
}
