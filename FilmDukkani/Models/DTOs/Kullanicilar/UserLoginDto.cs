using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserLoginDto
    {

        [Required]
        [MinLength(5, ErrorMessage = "Email alanı en az 5 karakter olmalıdır.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
