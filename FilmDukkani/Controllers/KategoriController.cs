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

        public KategoriController(IKategoriManager manager, SqlDbContext context, IMapper mapper)
        {
            this.manager = manager;
            this.context = context;
            this.mapper = mapper;

        }

        public IActionResult Index(KategoriListDto dto)
        {
            var sonuc = manager.GetAll();
            return View(sonuc);
        }
        #region Create



        public IActionResult Create(KategoriCreateDto createDto)
        {

            return View(createDto);
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                context.Kategoriler.Add(kategori);
                context.SaveChanges();
            }


            return RedirectToAction("Index");
        }
        #endregion
        #region Delete


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = context.Kategoriler.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            var remove = context.Kategoriler.FirstOrDefault(p => p.Id == kategori.Id);

            manager.Delete(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            Kategori kategori = context.Kategoriler.Find(id);
            return View(kategori);
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
