using FilmDukkani.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Models.DTOs.Fimler
{
    public class FilmListDto
    {
        public int Id { get; set; }

        public byte[]? Resim { get; set; }
        [Display(Name = "Film Adı")]
        public string FilmAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Yönetmen")]
        public string Yonetmeni { get; set; }
        [Display(Name = "Kategorisi")]
        public List<FilmKategori> FilmKategori { get; set; }
        [Display(Name = "Yapım Yılı")]
        public int YapimYili { get; set; }
    }
}
