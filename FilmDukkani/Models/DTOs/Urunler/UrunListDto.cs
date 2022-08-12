namespace FilmDukkani.Models.DTOs.Urunler
{
    public class UrunListDto
    {
        public string UrunAdi { get; set; }
        public string? UrunAciklama { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? Adet { get; set; }
    }
}
