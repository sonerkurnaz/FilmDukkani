using FilmDukkani.Entities;

namespace FilmDukkani.Models.DTOs.Adresler
{
    public class AdresCreateDto
    {
        public Sehir Sehir { get; set; }
        public string CaddeSokak { get; set; }
    }
}
