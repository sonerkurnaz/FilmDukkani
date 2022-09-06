using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Models.DTOs.Fimler;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class FilmController : Controller
    {
               
        
        private readonly IFilmManager manager;
       
        

        public FilmController(IFilmManager manager)
        {
            
            
            
            this.manager = manager;
            
            
        }
        public IActionResult Index(FilmListDto filmList)
        {
            
            var sonuc = manager.GetAll();
            return View(sonuc);
        }
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
