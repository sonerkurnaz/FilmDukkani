namespace FilmDukkani.Models.DTOs.Fimler
{
    public class FilmCreateDto
    {
        public byte[]? Resim { get; set; }
        public string FilmAdi { get; set; }
        public string Aciklama { get; set; }
        public string Yonetmeni { get; set; }
        public int YapimYili { get; set; }
        public decimal? Fiyat { get; set; }
    }
}
