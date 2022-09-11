using FilmDukkani.Entities;

namespace FilmDukkani.BL.Abstract
{
    public interface IKategoriManager : IManagerBase<Kategori>
    {
        int AddWithName(string categroyName, string description);
    }
}
