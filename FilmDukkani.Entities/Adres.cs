namespace FilmDukkani.Entities
{
    public class Adres : BaseEntity
    {
        
        public int? SehirId { get; set; }
        public Sehir Sehir { get; set; }
        public string CaddeSokak { get; set; }

    }
}
