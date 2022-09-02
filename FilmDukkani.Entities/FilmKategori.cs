namespace FilmDukkani.Entities
{
    public class FilmKategori : BaseEntity
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
