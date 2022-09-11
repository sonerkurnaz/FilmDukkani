using FilmDukkani.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Models.DTOs.Fimler
{
    public class FilmUpdateDto
    {
        public int Id { get; set; }
        public byte[]? Resim { get; set; }
        [Display(Name = "Film Adı")]
        public string? FilmAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }
        [Display(Name = "Yönetmen")]
        public string? Yonetmeni { get; set; }
        [Display(Name = "Özet")]
        public string? Ozeti { get; set; }
        [Display(Name = "Yapım Yılı")]
        public int YapimYili { get; set; }
        [Display(Name = "Alt Yazı")]
        public string? AltYazilari { get; set; }
        [Display(Name = "Fiyat")]
        public decimal? Fiyat { get; set; }
        [Display(Name = "Adet")]
        public decimal? Adet { get; set; }
        public List<FilmKategori> FilmKategori { get; set; }
    }
}
