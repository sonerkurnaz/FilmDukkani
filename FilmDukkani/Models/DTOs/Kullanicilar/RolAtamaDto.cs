using Microsoft.AspNetCore.Identity;

namespace FilmDukkani.Models.DTOs.Kullanicilar
{
    public class RolAtamaDto
    {
        public IdentityRole Role { get; set; }
        public IList<AppUser> HasRole { get; set; }
        public IList<AppUser> HasNotRole { get; set; }

        public string RoleName { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
