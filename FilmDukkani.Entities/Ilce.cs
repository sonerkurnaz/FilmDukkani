namespace FilmDukkani.Entities
{
    public class Ilce : BaseEntity
    {
        public string IlceAdi { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
    }
}
