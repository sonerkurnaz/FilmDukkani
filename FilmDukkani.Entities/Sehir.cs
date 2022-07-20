namespace FilmDukkani.Entities
{
    public class Sehir : BaseEntity
    {
        public string SehirAdi { get; set; }
        public ICollection<Ilce> Ilce { get; set; }
    }
}
