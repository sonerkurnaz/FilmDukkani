using FilmDukkani.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            RegisterDTO dTO = new();
            return View();
        }
    }
}
