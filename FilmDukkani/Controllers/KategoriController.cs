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
        
        private readonly KategoriListDto listDto;
        private readonly IKategoriManager manager;
        private readonly IMapper mapper;

        public KategoriController(IKategoriManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
            
        }
        public IActionResult Index()
        {
            var sonuc = manager.GetAll();            
            return View(sonuc);
        }
    }
}
