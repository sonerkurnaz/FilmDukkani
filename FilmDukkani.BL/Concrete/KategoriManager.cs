using FilmDukkani.BL.Abstract;
using FilmDukkani.Entities;

namespace FilmDukkani.BL.Concrete
{
    public class KategoriManager : ManagerBase<Kategori>, IKategoriManager
    {
        public int AddWithName(string kategoriAdi, string aciklama)
        {
            var result = base.GetAll(p => p.KategoriAdi == kategoriAdi);

            if (result != null)
            {
                throw new Exception("Bu kategori den daha önce tanimlanmistir.");
            }

            Kategori kategori = new Kategori();
            kategori.KategoriAdi = kategoriAdi;
            kategori.Aciklama = aciklama;
            return base.Add(kategori);
        }
    }
}
