using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
