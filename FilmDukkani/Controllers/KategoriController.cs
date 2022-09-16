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

        public IActionResult Index()
        {

            var sonuc = manager.GetAll();
            context.SaveChanges();
            return View(sonuc);
        }
        #region Create



        public IActionResult Create(KategoriListDto listDto)
        {

            return View(listDto);
        }
        [HttpPost]
        public IActionResult Create(KategoriCreateDto createDto)
        {
            var sonuc = mapper.Map<Kategori>(createDto);
            manager.Add(sonuc);
            context.SaveChanges();



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
        public IActionResult Update(KategoriUpdateDto updateDto)
        {
            Kategori kategori = mapper.Map<Kategori>(updateDto);
            manager.Update(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
