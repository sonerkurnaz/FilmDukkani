using System.ComponentModel.DataAnnotations;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class UserLoginDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Email alanı en az 5 karakter olmalıdır.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }

    }
}
