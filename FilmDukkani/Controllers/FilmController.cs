using AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.DAL.Contexts;
using FilmDukkani.Entities;
using FilmDukkani.Models.DTOs.Fimler;
using FilmDukkani.Models.DTOs.Kategoriler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmDukkani.Controllers
{
    public class FilmController : Controller
    {


        private readonly IFilmManager manager;
        private readonly SqlDbContext context;

        private readonly IMapper mapper;

        public FilmController(IFilmManager manager, SqlDbContext context, IMapper mapper)
        {
            this.manager = manager;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index(FilmListDto listDto)
        {
            Film film = mapper.Map<Film>(listDto);

            var sonuc = manager.GetAll();
            return View(sonuc);
        }
        public IActionResult Create()
        {
            FilmCreateDto createDto = new();
            return View(createDto);
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {

            context.Filmler.Add(film);
            context.SaveChanges();
            return RedirectToAction("Index");

            return View(film);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Film film = context.Filmler.Find(id);
            return View(film);
        }
        [HttpPost]
        public IActionResult Update(Film film)
        {
            context.Update(film);
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
                .Include(p => p.FilmKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }
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
        
        public IActionResult Details(int id)
        {
            Film film = context.Filmler.Find(id);
            return View(film);
        }
    }
}
