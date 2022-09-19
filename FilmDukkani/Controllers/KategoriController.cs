using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FilmDukkani.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "manager")]
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
        [AllowAnonymous]
        public IActionResult Index()
        {

            var sonuc = manager.GetAll();
            context.SaveChanges();
            return View(sonuc);
        }
        #region Create



        public IActionResult Create(Kategori kategori)
        {

            return View(kategori);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(KategoriCreateDto createDto)
        {
            
            Kategori kategori = mapper.Map<Kategori>(createDto);
            
            context.Kategoriler.Add(kategori);
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

        [HttpPost,ValidateAntiForgeryToken]
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

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Update(KategoriUpdateDto updateDto)
        {
            Kategori kategori = mapper.Map<Kategori>(updateDto);
            manager.Update(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Kategori kategori  = manager.Get((int)id);

            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
            #endregion
        }
    }
}
