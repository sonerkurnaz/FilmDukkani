namespace FilmDukkani.Entities
{
    public class Film : BaseEntity
    {
        public string FilmAdi { get; set; }
        public string Aciklama { get; set; }
        public string Yonetmeni { get; set; }
        public string Ozeti { get; set; }
        public int YapimYili { get; set; }
        public string AltYazilari { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? Adet { get; set; }

    }
}
