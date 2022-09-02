namespace FilmDukkani.Entities
{
    public class Adres : BaseEntity
    {
        public int Id { get; set; }
        public int? SehirId { get; set; }
        public string CaddeSokak { get; set; }

    }
}
