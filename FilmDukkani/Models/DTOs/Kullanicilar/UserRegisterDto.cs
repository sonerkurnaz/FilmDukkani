using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Ad alani 2'den az olamaz")]

        public string Ad { get; set; }

        
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [StringLength(50, ErrorMessage = "Soyad alanı 50 karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "Soyad alanı 2'den az olamaz")]
        public string Soyad { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre eşleşmiyor!")]

        [DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }

        [Required]
        public bool KabulEt { get; set; }




    }
}
