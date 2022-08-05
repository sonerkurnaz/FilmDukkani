using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
