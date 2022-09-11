using FilmDukkani.DAL;
using FilmDukkani.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserUpdateDto
    {
        [Display(Name = "Ad")]
        public string Adi { get; set; }
        [Display(Name = "Soyad")]
        public string Soyadi { get; set; }
        [Display(Name = "TC Kimlik No")]
        public string TCKN { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Gsm")]
        public string Gsm { get; set; }
        [Display(Name = "Kredi Kartı No")]
        public string KrediKartNo { get; set; }
        [Display(Name = "SKT")]
        public string KrediKartSkt { get; set; }
        [Display(Name = "CVC")]
        public string KrediKartCvc { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [Display(Name = "Adres")]
        public IList<Adres> Adresler { get; set; }
        public UserUpdateDto(AppUser user)
        {
            KullaniciAdi = user.UserName;
            Sifre = user.PasswordHash;
            Email = user.Email;
        }
    }
}
