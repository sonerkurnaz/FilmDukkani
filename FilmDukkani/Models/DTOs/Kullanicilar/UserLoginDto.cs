using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı alani zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        [DataType(DataType.Text)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre girmediniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}
