namespace FilmDukkani.Entities
{
    public class Urun : BaseEntity
    {
        public string UrunAdi { get; set; }
        public string? UrunAciklama { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? Adet { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

    }
}
