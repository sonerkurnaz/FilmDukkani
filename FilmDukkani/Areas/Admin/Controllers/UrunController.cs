using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Areas.Admin.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
