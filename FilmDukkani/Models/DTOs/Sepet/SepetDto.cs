namespace FilmDukkani.Models.DTOs.Sepet
{
    public class SepetDto
    {
        public int SepetId { get; set; }
        public List<SepetItemModel> SepetItems { get; set; }
        public decimal ToplamFiyat()
        {
            return SepetItems.Sum(i => i.Fiyat * i.Adet);
        }
    }
    public class SepetItemModel
    {
        public int SepetItemId { get; set; }
        public int FilmId { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string ImageUrl { get; set; }
        public int Adet { get; set; }
    }
}
