using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Models.DTOs.Fimler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class FilmController : Controller
    {
        
        private readonly IFilmManager filmManager;
        

        public FilmController(IFilmManager filmManager)
        {
            
            this.filmManager = filmManager;
            
        }
        public IActionResult Index()
        {
            var sonuc = filmManager.GetAllInclude();
            return View(sonuc);
        }
    }
}
