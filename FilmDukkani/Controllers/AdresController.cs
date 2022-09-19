using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Adresler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmDukkani.Controllers
{
    public class AdresController : Controller
    {
        private readonly IAdresManager manager;
        private readonly IMapper mapper;
        private readonly SqlDbContext context;

        public AdresController(IAdresManager manager,IMapper mapper,SqlDbContext context)
        {
            this.manager = manager;
            this.mapper = mapper;
            this.context = context;
        }
        // GET: AdresController
        public ActionResult Index()
        {
            Sehir sehir = new();
            
            var sonuc = manager.GetAll();
            context.SaveChanges();
            return View(sonuc);
        }

        // GET: AdresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdresController/Create
        public ActionResult Create(Adres adres)
        {
            return View(adres);
        }

        // POST: AdresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdresCreateDto adresCreate)
        {
            Adres adres = mapper.Map<Adres>(adresCreate);
            
            manager.Add(adres);
            context.SaveChanges();
            
            return View(adres);
        }

        // GET: AdresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
