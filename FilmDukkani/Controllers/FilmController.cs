using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Fimler;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace FilmDukkani.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "manager")]
    public class FilmController : Controller
    {


        private readonly IFilmManager manager;
        private readonly SqlDbContext context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public FilmController(IFilmManager manager, SqlDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.manager = manager;
            this.context = context;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index(FilmListDto dto)
        {
            Film film = mapper.Map<Film>(dto);


            var sonuc = manager.GetAll();
            return View(sonuc);
        }
        public IActionResult Create()
        {
            var film = new FilmCreateDto();
            return View(film);
        }
        [HttpPost]
        public IActionResult Create(FilmCreateDto createDto)
        {
            var sonuc = mapper.Map<Film>(createDto);

            manager.Add(sonuc);
            context.SaveChanges();

            //Fotograf foto = new Fotograf();

            //string wwwrootPath = hostEnvironment.WebRootPath;

            //string fileName = Path.GetFileNameWithoutExtension(createDto.PhotoUrl.FileName);

            //fileName += DateTime.Now.ToString("yymmddhhmmss") + Path.GetExtension(createDto.PhotoUrl.FileName);
            //foto.Path = Path.Combine(wwwrootPath, fileName);

            //using (var fileStream = new FileStream(foto.Path, FileMode.CreateNew))
            //{
            //    createDto.PhotoUrl.CopyTo(fileStream);
            //}



            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Film film = context.Filmler.Find(id);
            return View(film);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Update(FilmUpdateDto updateDto)
        {
            //Film film = new()
            //{
            //    FilmAdi = updateDto.FilmAdi,
            //    Aciklama = updateDto.Aciklama,
            //    Adet = updateDto.Adet,
            //    AltYazilari = updateDto.AltYazilari,
            //    Yonetmeni = updateDto.Yonetmeni,
            //    Ozeti = updateDto.Ozeti,
            //    YapimYili = updateDto.YapimYili
            //};

            Film film = mapper.Map<Film>(updateDto);
            manager.Update(film);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Filmler == null)
            {
                return NotFound();
            }

            var film = await context.Filmler
                .Include(p => p.FilmKategorileri)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (context.Filmler == null)
            {
                return Problem();
            }
            var film = await context.Filmler.FindAsync(id);
            if (film != null)
            {
                context.Filmler.Remove(film);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Film film = manager.Get((int)id);

            if (film == null)
            {
                return NotFound();
            }
            return View(film);

        }
    }
}
