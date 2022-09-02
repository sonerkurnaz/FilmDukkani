namespace FilmDukkani.Entities
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public IList<Film> Filmler { get; set; }



    }
}
