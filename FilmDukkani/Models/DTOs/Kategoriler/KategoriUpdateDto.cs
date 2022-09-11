using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Models.DTOs.Kategoriler
{
    public class KategoriUpdateDto
    {
        [Required]
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
