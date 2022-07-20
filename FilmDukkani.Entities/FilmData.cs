namespace FilmDukkani.Entities
{
    public class FilmData : BaseEntity
    {
        public string FilmAdi { get; set; }
        public string Yonetmeni { get; set; }
        public string Ozeti { get; set; }
        public string YapimYili { get; set; }
        public string AltYazilari { get; set; }
        public string Tedarikci { get; set; }
    }
}
