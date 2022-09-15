using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage ="Zorunlu Alan.")]
        [MinLength(2, ErrorMessage = "Ad alani 2'den az olamaz")]
        [Display(Name = "Ad")]
        public string Adi { get; set; }
       
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [StringLength(50, ErrorMessage = "Soyad alanı 50 karakterden büyük olamaz")]
        [MinLength(2, ErrorMessage = "Soyad alanı 2'den az olamaz")]
        [Display(Name = "Soyad")]
        public string Soyadi { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre eşleşmiyor!")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }

        
        [Display(Name = "Kabul Et")]
        public bool KabulEt { get; set; }




    }
}
