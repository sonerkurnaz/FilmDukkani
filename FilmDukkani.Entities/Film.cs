using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Entities
{
    public class Film : BaseEntity
    {
        
        public string? FilmAdi { get; set; }
        public string? Aciklama { get; set; }
        public string? Yonetmeni { get; set; }
        public string? Puan { get; set; }
        
        public int YapimYili { get; set; }
        public string? Sure { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? Adet { get; set; }      
        
        public List<FilmKategori> FilmKategorileri { get; set; }
        public List<Fotograf> Fotograflar { get; set; }

    }
}
