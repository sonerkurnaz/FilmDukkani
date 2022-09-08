using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "UserName alani zorunludur")]
        [Display(Name = "KullaniciAdi")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public string ReturnUrl { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
