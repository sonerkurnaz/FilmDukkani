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
        private readonly SqlDbContext context;
        private readonly IMapper mapper;

        public KategoriController(IKategoriManager manager,SqlDbContext context,IMapper mapper)
        {
            this.manager = manager;
            this.context = context;
            this.mapper = mapper;
            
        }

        public IActionResult Index()
        {
            KategoriListDto kategoriList = new();
            var sonuc = manager.GetAll();            
            return View(sonuc);
        }
        #region Create

        

        public IActionResult Create()
        {
            KategoriCreateDto createDto = new();
            return View(createDto);
        }
        [HttpPost]
        public IActionResult Create(KategoriCreateDto kategori)
        {
                
                context.Kategoriler.Add(kategori);
                context.SaveChanges();
                return RedirectToAction("Index");



            return View(kategori);
        }
        #endregion
        #region Delete

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var shipper = context.Kategoriler.Find(id);
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            var removeShipper = context.Kategoriler.FirstOrDefault(p => p.Id == kategori.Id);

            context.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            Kategori shipper = context.Kategoriler.Find(id);
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Update(Kategori kategori)
        {
            context.Update(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
