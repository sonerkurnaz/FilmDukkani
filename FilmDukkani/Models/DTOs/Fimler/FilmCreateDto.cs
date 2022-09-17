using FilmDukkani.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Fimler
{
    public class FilmCreateDto
    {
        public int Id { get; set; }
        
        
        [Required]
        [Display(Name ="Film Adı")]
        public string FilmAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }
        [Display(Name = "Yönetmen")]
        public string? Yonetmeni { get; set; }
        [Display(Name = "Yapım Yılı")]
        public string? Sure { get; set; }
        public string? Puan { get; set; }
        public int YapimYili { get; set; }
        public decimal? Fiyat { get; set; }
        public Fotograf? Fotograf { get; set; }

        public IFormFile PhotoUrl { get; set; }
    }
}
