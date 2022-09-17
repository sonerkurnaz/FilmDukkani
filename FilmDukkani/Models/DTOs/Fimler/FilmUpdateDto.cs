using FilmDukkani.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Models.DTOs.Fimler
{
    public class FilmUpdateDto
    {
        public int Id { get; set; }
        
        [Display(Name = "Film Adı")]
        public string? FilmAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }
        [Display(Name = "Yönetmen")]
        public string? Yonetmeni { get; set; }
        
        [Display(Name = "Yapım Yılı")]
        public int YapimYili { get; set; }
        
        [Display(Name = "Fiyat")]
        public decimal? Fiyat { get; set; }
        public string? Puan { get; set; }
        public string? Sure { get; set; }
        [Display(Name = "Adet")]
        public decimal? Adet { get; set; }
        public List<FilmKategori>? FilmKategori { get; set; }
        public Fotograf? Fotograf { get; set; }

        public IFormFile? PhotoUrl { get; set; }
    }
}
