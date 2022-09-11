using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Kategoriler
{
    public class KategoriCreateDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
