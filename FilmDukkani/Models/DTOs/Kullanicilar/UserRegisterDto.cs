using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "Ad alanı girilmedi!")]
        [Display(Name = "Ad")]
        [MinLength(2,ErrorMessage ="Ad çok kısa")]
        [MaxLength(50,ErrorMessage ="50'nin altında değer giriniz.")]
        public string? Adi { get; set; }

        [Required(ErrorMessage = "Soyad alanı girilmedi!")]
        [Display(Name = "Soyad")]
        [MinLength(2, ErrorMessage = "Soyad çok kısa")]
        public string? Soyadi { get; set; }
        [Display(Name = "TC Kimlik No")]
        public string? TCKN { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre eşleşmiyor!")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Sifre")]
        public string SifreTekrar { get; set; }

        
        //[Display(Name = "Kabul Et")]
        //public bool KabulEt { get; set; }




    }
}
