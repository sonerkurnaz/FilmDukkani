using FilmDukkani.Entities;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserUpdateDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string KrediKartNo { get; set; }
        public string KrediKartSkt { get; set; }
        public string KrediKartCvc { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }


        public IList<Adres> Adresler { get; set; }
    }
}
