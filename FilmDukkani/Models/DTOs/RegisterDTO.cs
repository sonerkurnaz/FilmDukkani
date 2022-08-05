using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }

        [Required]
        public bool KabulEt { get; set; }




    }
}
