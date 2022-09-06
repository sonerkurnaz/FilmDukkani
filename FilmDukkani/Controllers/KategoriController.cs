using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class KategoriController : Controller
    {
        
        
        private readonly IKategoriManager manager;
        

        public KategoriController(IKategoriManager manager)
        {
            this.manager = manager;
           
            
            
        }
        public IActionResult Index()
        {
            KategoriListDto kategoriList = new();
            var sonuc = manager.GetAll();            
            return View(sonuc);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
